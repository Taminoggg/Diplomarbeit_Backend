namespace ContainerToolDBDb;

public class AddChecklistDto
{
    [RegularExpression(@"[\wÖÄÜöäü\-_\.]+$")] [Required] public string Checklistname { get; set; } = null!;
}