using EcoMoveAPI.BlogManagment.Application.Internal.CommandServices;
using EcoMoveAPI.BlogManagment.Application.Internal.QueryServices;
using EcoMoveAPI.BlogManagment.Domain.Repositories;
using EcoMoveAPI.BlogManagment.Domain.Services;
using EcoMoveAPI.BlogManagment.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.BookingReservation.Application.Internal.CommandServices;
using EcoMoveAPI.BookingReservation.Application.Internal.OutboundServices.ACL;
using EcoMoveAPI.BookingReservation.Application.Internal.QueryServices;
using EcoMoveAPI.BookingReservation.Domain.Repositories;
using EcoMoveAPI.BookingReservation.Domain.Services;
using EcoMoveAPI.BookingReservation.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.CustomerSupport.Application.Internal.CommandServices;
using EcoMoveAPI.CustomerSupport.Application.Internal.QueryServices;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.CustomerSupport.Domain.Services;
using EcoMoveAPI.CustomerSupport.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.Payment.Application.Internal.CommandServices;
using EcoMoveAPI.Payment.Application.Internal.QueryServices;
using EcoMoveAPI.Payment.Domain.Repositories;
using EcoMoveAPI.Payment.Domain.Services;
using EcoMoveAPI.Payment.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.Shared.Application.Internal.OutboundServices;
using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.Shared.Interfaces.ASP.Configuration;
using EcoMoveAPI.UserManagement.Application.Internal.CommandServices;
using EcoMoveAPI.UserManagement.Application.Internal.OutboundServices;
using EcoMoveAPI.UserManagement.Application.Internal.QueryServices;
using EcoMoveAPI.UserManagement.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Services;
using EcoMoveAPI.UserManagement.Infrastructure.Hashing.BCrypt.Services;
using EcoMoveAPI.UserManagement.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.UserManagement.Infrastructure.Pipeline.Middleware.Extensions;
using EcoMoveAPI.UserManagement.Infrastructure.Tokens.JWT.Configuration;
using EcoMoveAPI.UserManagement.Infrastructure.Tokens.JWT.Services;
using EcoMoveAPI.UserManagement.Interfaces.ACL;
using EcoMoveAPI.UserManagement.Interfaces.ACL.Services;
using EcoMoveAPI.VehicleManagement.Application.Internal.CommandServices;
using EcoMoveAPI.VehicleManagement.Application.Internal.QueryServices;
using EcoMoveAPI.VehicleManagement.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Services;
using EcoMoveAPI.VehicleManagement.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.VehicleManagement.Interfaces.ACL;
using EcoMoveAPI.VehicleManagement.Interfaces.ACL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("AzureConnection");

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "EcomoveWebService.API",
                Version = "v1",
                Description = "Ecomove Web Service API",
                TermsOfService = new Uri("https://ecomove.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Ecomove",
                    Email = "ecomove@gmail.com"
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ExternalUserService>();
builder.Services.AddScoped<IUserManagementContextFacade, UserManagementContextFacade>();

builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
builder.Services.AddScoped<IMembershipCommandService, MembershipCommandService>();
builder.Services.AddScoped<IMembershipQueryService, MembershipQueryService>();

builder.Services.AddScoped<IMembershipCategoryRepository, MembershipCategoryRepository>();
builder.Services.AddScoped<IMembershipCategoryCommandService, MembershipCategoryCommandService>();
builder.Services.AddScoped<IMembershipCategoryQueryService, MembershipCategoryQueryService>();

// VehicleManagement Bounded Context Injection Configuration

builder.Services.AddScoped<IEcoVehicleRepository, EcoVehicleRepository>();
builder.Services.AddScoped<IEcoVehicleCommandService, EcoVehicleCommandService>();
builder.Services.AddScoped<IEcoVehicleQueryService, EcoVehicleQueryService>();

builder.Services.AddScoped<IEcoVehicleTypeRepository, EcoVehicleTypeRepository>();
builder.Services.AddScoped<IEcoVehicleTypeCommandService, EcoVehicleTypeCommandService>();
builder.Services.AddScoped<IEcoVehicleTypeQueryService, EcoVehicleTypeQueryService>();
builder.Services.AddScoped<ExternalEcoVehicleService>();
builder.Services.AddScoped<IVehicleManagementContextFacade, VehicleManagementContextFacade>();

// BookingReservation Bounded Context Injection Configuration

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingCommandService, BookingCommandService>();
builder.Services.AddScoped<IBookingQueryService, BookingQueryService>();

// CustomerSupport Bounded Context Injection Configuration

builder.Services.AddScoped<ICustomerSupportAgentRepository, CustomerSupportAgentRepository>();
builder.Services.AddScoped<ICustomerSupportAgentCommandService, CustomerSupportAgentCommandService>();
builder.Services.AddScoped<ICustomerSupportAgentQueryService, CustomerSupportAgentQueryService>();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketCommandService, TicketCommandService>();
builder.Services.AddScoped<ITicketQueryService, TicketQueryService>();

builder.Services.AddScoped<ITicketCategoryRepository, TicketCategoryRepository>();
builder.Services.AddScoped<ITicketCategoryCommandService, TicketCategoryCommandService>();
builder.Services.AddScoped<ITicketCategoryQueryService, TicketCategoryQueryService>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionCommandService, TransactionCommandService>();
builder.Services.AddScoped<ITransactionQueryService, TransactionQueryService>();

builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogCommandService, BlogCommandService>();
builder.Services.AddScoped<IBlogQueryService, BlogQueryService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();