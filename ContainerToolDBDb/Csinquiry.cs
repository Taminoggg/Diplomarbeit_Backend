using ContainerToolDB;
using System;
using System.Collections.Generic;

namespace ContainerToolDBDb;

public partial class Csinquiry
{
    public int Id { get; set; }

    public string Container { get; set; } = null!;

    public int Abnumber { get; set; }

    public int BruttoWeightInKg { get; set; }

    public string Incoterm { get; set; } = null!;

    public int ContainersizeA { get; set; }

    public int ContainersizeB { get; set; }

    public int ContainersizeHc { get; set; }

    public bool FreeDetention { get; set; }

    public bool Thctb { get; set; }

    public DateTime ReadyToLoad { get; set; }

    public string LoadingPlattform { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; } = new List<Article>();
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
