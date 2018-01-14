using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SWOF.Core.Models;
using System;
using System.Linq;

namespace SWOF.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BauDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BauDbContext>>()))
            {
                // Apply the Initial migration to create the database
                context.Database.Migrate();

                if (context.Engineer.Any())
                {
                    return;
                }

                context.Engineer.AddRange(
                    new Engineer { Name = "Vinay" },
                    new Engineer { Name = "Jitender" },
                    new Engineer { Name = "Shivam" },
                    new Engineer { Name = "Parvez" },
                    new Engineer { Name = "Pankaj" },
                    new Engineer { Name = "Subodh" },
                    new Engineer { Name = "Peeyush" },
                    new Engineer { Name = "Harsh" },
                    new Engineer { Name = "Tanvi" },
                    new Engineer { Name = "Harry" }
                    );
                context.SaveChanges();
            }
        }
    }
}
