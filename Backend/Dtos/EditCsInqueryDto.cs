namespace ContainerToolDBDb;

public class EditCsinquiryDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Id { get; set; }
    [Required] public string Container { get; set; } = null!;
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Abnumber { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int BruttoWeightInKg { get; set; }
    [Required] public string Incoterm { get; set; } = null!;
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int ContainersizeA { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int ContainersizeB { get; set; }
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int ContainersizeHc { get; set; }
    [Required] public bool FreeDetention { get; set; }
    [Required] public bool Thctb { get; set; }
    [Required] public string ReadyToLoad { get; set; } = null!;
    [Required] public string LoadingPlattform { get; set; } = null!;
}