namespace ContainerToolDBDb;

public class AddChecklistDto
{
    [RegularExpression(@"[\wÖÄÜöäü\-_\.]+$")] [Required] public string CustomerName { get; set; } = null!;
}