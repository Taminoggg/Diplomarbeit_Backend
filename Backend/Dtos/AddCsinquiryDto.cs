using System;
using System.Collections.Generic;

namespace ContainerToolDBDb;

public class AddCsinquiryDto
{
    [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only numbers greater than 0 allowed!")]
    [Required] public int Abnumber { get; set; }
    [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Only positive numbers allowed!")]
    [Required] public int BruttoWeightInKg { get; set; }
    [Required] public string Incoterm { get; set; } = null!;
    [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Only positive numbers allowed!")]
    [Required] public int ContainersizeA { get; set; }
    [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Only positive numbers allowed!")]
    [Required] public int ContainersizeB { get; set; }
    [RegularExpression(@"^[0-9]\d*$", ErrorMessage = "Only positive numbers allowed!")]
    [Required] public int ContainersizeHc { get; set; }
    [Required] public int FreeDetention { get; set; }
    [Required] public string Country { get; set; } = null!;
    [Required] public bool Thctb { get; set; }
    [Required] public bool Thcc { get; set; }
    [RegularExpression(@"^^(?<year>\d{4})\-(?<month>0\d|1[0-2])\-(?<day>[0-2]\d|3[0-1])$", ErrorMessage = "Only date in the format yyyy-MM-dd allowed!")]
    [Required] public string ReadyToLoad { get; set; } = null!;
    [Required] public bool IsDirectLine { get; set; }
    [Required] public bool IsFastLine { get; set; }
}
