namespace Magazijn.Components.Services;

using Magazijn.Components.Models;

public sealed class MagazijnService
{
    private readonly List<Materiaal> _materialen =
    [
        new()
        {
            Id = 1,
            Naam = "HDMI-kabel 2 m",
            Omschrijving = "4K HDMI-kabel voor beamers en schermen.",
            CategorieId = 1,
            Voorraad = new() { [1] = 12, [2] = 4 }
        },
        new()
        {
            Id = 2,
            Naam = "USB-C kabel 1 m",
            Omschrijving = "Opladen en data-overdracht.",
            CategorieId = 1,
            Voorraad = new() { [1] = 20, [2] = 6 }
        },
        new()
        {
            Id = 3,
            Naam = "Ethernet-kabel 5 m",
            Omschrijving = "Netwerkkabel voor bekabelde verbindingen.",
            CategorieId = 1,
            Voorraad = new() { [1] = 15, [2] = 3 }
        },
        new()
        {
            Id = 4,
            Naam = "DisplayPort-kabel 2 m",
            Omschrijving = "Voor monitors met DisplayPort.",
            CategorieId = 1,
            Voorraad = new() { [1] = 6, [2] = 0 }
        },
        new()
        {
            Id = 5,
            Naam = "Universele stroomadapter",
            Omschrijving = "Instelbare adapter met meerdere pluggen.",
            CategorieId = 2,
            Voorraad = new() { [1] = 5, [2] = 2 }
        },
        new()
        {
            Id = 6,
            Naam = "Powerbank 20.000 mAh",
            Omschrijving = "Voor apparaten tijdens excursies.",
            CategorieId = 2,
            Voorraad = new() { [1] = 8, [2] = 2 }
        },
        new()
        {
            Id = 7,
            Naam = "Verlengsnoer 5 m",
            Omschrijving = "Met overspanningsbeveiliging.",
            CategorieId = 2,
            Voorraad = new() { [1] = 10, [2] = 1 }
        },
        new()
        {
            Id = 8,
            Naam = "Raspberry Pi 5",
            Omschrijving = "Single-board computer voor projecten.",
            CategorieId = 3,
            Voorraad = new() { [1] = 4, [2] = 0 }
        },
        new()
        {
            Id = 9,
            Naam = "Arduino Uno",
            Omschrijving = "Microcontroller voor elektronica-opdrachten.",
            CategorieId = 3,
            Voorraad = new() { [1] = 9, [2] = 3 }
        },
        new()
        {
            Id = 10,
            Naam = "USB-microfoon",
            Omschrijving = "Voor opnames en online overleg.",
            CategorieId = 3,
            Voorraad = new() { [1] = 3, [2] = 1 }
        },
        new()
        {
            Id = 11,
            Naam = "Logitech webcam",
            Omschrijving = "Full HD-webcam.",
            CategorieId = 3,
            Voorraad = new() { [1] = 2, [2] = 0 }
        },
        new()
        {
            Id = 12,
            Naam = "Monitor 24 inch",
            Omschrijving = "Full HD-monitor met HDMI.",
            CategorieId = 4,
            Voorraad = new() { [1] = 6, [2] = 5 }
        },
        new()
        {
            Id = 13,
            Naam = "Beamer",
            Omschrijving = "Draagbare beamer voor presentaties.",
            CategorieId = 4,
            Voorraad = new() { [1] = 2, [2] = 0 }
        },
        new()
        {
            Id = 14,
            Naam = "Touchscreen 27 inch",
            Omschrijving = "Interactief scherm voor demo's.",
            CategorieId = 4,
            Voorraad = new() { [1] = 1, [2] = 1 }
        }
    ];

    private int _volgendeAanvraagId = 1;

    public IReadOnlyList<Vestiging> Vestigingen { get; } =
    [
        new(1, "Heerlen"),
        new(2, "Valencia")
    ];

    public IReadOnlyList<Categorie> Categorieen { get; } =
    [
        new(1, "Kabels"),
        new(2, "Stroom"),
        new(3, "Kleine apparatuur"),
        new(4, "Beeldschermen")
    ];

    public IReadOnlyList<Materiaal> Materialen => _materialen;

    public List<Aanvraag> Aanvragen { get; } = [];

    public Materiaal? Materiaal(int id) => _materialen.FirstOrDefault(m => m.Id == id);

    public string CategorieNaam(int id) =>
        Categorieen.FirstOrDefault(c => c.Id == id)?.Naam ?? "Onbekend";

    public string VestigingNaam(int id) =>
        Vestigingen.FirstOrDefault(v => v.Id == id)?.Naam ?? "Onbekend";

    public IReadOnlyList<Materiaal> Zoek(string? zoekterm, int categorieId = 0, int vestigingId = 0)
    {
        IEnumerable<Materiaal> resultaat = _materialen;

        if (!string.IsNullOrWhiteSpace(zoekterm))
        {
            var term = zoekterm.Trim();
            resultaat = resultaat.Where(m =>
                m.Naam.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                m.Omschrijving.Contains(term, StringComparison.OrdinalIgnoreCase));
        }

        if (categorieId > 0)
        {
            resultaat = resultaat.Where(m => m.CategorieId == categorieId);
        }

        if (vestigingId > 0)
        {
            resultaat = resultaat.Where(m => m.VoorraadVoor(vestigingId) > 0);
        }

        return resultaat.OrderBy(m => m.Naam).ToList();
    }

    public Aanvraag PlaatsAanvraag(UitleenFormulier form)
    {
        ArgumentNullException.ThrowIfNull(form);

        var materiaal = Materiaal(form.MateriaalId)
            ?? throw new InvalidOperationException("Kies een geldig materiaal.");

        if (Vestigingen.All(v => v.Id != form.VestigingId))
        {
            throw new InvalidOperationException("Kies een geldige vestiging.");
        }

        if (form.Terugbrengdatum.Date < form.Vanaf.Date)
        {
            throw new InvalidOperationException("De terugbrengdatum mag niet voor de startdatum liggen.");
        }

        if (form.Soort == AanvraagSoort.Lenen)
        {
            var voorraad = materiaal.VoorraadVoor(form.VestigingId);
            if (voorraad <= 0)
            {
                throw new InvalidOperationException($"'{materiaal.Naam}' is niet beschikbaar op deze vestiging.");
            }

            materiaal.Voorraad[form.VestigingId] = voorraad - 1;
        }

        var aanvraag = new Aanvraag
        {
            Id = _volgendeAanvraagId++,
            MateriaalId = materiaal.Id,
            VestigingId = form.VestigingId,
            Naam = form.Naam.Trim(),
            Email = form.Email.Trim(),
            Vanaf = form.Vanaf.Date,
            Terugbrengdatum = form.Terugbrengdatum.Date,
            Soort = form.Soort,
            Opmerking = form.Opmerking?.Trim()
        };

        Aanvragen.Add(aanvraag);
        return aanvraag;
    }
}
