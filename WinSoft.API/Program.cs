using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WinSoft.Core.Data;
using WinSoft.Core.Domain.Entitites.Documents;
using WinSoft.Core.Infrastructure.Extensions;
using WinSoft.Core.Infrastructure.Services;
using WinSoft.Core.Infrastructure.Services.Abstractions;
using WinSoft.Core.Presentation.DTOProfiles;

namespace WinSoft.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var jwtConfiguration = builder.Configuration.GetJwtConfiguration();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o => o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtConfiguration.Audience,

                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = jwtConfiguration.SymmetricSecurityKey,
                });

            builder.Services.AddDbContext<ApplicationContext>(ServiceLifetime.Transient);
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
            builder.Services.AddSingleton<IDocumentDirectoryService, DocumentDirectoryService>();
            builder.Services.AddSingleton<IDocumentPackageService, DocumentPackageService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                var applicationContext = app.Services.GetRequiredService<ApplicationContext>();

                var administrator = applicationContext.Users.Add(new Core.Domain.Entitites.User
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@admin.com",
                    Password = "admin".MD5Hash(),
                    Role = Core.Domain.Entitites.Enums.UserRole.Administrator,
                    OwnedDocumentDirectory = new List<DocumentDirectory>()
                    {
                        new DocumentDirectory() {}
                    }
                }).Entity;

                var user = applicationContext.Users.Add(new Core.Domain.Entitites.User 
                { 
                    Id = Guid.NewGuid(),
                    Email = "user@user.com", 
                    Password = "user".MD5Hash(), 
                    Role = Core.Domain.Entitites.Enums.UserRole.User,
                    DocumentsPackages = new List<DocumentsPackage>
                    {
                        new DocumentsPackage
                        {
                            Directory = administrator.OwnedDocumentDirectory.First(),
                            Passport = new Core.Domain.Entitites.Documents.DocumentTypes.Passport
                            {
                                FullName = "Степан Андрійович Бандера",
                                Birthdate = new DateTime(1909, 1, 1),
                                DateOfIssue = new DateTime(1923, 1, 29),
                                Series = 000000,
                                RecordNumber = 000001,
                                Authority = 01
                            },
                            CreditCard = new Core.Domain.Entitites.Documents.DocumentTypes.CreditCard
                            {
                                CardNumber = "0000 0000 0000 0001",
                                OwnerName = "Stepan Andriyovych Bandera",
                                ExpiredAt = new DateTime(2024, 5, 5)
                            },
                            DrivingLicence = new Core.Domain.Entitites.Documents.DocumentTypes.DrivingLicence
                            {
                                FullName = "Степан Андрійович Бандера",
                                CarClass = "B",
                                DateOfIssue = new DateTime(2009, 4, 4),
                                ExpiredAt = new DateTime(2029, 4, 4)

                            }
                        }
                    }
                }).Entity;

                applicationContext.SaveChanges();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}