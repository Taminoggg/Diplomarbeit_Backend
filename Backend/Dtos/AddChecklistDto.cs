namespace ContainerToolDBDb;

public class AddChecklistDto
{
    [RegularExpression(@"[\wÖÄÜöäü\-_\.]+$")] [Required] public string Checklistname { get; set; } = null!;
    [Required] public bool GeneratedByAdmin { get; set; }
    public int? Id { get; set; }
}