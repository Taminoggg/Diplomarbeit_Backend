namespace ContainerToolDBDb;

public class EditApproveOrderDto
{
    [Required] public int Id { get; set; }
    [Required] public bool Approve { get; set; }
}
