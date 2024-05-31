using Microsoft.EntityFrameworkCore;
using RentACarProject.Entities.Brands;
using RentACarProject.Entities.Cars;
using RentACarProject.Entities.Colors;
using RentACarProject.Entities.Fuels;
using RentACarProject.Entities.Models;
using RentACarProject.Entities.Transmissions;
using RentACarProject.Enums;
using System.ComponentModel;
using System.Reflection.Emit;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace RentACarProject.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class RentACarProjectDbContext :
    AbpDbContext<RentACarProjectDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public RentACarProjectDbContext(DbContextOptions<RentACarProjectDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(RentACarProjectConsts.DbTablePrefix + "YourEntities", RentACarProjectConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Brand>(b =>
        {
            b.ToTable("Brand").HasKey(x => x.Id);
            b.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            b.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            b.HasMany(x => x.Models).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId);
        }
        );

        builder.Entity<Car>(c =>
        {
            c.ToTable("Car").HasKey(x => x.Id);
            c.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            c.Property(x => x.ModelId).HasColumnName("ModelId").IsRequired();
            c.Property(x => x.ColorId).HasColumnName("ColorId").IsRequired();
            c.Property(x => x.ModelYear).HasColumnName("ModelYear").IsRequired();
            c.Property(x => x.Plate).HasColumnName("Plate").HasMaxLength(10).IsRequired();
            c.Property(x => x.CarState).HasColumnName("State").IsRequired();


            c.HasOne(x => x.Model).WithMany(x => x.Cars).HasForeignKey(x => x.ModelId);
            c.HasOne(x => x.Color).WithMany(x => x.Cars).HasForeignKey(x => x.ColorId);
        });

        builder.Entity<Color>(c =>
        {
            c.ToTable("Color").HasKey(x => x.Id);
            c.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            c.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            c.HasMany(x => x.Cars).WithOne(x => x.Color).HasForeignKey(x => x.ColorId);
        });
     
        builder.Entity<Fuel>(f =>
        {
            f.ToTable("Fuel").HasKey(x => x.Id);
            f.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            f.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
 
            f.HasMany(x => x.Models).WithOne(x => x.Fuel).HasForeignKey(x => x.FuelId);
        });
  
        builder.Entity<Model>(m =>
        {
            m.ToTable("Model").HasKey(x => x.Id);
            m.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            m.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            m.Property(x => x.BrandId).HasColumnName("BrandId").IsRequired();
       
            m.HasOne(x => x.Brand).WithMany(x => x.Models).HasForeignKey(x => x.BrandId);
            m.HasMany(x => x.Cars).WithOne(x => x.Model).HasForeignKey(x => x.ModelId);
        });
 
        builder.Entity<Transmission>(t =>
        {
            t.ToTable("Transmission").HasKey(x => x.Id);
            t.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            t.Property(x => x.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();

            t.HasMany(x => x.Models).WithOne(x => x.Transmission).HasForeignKey(x => x.TransmissionId);
        });


        // Seed data
        // Brand
        builder.Entity<Brand>().HasData(
            new Brand(1, "Audi"),
            new Brand(2, "BMW"),
            new Brand(3, "Mercedes"),
            new Brand(4, "Volkswagen"),
            new Brand(5, "Volvo"),
            new Brand(6, "Ford")
        );
        // Color
        builder.Entity<Color>().HasData(
            new Color(1, "Black"),
            new Color(2, "White"),
            new Color(3, "Red"),
            new Color(4, "Blue"),
            new Color(5, "Silver"),
            new Color(6, "Yellow"),
            new Color(7, "Green"),
            new Color(8, "Orange"),
            new Color(9, "Pink"),
            new Color(10, "Purple"),
            new Color(11, "Brown"),
            new Color(12, "Grey"),
            new Color(13, "Maroon"),
            new Color(14, "Navy"),
            new Color(15, "Lime"),
            new Color(16, "Aqua"),
            new Color(17, "Teal"),
            new Color(18, "Olive"),
            new Color(19, "Maroon"),
            new Color(20, "Aquamarine"),
            new Color(21, "Coral"),
            new Color(22, "Crimson"),
            new Color(23, "Cyan"),
            new Color(24, "Fuchsia"),
            new Color(25, "Gold"),
            new Color(26, "Khaki"),
            new Color(27, "Lavender"),
            new Color(28, "Lime"),
            new Color(29, "Magenta"),
            new Color(30, "Navy"),
            new Color(31, "Olive"),
            new Color(32, "Plum"),
            new Color(33, "Salmon"),
            new Color(34, "Silver"),
            new Color(35, "Tan"),
            new Color(36, "Teal"),
            new Color(37, "Violet"),
            new Color(38, "Yellow"),
            new Color(39, "Beige"),
            new Color(40, "Brown"),
            new Color(41, "Cream"),
            new Color(42, "Gold"),
            new Color(43, "Grey"),
            new Color(44, "Ivory"),
            new Color(45, "Mauve"),
            new Color(46, "Ochre"),
            new Color(47, "Puce"),
            new Color(48, "Rust"),
            new Color(49, "Tan"),
            new Color(50, "Teal"));
        // Fuel
        builder.Entity<Fuel>().HasData(
            new Fuel(1, "Petrol"),
            new Fuel(2, "Diesel"),
            new Fuel(3, "Gas"),
            new Fuel(4, "Electric"),
            new Fuel(5, "Hybrid"),
            new Fuel(6, "Other"));
        // Transmission
        builder.Entity<Transmission>().HasData(
            new Transmission(1, "Manual"),
            new Transmission(2, "Automatic"));
        // Model
        builder.Entity<Model>().HasData(
            new Model(1, "A1", 1000, 1, 1, 1, ""),
            new Model(2, "A3", 600, 2, 2, 2, ""),
            new Model(3, "A4", 1000, 1, 3, 3, ""),
            new Model(4, "A5", 750, 2, 4, 4, ""),
            new Model(5, "A6", 500, 1, 5, 5, ""),
            new Model(6, "A7", 2000, 2, 6, 6, "")
            );
        // Car
        builder.Entity<Car>().HasData(
            new Car(1, 1, "60TR60", 2001, 1, CarState.Available),
            new Car(2, 2, "34TR60", 2002, 2, CarState.Rented),
            new Car(3, 3, "45TR60", 2003, 3, CarState.Maintenance),
            new Car(4, 4, "35TR60", 2004, 4, CarState.Available),
            new Car(5, 5, "55TR60", 2005, 5, CarState.Rented),
            new Car(6, 6, "66TR60", 2006, 6, CarState.Maintenance)
            );
    }
}
