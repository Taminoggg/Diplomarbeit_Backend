using System;
using System.Collections.Generic;

namespace ContainerToolDBDb;

public class AddCsinquiryDto
{
    [Required] public string Container { get; set; } = null!;
    [Required] public string FastLine { get; set; } = null!;
    [Required] public string DirectLine { get; set; } = null!;
    [Required] public string ArticleNumber { get; set; } = null!;
    [RegularExpression(@"\d", ErrorMessage = "Only numbers allowed")]
    [Required] public int Palletamount { get; set; }
    [Required] public string Customer { get; set; } = null!;
    [RegularExpression(@"\d", ErrorMessage = "Only numbers allowed")]
    [Required] public int Abnumber { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int BruttoWeightInKg { get; set; }
    [Required] public string Incoterm { get; set; } = null!;
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int ContainersizeA { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int ContainersizeB { get; set; }
    [RegularExpression(@"\d+", ErrorMessage = "Only numbers allowed")]
    [Required] public int ContainersizeHc { get; set; }
    [Required] public bool FreeDetention { get; set; }
    [Required] public bool Thctb { get; set; }
    [RegularExpression(@"(0[1-9]|[12]\d|3[01])\.(0[1-9]|1[0-2])\.\d{4}", ErrorMessage = "Datestring in the format dd.MM.yyyy allowed")]
    [Required] public string ReadyToLoad { get; set; } = null!;
    [Required] public string LoadingPlattform { get; set; } = null!;
}
