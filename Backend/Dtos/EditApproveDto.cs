namespace ContainerToolDBDb;

public class EditApproveDto
{
    [Required] public int Id { get; set; }
    [Required] public bool Approve { get; set; }
}
