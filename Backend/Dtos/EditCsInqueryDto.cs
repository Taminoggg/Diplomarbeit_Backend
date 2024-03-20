namespace ContainerToolDBDb;

public class EditCsinquiryDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Id { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Abnumber { get; set; }
    [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Only positive numbers allowed!")]
    [Required] public int GrossWeightInKg { get; set; }
    [Required] public string Incoterm { get; set; } = null!;
    [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Only positive numbers allowed!")]
    [Required] public int ContainersizeA { get; set; }
    [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Only positive numbers allowed!")]
    [Required] public int ContainersizeB { get; set; }
    [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Only positive numbers allowed!")]
    [Required] public int ContainersizeHc { get; set; }
    [Required] public int FreeDetention { get; set; }
    [Required] public bool Thctb { get; set; }
    [Required] public bool Thcc { get; set; }
    [Required] public string ReadyToLoad { get; set; } = null!;
    [Required] public string Country { get; set; } = null!;
    [Required] public bool IsFastLine { get; set; }
    [Required] public bool IsDirectLine { get; set; }
}