using ContainerToolDB;
using System;
using System.Collections.Generic;
using System.Data;

namespace ContainerToolDBDb;

public partial class Order
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string CreatedBy { get; set; } = null!;
    public bool ApprovedByCrCs { get; set; }
    public bool ApprovedByCrTl { get; set; }
    public bool ApprovedByPpCs { get; set; }
    public bool ApprovedByPpPp { get; set; }
    public DateTime? ApprovedByCrCsTime { get; set; }
    public DateTime? ApprovedByCrTlTime { get; set; }
    public DateTime? ApprovedByPpCsTime { get; set; }
    public DateTime? ApprovedByPpPpTime { get; set; }
    public int Amount { get; set; }
    public DateTime LastUpdated { get; set; }
    public int ChecklistId { get; set; }
    public int Csid { get; set; }
    public int Tlid { get; set; }
    public string? AdditionalInformation { get; set; }
    public virtual Checklist Checklist { get; set; } = null!;
    public virtual ICollection<MessageConversation> MessageConversations { get; } = new List<MessageConversation>();
    public virtual Csinquiry Cs { get; set; } = null!;
    public virtual Tlinquiry Tl { get; set; } = null!;
}
