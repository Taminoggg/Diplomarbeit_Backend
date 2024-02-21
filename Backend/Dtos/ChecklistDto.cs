namespace ContainerToolDBDb;

public class ChecklistDto
{
    [Required] public int Id { get; set; }
    [Required] public string Checklistname { get; set; } = null!;
    [Required] public bool GeneratedByAdmin { get; set; }
}