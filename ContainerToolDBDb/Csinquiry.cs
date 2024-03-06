using ContainerToolDB;

namespace ContainerToolDBDb;

public partial class Csinquiry
{
    public int Id { get; set; }

    public string Container { get; set; } = null!;

    public int Abnumber { get; set; }

    public int GrossWeightInKg { get; set; }

    public string Incoterm { get; set; } = null!;

    public int ContainersizeA { get; set; }

    public int ContainersizeB { get; set; }

    public int ContainersizeHc { get; set; }

    public bool FreeDetention { get; set; }

    public bool Thctb { get; set; }

    public DateTime ReadyToLoad { get; set; }

    public string LoadingPlattform { get; set; } = null!;
    public bool ApprovedByCrCs { get; set; }
    public DateTime? ApprovedByCrCsTime { get; set; }
    public bool IsDirectLine { get; set; }
    public bool IsFastLine { get; set; }

    public virtual ICollection<ArticleCR> Articles { get; } = new List<ArticleCR>();
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
