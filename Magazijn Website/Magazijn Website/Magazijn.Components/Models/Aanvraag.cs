namespace Magazijn.Components.Models;

public enum AanvraagSoort
{
    Lenen,
    Reserveren
}

public sealed class Aanvraag
{
    public int Id { get; init; }
    public int MateriaalId { get; init; }
    public int VestigingId { get; init; }
    public string Naam { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime Vanaf { get; init; }
    public DateTime Terugbrengdatum { get; init; }
    public AanvraagSoort Soort { get; init; }
    public string? Opmerking { get; init; }
    public DateTime Aangemaakt { get; init; } = DateTime.Now;
}
