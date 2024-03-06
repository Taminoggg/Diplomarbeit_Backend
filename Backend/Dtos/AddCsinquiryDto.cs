using System;
using System.Collections.Generic;

namespace ContainerToolDBDb;

public class AddCsinquiryDto
{
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
    [RegularExpression(@"^(?<day>[0-2]\d|3[0-1])\.(?<month>0\d|1[0-2])\.(?<year>\d{4})$", ErrorMessage = "Only date in the format dd.MM.yyyy allowed!")]
    [Required] public string ReadyToLoad { get; set; } = null!;
    [Required] public string LoadingPlattform { get; set; } = null!;
    [Required] public bool IsDirectLine { get; set; }
    [Required] public bool IsFastLine { get; set; }
}
