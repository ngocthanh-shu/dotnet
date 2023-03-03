using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.Framework
{
    public partial class EShoperDbContext : DbContext
    {
        public EShoperDbContext()
            : base("name=EShoperDbContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<blog> blogs { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<Checkout> Checkouts { get; set; }
        public virtual DbSet<menu> menus { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<slide> slides { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Profiles)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Checkout>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.phonenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Profile>()
                .Property(e => e.postalcode)
                .IsUnicode(false);

            modelBuilder.Entity<slide>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
