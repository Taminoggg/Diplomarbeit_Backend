namespace ContainerToolDBDb;

public class EditStatusDto
{
    [Required] public int Id { get; set; }
    [Required] public bool Status { get; set; }
}
