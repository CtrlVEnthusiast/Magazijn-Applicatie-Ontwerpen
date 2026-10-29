using Magazijn.Components.Models;
using Magazijn.Components.Services;

namespace Magazijn.Components.Tests;

public class MagazijnServiceTests
{
    private static UitleenFormulier Formulier(int materiaalId, int vestigingId, AanvraagSoort soort) => new()
    {
        MateriaalId = materiaalId,
        VestigingId = vestigingId,
        Soort = soort,
        Naam = "Test Student",
        Email = "test@example.com"
    };

    [Fact]
    public void Lenen_verlaagt_voorraad_alleen_op_eigen_vestiging()
    {
        var service = new MagazijnService();
        var materiaal = service.Materiaal(9)!;
        var heerlen = materiaal.VoorraadVoor(1);
        var valencia = materiaal.VoorraadVoor(2);

        service.PlaatsAanvraag(Formulier(9, 1, AanvraagSoort.Lenen));

        Assert.Equal(heerlen - 1, materiaal.VoorraadVoor(1));
        Assert.Equal(valencia, materiaal.VoorraadVoor(2));
        Assert.Single(service.Aanvragen);
    }

    [Fact]
    public void Reserveren_kan_zonder_voorraad_en_wijzigt_niets()
    {
        var service = new MagazijnService();
        var materiaal = service.Materiaal(13)!; // Beamer: 0 op Valencia

        var aanvraag = service.PlaatsAanvraag(Formulier(13, 2, AanvraagSoort.Reserveren));

        Assert.Equal(AanvraagSoort.Reserveren, aanvraag.Soort);
        Assert.Equal(0, materiaal.VoorraadVoor(2));
    }

    [Fact]
    public void Lenen_zonder_voorraad_geeft_fout()
    {
        var service = new MagazijnService();

        Assert.Throws<InvalidOperationException>(
            () => service.PlaatsAanvraag(Formulier(13, 2, AanvraagSoort.Lenen)));
        Assert.Empty(service.Aanvragen);
    }

    [Fact]
    public void Zoek_filtert_op_vestiging_met_voorraad()
    {
        var service = new MagazijnService();

        var valencia = service.Zoek(null, vestigingId: 2);

        Assert.NotEmpty(valencia);
        Assert.DoesNotContain(valencia, m => m.Naam == "Beamer");
        Assert.All(valencia, m => Assert.True(m.VoorraadVoor(2) > 0));
    }
}
