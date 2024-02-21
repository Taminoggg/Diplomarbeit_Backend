namespace Backend.Dtos;

public class EditPPArticleDto
{
    [Required] public int Id { get; set; }
    [Required] public string ShortText { get; set; } = null!;
    [Required] public string DeliveryDate { get; set; } = null!;
    [Required] public string Nozzle { get; set; } = null!;
    [Required] public string Factory { get; set; } = null!;
    [Required] public string ProductionOrder { get; set; } = null!;
    [Required] public string PlannedOrder { get; set; } = null!;
    [Required] public string Plant { get; set; } = null!;
}