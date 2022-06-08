using DVD.Web.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DVD.Web.DbConnection
{
    public class DVDContext : DbContext
    {
        public DVDContext(DbContextOptions<DVDContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
            {
                b.Property(e => e.UserNumber).UseIdentityColumn();
            });
            modelBuilder.Entity<Actor>(b =>
            {
                b.Property(e => e.ActorNumber).UseIdentityColumn();
            });
            modelBuilder.Entity<DVDCategory>(b =>
            {
                b.Property(e => e.CategoryNumber).UseIdentityColumn();
            });
            modelBuilder.Entity<MembershipCategory>(b =>
            {
                b.Property(e => e.MembershipCategoryNumber).UseIdentityColumn();
            });
            modelBuilder.Entity<Studio>(b =>
            {
                b.Property(e => e.StudioNumber).UseIdentityColumn();
            });
            modelBuilder.Entity<Producer>(b =>
            {
                b.Property(e => e.ProducerNumber).UseIdentityColumn();
            });
            modelBuilder.Entity<LoanTypes>(b =>
            {
                b.Property(e => e.LoanTypeNumber).UseIdentityColumn();
            });
            modelBuilder.Entity<CastMember>(b =>
            {
                b.HasNoKey();
                b.HasOne<DVDTitle>().WithMany().HasForeignKey(e => e.DVDNumber);
                b.HasOne<Actor>().WithMany().HasForeignKey(e => e.ActorNumber);
            });
            modelBuilder.Entity<DVDTitle>(b =>
            {
                b.Property(e => e.DVDNumber).UseIdentityColumn();
                b.HasOne<Producer>().WithMany().HasForeignKey(e => e.ProducerNumber);
                b.HasOne<DVDCategory>().WithMany().HasForeignKey(e => e.CategoryNumber);
                b.HasOne<Studio>().WithMany().HasForeignKey(e => e.StudioNumber);
            });
            modelBuilder.Entity<DVDCopy>(b =>
            {
                b.Property(e => e.CopyNumber).UseIdentityColumn();
                b.HasOne<DVDTitle>().WithMany().HasForeignKey(e => e.DVDNumber);
            });
            modelBuilder.Entity<Loan>(b =>
            {
                b.Property(e => e.LoanNumber).UseIdentityColumn();
                b.HasOne<LoanTypes>().WithMany().HasForeignKey(e => e.LoanTypeNumber);
                b.HasOne<DVDCopy>().WithMany().HasForeignKey(e => e.CopyNumber);
                b.HasOne<Member>().WithMany().HasForeignKey(e => e.MemberNumber);
            });
            modelBuilder.Entity<Member>(b =>
            {
                b.Property(e => e.MemberNumber).UseIdentityColumn();
                b.HasOne<MembershipCategory>().WithMany().HasForeignKey(e => e.MembershipCategoryNumber);
            });
        }
        public DbSet<User> User { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<DVDCategory> DVDCategory { get; set; }
        public DbSet<MembershipCategory> MembershipCategory { get; set; }
        public DbSet<Studio> Studio { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<LoanTypes> LoanType { get; set; }
        public DbSet<CastMember> CastMember { get; set; }
        public DbSet<DVDTitle> DVDTitle { get; set; }
        public DbSet<DVDCopy> DVDCopy { get; set; }
        public DbSet<Loan> Loan{ get; set; }
        public DbSet<Member> Member { get; set; }
    }
}
