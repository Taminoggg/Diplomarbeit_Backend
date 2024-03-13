using ContainerToolDB;
using System;
using System.Collections.Generic;
using System.Data;

namespace ContainerToolDBDb;

public partial class Order
{
    public int Id { get; set; }
    public bool Canceled { get; set; }
    public bool SuccessfullyFinished { get; set; }
    public string Status { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string CreatedByCS { get; set; } = null!;
    public string CreatedBySD { get; set; } = null!;
    public DateTime LastUpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? FinishedOn { get; set; }
    public int? ChecklistId { get; set; }
    public int? CsId { get; set; }
    public int? TlId { get; set; }
    public int? PpId { get; set; }
    public string? AdditionalInformation { get; set; }
    public virtual ICollection<MessageConversation> MessageConversations { get; } = new List<MessageConversation>();
    public virtual Checklist? Checklist { get; set; } = null!;
    public virtual Csinquiry? Cs { get; set; }
    public virtual Tlinquiry? Tl { get; set; }
    public virtual ProductionPlanning? ProductionPlanning { get; set; }
}
