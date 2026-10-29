namespace Magazijn.Components.Models;

public sealed class Materiaal
{
    public int Id { get; init; }
    public string Naam { get; init; } = string.Empty;
    public string Omschrijving { get; init; } = string.Empty;
    public int CategorieId { get; init; }
    public Dictionary<int, int> Voorraad { get; init; } = new();

    public int Totaal => Voorraad.Values.Sum();

    public int VoorraadVoor(int vestigingId) => Voorraad.GetValueOrDefault(vestigingId);
}
