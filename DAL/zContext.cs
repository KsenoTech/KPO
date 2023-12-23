using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DomainModel
{
    public partial class zContext : DbContext
    {
        public zContext()
            : base("name=zContext")
        {
        }

        public virtual DbSet<Client> zcontextClient { get; set; }
        public virtual DbSet<Executor> zcontextExecutor { get; set; }
        public virtual DbSet<Feedback> zcontextFeedback { get; set; }
        public virtual DbSet<Order> zcontextOrder { get; set; }
        public virtual DbSet<Type_of_service> zcontextType_of_service { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.client_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Executor>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Executor)
                .HasForeignKey(e => e.executor_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Feedback)
                .HasForeignKey(e => e.feedback_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
