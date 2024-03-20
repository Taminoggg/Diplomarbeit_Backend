namespace Backend.Dtos;

public class EditPpPpArticleDto
{
    [Required] public int Id { get; set; }
    [Required] public int DeliveryDate { get; set; }
    public string? Nozzle { get; set; }
    public string? ShortText { get; set; }
    public string? Factory { get; set; } 
    public string? ProductionOrder { get; set; } 
    public string? PlannedOrder { get; set; }
    public string? Plant { get; set; }
}