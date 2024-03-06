using ContainerToolDB;
using Microsoft.EntityFrameworkCore;

namespace ContainerToolDBDb;

public partial class ContainerToolDBContext : DbContext
{
    public ContainerToolDBContext() { }
    public ContainerToolDBContext(DbContextOptions<ContainerToolDBContext> options) : base(options) { }

    public virtual DbSet<Checklist> Checklists { get; set; }
    public virtual DbSet<Csinquiry> Csinquiries { get; set; }
    public virtual DbSet<File> Files { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<MessageConversation> MessageConversations { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<ArticleCR> ArticlesCR { get; set; }
    public virtual DbSet<ArticlePP> ArticlesPP { get; set; }
    public virtual DbSet<Step> Steps { get; set; }
    public virtual DbSet<StepChecklist> StepChecklists { get; set; }
    public virtual DbSet<Tlinquiry> Tlinquiries { get; set; }
    public virtual DbSet<ProductionPlanning> ProductionPlannings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticleCR>(entity =>
        {
            entity.ToTable("ArticlesCR");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.ArticleNumber).HasColumnName("ArticleNumber").IsRequired();
            entity.Property(e => e.CsinquiryId).HasColumnName("CsinquiryId").IsRequired();
            entity.Property(e => e.Pallets).HasColumnName("Pallets").IsRequired();

            entity.HasOne(d => d.Csinquiry)
                  .WithMany(p => p.Articles)
                  .HasForeignKey(d => d.CsinquiryId)
                  .IsRequired();
        });

        modelBuilder.Entity<ArticlePP>(entity =>
        {
            entity.ToTable("ArticlesPP");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.ArticleNumber).HasColumnName("ArticleNumber");
            entity.Property(e => e.MinHeigthRequired).HasColumnName("MinHeightRequired");
            entity.Property(e => e.DesiredDeliveryDate).HasColumnName("DesiredDeliveryDate");
            entity.Property(e => e.DeliveryDate).HasColumnName("DeliveryDate");
            entity.Property(e => e.ShortText).HasColumnName("ShortText").IsRequired();
            entity.Property(e => e.Factory).HasColumnName("Factory").IsRequired();
            entity.Property(e => e.Nozzle).HasColumnName("Nozzle").IsRequired();
            entity.Property(e => e.ProductionOrder).HasColumnName("ProductionOrder").IsRequired();
            entity.Property(e => e.PlannedOrder).HasColumnName("PlannedOrder").IsRequired();
            entity.Property(e => e.InquiryForFixedOrder).HasColumnName("InquiryForFixedOrder");
            entity.Property(e => e.InquiryForQuotation).HasColumnName("InquiryForQuotation");
            entity.Property(e => e.Pallets).HasColumnName("Pallets");
            entity.Property(e => e.ProductionPlanningId).HasColumnName("ProductionPlanningId");

            entity.HasOne(d => d.ProductionPlanning)
                  .WithMany(p => p.Articles)
                  .HasForeignKey(d => d.ProductionPlanningId)
                  .IsRequired();
        });

        modelBuilder.Entity<Csinquiry>(entity =>
        {
            entity.ToTable("CSInquiries");

            entity.Property(e => e.Abnumber).HasColumnName("ABNumber");
            entity.Property(e => e.GrossWeightInKg).HasColumnName("GrossWeightInKG");
            entity.Property(e => e.ContainersizeHc).HasColumnName("ContainersizeHC");
            entity.Property(e => e.Incoterm).HasColumnName("INCOTERM");
            entity.Property(e => e.Thctb).HasColumnName("THCTb");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasIndex(e => e.AttachmentId, "IX_Messages_AttachmentId");

            entity.HasOne(d => d.Attachment).WithMany(p => p.Messages).HasForeignKey(d => d.AttachmentId);
        });

        modelBuilder.Entity<MessageConversation>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_MessageConversations_ConversationId");

            entity.HasIndex(e => e.MessageId, "IX_MessageConversations_MessageId");

            entity.HasOne(d => d.Order).WithMany(p => p.MessageConversations).HasForeignKey(d => d.OrderId);

            entity.HasOne(d => d.Message).WithMany(p => p.MessageConversations).HasForeignKey(d => d.MessageId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CsId, "IX_Orders_CSId");

            entity.HasIndex(e => e.ChecklistId, "IX_Orders_ChecklistId");

            entity.HasIndex(e => e.TlId, "IX_Orders_TLId");

            entity.HasIndex(e => e.PpId, "IX_Orders_PPId");

            entity.Property(e => e.CsId).HasColumnName("CSId");
            entity.Property(e => e.TlId).HasColumnName("TLId");
            entity.Property(e => e.PpId).HasColumnName("PpId");

            entity.HasOne(d => d.Checklist).WithMany(p => p.Orders).HasForeignKey(d => d.ChecklistId);

            entity.HasOne(d => d.Cs).WithMany(p => p.Orders).HasForeignKey(d => d.CsId);
            entity.HasOne(d => d.ProductionPlanning).WithMany(p => p.Orders).HasForeignKey(d => d.PpId);
            entity.HasOne(d => d.Tl).WithMany(p => p.Orders).HasForeignKey(d => d.TlId);
        });


        modelBuilder.Entity<StepChecklist>(entity =>
        {
            entity.HasIndex(e => e.ChecklistId, "IX_StepChecklists_ChecklistId");

            entity.HasIndex(e => e.StepId, "IX_StepChecklists_StepId");

            entity.HasOne(d => d.Checklist).WithMany(p => p.StepChecklists).HasForeignKey(d => d.ChecklistId);

            entity.HasOne(d => d.Step).WithMany(p => p.StepChecklists).HasForeignKey(d => d.StepId);
        });

        modelBuilder.Entity<Tlinquiry>(entity =>
        {
            entity.ToTable("TLInquiries");

            entity.Property(e => e.DebtCapitalGeneralForerunEur).HasColumnName("DebtCapitalGeneralForerunEUR");
            entity.Property(e => e.DebtCapitalMainDol).HasColumnName("DebtCapitalMainDOL");
            entity.Property(e => e.DebtCapitalTrailingDol).HasColumnName("DebtCapitalTrailingDOL");
            entity.Property(e => e.Eta).HasColumnName("ETA");
            entity.Property(e => e.Ets).HasColumnName("ETS");
            entity.Property(e => e.IsContainerHc).HasColumnName("IsContainerHC");
            entity.Property(e => e.WeightInKg).HasColumnName("WeightInKG");
        });

        modelBuilder.Entity<ProductionPlanning>(entity =>
        {
            entity.ToTable("ProductionPlannings");

            entity.Property(e => e.Id).HasColumnName("Id");

            entity.Property(e => e.ApprovedByPpCs).HasColumnName("ApprovedByPPCS");

            entity.Property(e => e.ApprovedByPpPp).HasColumnName("ApprovedByPPPP");

            entity.Property(e => e.ApprovedByPpCsTime).HasColumnName("ApprovedByPPCSTime");

            entity.Property(e => e.ApprovedByPpPpTime).HasColumnName("ApprovedByPPPPTime");

            entity.HasMany(e => e.Articles)
                  .WithOne()
                  .IsRequired()
                  .HasForeignKey(e => e.ProductionPlanningId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
