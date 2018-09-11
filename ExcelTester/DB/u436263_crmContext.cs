using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExcelTester
{
    public partial class u436263_crmContext : DbContext
    {
        public u436263_crmContext()
        {
        }

        public u436263_crmContext(DbContextOptions<u436263_crmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmountOrder> AmountOrder { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BonusCard> BonusCard { get; set; }
        public virtual DbSet<BonusInMoney> BonusInMoney { get; set; }
        public virtual DbSet<CashCheck> CashCheck { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CityMinCashSum> CityMinCashSum { get; set; }
        public virtual DbSet<CrmClients> CrmClients { get; set; }
        public virtual DbSet<CrmContactClients> CrmContactClients { get; set; }
        public virtual DbSet<CrmDemands> CrmDemands { get; set; }
        public virtual DbSet<CrmDemandType> CrmDemandType { get; set; }
        public virtual DbSet<CrmPhones> CrmPhones { get; set; }
        public virtual DbSet<CrmPieceTypes> CrmPieceTypes { get; set; }
        public virtual DbSet<CrmProduct> CrmProduct { get; set; }
        public virtual DbSet<CrmProductCategory> CrmProductCategory { get; set; }
        public virtual DbSet<CrmProductList> CrmProductList { get; set; }
        public virtual DbSet<CrmProductPrice> CrmProductPrice { get; set; }
        public virtual DbSet<CrmProductType> CrmProductType { get; set; }
        public virtual DbSet<CrmWhereFrom> CrmWhereFrom { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Smsoptions> Smsoptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=u436263.mssql.masterhost.ru;Database=u436263_crm;User ID=u436263;Password=hessing2op;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmountOrder>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SummOrder).HasColumnName("Summ_Order");
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<BonusCard>(entity =>
            {
                entity.HasKey(e => e.IdBonusCard);

                entity.Property(e => e.IdBonusCard).HasColumnName("id_bonusCard");

                entity.Property(e => e.BonusCount).HasColumnName("Bonus_Count");

                entity.Property(e => e.IdClients).HasColumnName("id_Clients");

                entity.Property(e => e.NumberCard).HasMaxLength(30);

                entity.HasOne(d => d.IdClientsNavigation)
                    .WithMany(p => p.BonusCardNavigation)
                    .HasForeignKey(d => d.IdClients)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BonusCard_CRM_Clients");
            });

            modelBuilder.Entity<BonusInMoney>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MinSum).HasColumnName("minSum");

                entity.Property(e => e.Percent).HasColumnName("Percent_");
            });

            modelBuilder.Entity<CashCheck>(entity =>
            {
                entity.HasKey(e => e.IdChek);

                entity.ToTable("Cash_check");

                entity.Property(e => e.IdChek).HasColumnName("id_chek");

                entity.Property(e => e.BonusMinus).HasColumnName("bonusMinus");

                entity.Property(e => e.BonusPlus).HasColumnName("bonusPlus");

                entity.Property(e => e.CostInPrice).HasColumnName("costInPrice");

                entity.Property(e => e.Delivery).HasColumnName("delivery");

                entity.Property(e => e.IdDemands).HasColumnName("id_demands");

                entity.Property(e => e.Sum).HasColumnName("sum");

                entity.HasOne(d => d.IdDemandsNavigation)
                    .WithMany(p => p.CashCheck)
                    .HasForeignKey(d => d.IdDemands)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cash_check_CRM_Demands");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity);

                entity.Property(e => e.IdCity).HasColumnName("id_city");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("city_name");

                entity.Property(e => e.Cost).HasColumnName("cost");
            });

            modelBuilder.Entity<CityMinCashSum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<CrmClients>(entity =>
            {
                entity.ToTable("CRM_Clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateBirdth).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MidName).HasMaxLength(50);
            });

            modelBuilder.Entity<CrmContactClients>(entity =>
            {
                entity.ToTable("CRM_ContactClients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio).HasColumnName("FIO");

                entity.Property(e => e.IdClients).HasColumnName("id_Clients");

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.HasOne(d => d.IdClientsNavigation)
                    .WithMany(p => p.CrmContactClients)
                    .HasForeignKey(d => d.IdClients)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_ContactClients_CRM_Clients");
            });

            modelBuilder.Entity<CrmDemands>(entity =>
            {
                entity.ToTable("CRM_Demands");

                entity.HasIndex(e => e.ClientId)
                    .HasName("IX_FK_CRM_Demands_CRM_Clients");

                entity.HasIndex(e => e.Type)
                    .HasName("IX_FK_CRM_Demands_CRM_DemandType");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_FK_CRM_Demands_AspNetUsers");

                entity.HasIndex(e => e.Wherefrom)
                    .HasName("IX_FK_CRM_Demands_CRM_WhereFrom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Fio)
                    .HasColumnName("FIO")
                    .HasMaxLength(50);

                entity.Property(e => e.IdPayMet).HasColumnName("id_PayMet");

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CrmDemands)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_CRM_Demands_CRM_Clients");

                entity.HasOne(d => d.IdPayMetNavigation)
                    .WithMany(p => p.CrmDemands)
                    .HasForeignKey(d => d.IdPayMet)
                    .HasConstraintName("FK_CRM_Demands_PaymentMethod");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.CrmDemands)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_CRM_Demands_CRM_DemandType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CrmDemands)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CRM_Demands_AspNetUsers");

                entity.HasOne(d => d.WherefromNavigation)
                    .WithMany(p => p.CrmDemands)
                    .HasForeignKey(d => d.Wherefrom)
                    .HasConstraintName("FK_CRM_Demands_CRM_WhereFrom");
            });

            modelBuilder.Entity<CrmDemandType>(entity =>
            {
                entity.ToTable("CRM_DemandType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CrmPhones>(entity =>
            {
                entity.ToTable("CRM_Phones");

                entity.HasIndex(e => e.ClientId)
                    .HasName("IX_FK_CRM_Phones_CRM_Clients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CrmPhones)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_Phones_CRM_Clients");
            });

            modelBuilder.Entity<CrmPieceTypes>(entity =>
            {
                entity.ToTable("CRM_PieceTypes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CrmProduct>(entity =>
            {
                entity.ToTable("CRM_Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CrmProductCategory>(entity =>
            {
                entity.ToTable("CRM_ProductCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CrmProductList>(entity =>
            {
                entity.ToTable("CRM_ProductList");

                entity.HasIndex(e => e.Demand)
                    .HasName("IX_FK_CRM_ProductList_CRM_Demands");

                entity.HasIndex(e => e.Product)
                    .HasName("IX_FK_CRM_ProductList_CRM_Product");

                entity.HasIndex(e => e.Type)
                    .HasName("IX_FK_CRM_ProductList_CRM_ProductType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.DemandNavigation)
                    .WithMany(p => p.CrmProductList)
                    .HasForeignKey(d => d.Demand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_ProductList_CRM_Demands");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.CrmProductList)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_ProductList_CRM_Product");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.CrmProductList)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_CRM_ProductList_CRM_ProductType");
            });

            modelBuilder.Entity<CrmProductPrice>(entity =>
            {
                entity.ToTable("CRM_ProductPrice");

                entity.HasIndex(e => e.Category)
                    .HasName("IX_FK_CRM_ProductPrice_CRM_ProductCategory");

                entity.HasIndex(e => e.PieceType)
                    .HasName("IX_FK_CRM_ProductPrice_CRM_PieceTypes");

                entity.HasIndex(e => e.Product)
                    .HasName("IX_FK_CRM_ProductPrice_CRM_Product");

                entity.HasIndex(e => e.Type)
                    .HasName("IX_FK_CRM_ProductPrice_CRM_ProductType");

                entity.HasIndex(e => e.WeightType)
                    .HasName("IX_FK_CRM_ProductPrice_CRM_PieceTypes1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsAweightedProduct).HasColumnName("isAWeightedProduct");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.CrmProductPrice)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_ProductPrice_CRM_ProductCategory");

                entity.HasOne(d => d.PieceTypeNavigation)
                    .WithMany(p => p.CrmProductPrice)
                    .HasForeignKey(d => d.PieceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_ProductPrice_CRM_PieceTypes");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.CrmProductPrice)
                    .HasForeignKey(d => d.Product)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CRM_ProductPrice_CRM_Product");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.CrmProductPrice)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_CRM_ProductPrice_CRM_ProductType");
            });

            modelBuilder.Entity<CrmProductType>(entity =>
            {
                entity.ToTable("CRM_ProductType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CrmWhereFrom>(entity =>
            {
                entity.ToTable("CRM_WhereFrom");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.IdPayMethod);

                entity.Property(e => e.IdPayMethod).HasColumnName("id_PayMethod");

                entity.Property(e => e.PayMethod)
                    .IsRequired()
                    .HasColumnName("payMethod");
            });

            modelBuilder.Entity<Smsoptions>(entity =>
            {
                entity.ToTable("SMSOptions");

                entity.Property(e => e.TextTemplate).IsRequired();
            });
        }
    }
}
