using EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;
using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;
using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Entities;
using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // UserManagement Context

        builder.Entity<User>().HasKey(u => u.UserId);
        builder.Entity<User>().Property(u => u.UserId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().OwnsOne(u => u.Name, n =>
        {
            n.WithOwner().HasForeignKey("UserId");
            n.Property(p => p.FirstName).HasColumnName("FirstName");
            n.Property(p => p.LastName).HasColumnName("LastName");
        });
        builder.Entity<User>().OwnsOne(u => u.Email, e =>
        {
            e.WithOwner().HasForeignKey("UserId");
            e.Property(p => p.Address).HasColumnName("Email");
        });
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<User>()
            .HasMany(u => u.Bookings)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .HasPrincipalKey(u => u.UserId);

        builder.Entity<User>()
            .HasMany(u => u.Memberships)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId)
            .HasPrincipalKey(u => u.UserId);

        builder.Entity<User>()
            .HasMany(u => u.Tickets)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .HasPrincipalKey(u => u.UserId);
        builder.Entity<User>()
            .HasMany(u => u.Transactions)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .HasPrincipalKey(u => u.UserId);

        builder.Entity<Membership>().HasKey(m => m.MembershipId);
        builder.Entity<Membership>().Property(m => m.MembershipId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Membership>().Property(m => m.UserId).IsRequired();
        builder.Entity<Membership>().Property(m => m.MembershipCategoryId).IsRequired();
        builder.Entity<Membership>().Property(m => m.EndDate).IsRequired();

        builder.Entity<MembershipCategory>().HasKey(mc => mc.MembershipCategoryId);
        builder.Entity<MembershipCategory>().Property(mc => mc.MembershipCategoryId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MembershipCategory>().Property(mc => mc.Name).IsRequired();
        builder.Entity<MembershipCategory>()
            .HasMany(mc => mc.Memberships)
            .WithOne(m => m.MembershipCategory)
            .HasForeignKey(m => m.MembershipCategoryId)
            .HasPrincipalKey(mc => mc.MembershipCategoryId);

        // VehicleManagement Context

        builder.Entity<EcoVehicle>().HasKey(v => v.EcoVehicleId);
        builder.Entity<EcoVehicle>().Property(v => v.EcoVehicleId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EcoVehicle>().Property(v => v.Model).IsRequired();
        builder.Entity<EcoVehicle>().Property(v => v.EcoVehicleId).IsRequired();
        builder.Entity<EcoVehicle>().Property(v => v.BatteryLevel).IsRequired();
        builder.Entity<EcoVehicle>().Property(v => v.UserId).IsRequired();
        builder.Entity<EcoVehicle>().Property(v => v.EcoVehicleName).IsRequired();
        builder.Entity<EcoVehicle>().OwnsOne(v => v.Location, l =>
        {
            l.WithOwner().HasForeignKey("EcoVehicleId");
            l.Property(p => p.Latitude).HasColumnName("Latitude");
            l.Property(p => p.Longitude).HasColumnName("Longitude");
        });
        builder.Entity<EcoVehicle>().Property(v => v.Status).IsRequired();
        builder.Entity<EcoVehicle>().Property(v => v.ImageUrl).IsRequired();
        builder.Entity<EcoVehicle>()
            .HasMany(v => v.Bookings)
            .WithOne(b => b.EcoVehicle)
            .HasForeignKey(b => b.VehicleId)
            .HasPrincipalKey(v => v.EcoVehicleId);

        builder.Entity<EcoVehicleType>().HasKey(et => et.EcoVehicleTypeId);
        builder.Entity<EcoVehicleType>().Property(et => et.EcoVehicleTypeId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<EcoVehicleType>().Property(et => et.Name).IsRequired();
        builder.Entity<EcoVehicleType>()
            .HasMany(et => et.EcoVehicles)
            .WithOne(v => v.EcoVehicleType)
            .HasForeignKey(v => v.EcoVehicleTypeId)
            .HasPrincipalKey(et => et.EcoVehicleTypeId);

        // BookingReservation Context

        builder.Entity<Booking>().HasKey(b => b.BookingId);
        builder.Entity<Booking>().Property(b => b.BookingId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Booking>().Property(b => b.UserId).IsRequired();
        builder.Entity<Booking>().Property(b => b.VehicleId).IsRequired();
        builder.Entity<Booking>().Property(b => b.StartTime).IsRequired();
        builder.Entity<Booking>().Property(b => b.EndTime).IsRequired();
        builder.Entity<Booking>().Property(b => b.Status).IsRequired();
        
        // BlogManagement Context
        
        builder.Entity<Blog>().HasKey(b => b.BlogId);
        builder.Entity<Blog>().Property(b => b.BlogId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Blog>().Property(b => b.Title).IsRequired();
        builder.Entity<Blog>().Property(b => b.Description).IsRequired();
        builder.Entity<Blog>().Property(b => b.UserId).IsRequired();

        // CustomerSupport Context

        builder.Entity<CustomerSupportAgent>().HasKey(c => c.CustomerSupportAgentId);
        builder.Entity<CustomerSupportAgent>().Property(c => c.CustomerSupportAgentId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<CustomerSupportAgent>().OwnsOne(c => c.Name, n =>
        {
            n.WithOwner().HasForeignKey("CustomerSupportAgentId");
            n.Property(p => p.FirstName).HasColumnName("FirstName");
            n.Property(p => p.LastName).HasColumnName("LastName");
        });
        builder.Entity<CustomerSupportAgent>().OwnsOne(c => c.Email, e =>
        {
            e.WithOwner().HasForeignKey("CustomerSupportAgentId");
            e.Property(p => p.Address).HasColumnName("Email");
        });
        builder.Entity<CustomerSupportAgent>()
            .HasMany(c => c.Tickets)
            .WithOne(t => t.CustomerSupportAgent)
            .HasForeignKey(t => t.CustomerSupportAgentId)
            .HasPrincipalKey(c => c.CustomerSupportAgentId);

        builder.Entity<Ticket>().HasKey(t => t.TicketId);
        builder.Entity<Ticket>().Property(t => t.TicketId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Ticket>().Property(t => t.UserId).IsRequired();
        builder.Entity<Ticket>().Property(t => t.CustomerSupportAgentId).IsRequired();
        builder.Entity<Ticket>().Property(t => t.Title).IsRequired();
        builder.Entity<Ticket>().Property(t => t.Description).IsRequired();
        builder.Entity<Ticket>().Property(t => t.Status).IsRequired();

        builder.Entity<TicketCategory>().HasKey(tc => tc.TicketCategoryId);
        builder.Entity<TicketCategory>().Property(tc => tc.TicketCategoryId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TicketCategory>().Property(tc => tc.Name).IsRequired();
        builder.Entity<TicketCategory>()
            .HasMany(tc => tc.Tickets)
            .WithOne(t => t.TicketCategory)
            .HasForeignKey(t => t.TicketCategoryId)
            .HasPrincipalKey(tc => tc.TicketCategoryId);

        builder.Entity<Transaction>().HasKey(t => t.TransactionId);
        builder.Entity<Transaction>().Property(t => t.TransactionId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Transaction>().Property(t => t.UserId).IsRequired();
        builder.Entity<Transaction>().Property(t => t.Amount).IsRequired();

        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}