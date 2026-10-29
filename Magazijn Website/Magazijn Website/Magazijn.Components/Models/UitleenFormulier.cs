using System.ComponentModel.DataAnnotations;

namespace Magazijn.Components.Models;

public sealed class UitleenFormulier
{
    [Required(ErrorMessage = "Vul je naam in.")]
    [StringLength(100, ErrorMessage = "Gebruik maximaal 100 tekens.")]
    public string Naam { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vul je e-mailadres in.")]
    [EmailAddress(ErrorMessage = "Vul een geldig e-mailadres in.")]
    public string Email { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Kies een vestiging.")]
    public int VestigingId { get; set; } = 1;

    public AanvraagSoort Soort { get; set; } = AanvraagSoort.Lenen;

    [Required(ErrorMessage = "Kies een startdatum.")]
    public DateTime Vanaf { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Kies een terugbrengdatum.")]
    public DateTime Terugbrengdatum { get; set; } = DateTime.Today.AddDays(7);

    [StringLength(500, ErrorMessage = "Gebruik maximaal 500 tekens.")]
    public string? Opmerking { get; set; }

    public int MateriaalId { get; set; }
}
