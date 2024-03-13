using ContainerToolDBDb;

namespace ContainerToolDB;

public partial class ProductionPlanning
{
    public int Id { get; set; }
    public bool ApprovedByPpCs { get; set; }
    public bool ApprovedByPpPp { get; set; }
    public string RecievingCountry { get; set; } = null!;
    public char CustomerPriority { get; set; }
    public DateTime? ApprovedByPpCsTime { get; set; }
    public DateTime? ApprovedByPpPpTime { get; set; }
    public virtual ICollection<ArticlePP> Articles { get; } = new List<ArticlePP>();
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
