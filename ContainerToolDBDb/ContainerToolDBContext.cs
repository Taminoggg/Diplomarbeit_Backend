using System;
using System.Collections.Generic;
using ContainerToolDB;
using Microsoft.EntityFrameworkCore;

namespace ContainerToolDBDb;

public partial class ContainerToolDBContext : DbContext
{
    public ContainerToolDBContext()
    {
    }

    public ContainerToolDBContext(DbContextOptions<ContainerToolDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticlesInDispatchRequest> ArticlesInDispatchRequests { get; set; }

    public virtual DbSet<Checklist> Checklists { get; set; }

    public virtual DbSet<Csinquiry> Csinquiries { get; set; }

    public virtual DbSet<DispachDateRequest> DispachDateRequests { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<MessageConversation> MessageConversations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<PlanningSt> PlanningSts { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    public virtual DbSet<StepChecklist> StepChecklists { get; set; }

    public virtual DbSet<Stsarticle> Stsarticles { get; set; }

    public virtual DbSet<Tlinquiry> Tlinquiries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticlesInDispatchRequest>(entity =>
        {
            entity.HasIndex(e => e.DispachDateRequestId, "IX_ArticlesInDispatchRequests_DispachDateRequestId");

            entity.HasOne(d => d.DispachDateRequest).WithMany(p => p.ArticlesInDispatchRequests).HasForeignKey(d => d.DispachDateRequestId);
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasIndex(e => e.CsinquiryId, "IX_Conversations_OrderId");

            entity.HasOne(d => d.Csinquiry).WithMany(p => p.Articles).HasForeignKey(d => d.CsinquiryId);
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
            entity.HasIndex(e => e.Csid, "IX_Orders_CSId");

            entity.HasIndex(e => e.ChecklistId, "IX_Orders_ChecklistId");

            entity.HasIndex(e => e.Tlid, "IX_Orders_TLId");

            entity.Property(e => e.Csid).HasColumnName("CSId");
            entity.Property(e => e.Tlid).HasColumnName("TLId");

            entity.HasOne(d => d.Checklist).WithMany(p => p.Orders).HasForeignKey(d => d.ChecklistId);

            entity.HasOne(d => d.Cs).WithMany(p => p.Orders).HasForeignKey(d => d.Csid);

            entity.HasOne(d => d.Tl).WithMany(p => p.Orders).HasForeignKey(d => d.Tlid);
        });

        modelBuilder.Entity<PlanningSt>(entity =>
        {
            entity.ToTable("PlanningSTS");
        });

        modelBuilder.Entity<StepChecklist>(entity =>
        {
            entity.HasIndex(e => e.ChecklistId, "IX_StepChecklists_ChecklistId");

            entity.HasIndex(e => e.StepId, "IX_StepChecklists_StepId");

            entity.HasOne(d => d.Checklist).WithMany(p => p.StepChecklists).HasForeignKey(d => d.ChecklistId);

            entity.HasOne(d => d.Step).WithMany(p => p.StepChecklists).HasForeignKey(d => d.StepId);
        });

        modelBuilder.Entity<Stsarticle>(entity =>
        {
            entity.ToTable("STSArticles");

            entity.HasIndex(e => e.PlantId, "IX_STSArticles_PlantId");

            entity.HasOne(d => d.Plant).WithMany(p => p.Stsarticles).HasForeignKey(d => d.PlantId);
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
