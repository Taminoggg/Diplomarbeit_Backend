namespace Backend.Dtos;

public class OrderOrdersDto
{
    [Required] public int[] OrderIds { get; set; } = null!;
    [Required] public bool Asc { get; set; }
}
