namespace ContainerToolDBDb;

public class CsinquiryDto
{
    [Required] public int Id { get; set; }
    [Required] public int Abnumber { get; set; }
    [Required] public int GrossWeightInKg { get; set; }
    [Required] public string Incoterm { get; set; } = null!;
    [Required] public int ContainersizeA { get; set; }
    [Required] public string Country { get; set; } = null!;
    [Required] public int ContainersizeB { get; set; }
    [Required] public int ContainersizeHc { get; set; }
    [Required] public int FreeDetention { get; set; }
    [Required] public bool Thctb { get; set; }
    [Required] public bool Thcc { get; set; }
    [Required] public bool IsFastLine { get; set; }
    [Required] public bool IsDirectLine { get; set; }
    [Required] public string ReadyToLoad { get; set; } = null!;
    [Required] public bool ApprovedByCrCs { get; set; }
    [Required] public string ApprovedByCrCsTime { get; set; } = null!;
}