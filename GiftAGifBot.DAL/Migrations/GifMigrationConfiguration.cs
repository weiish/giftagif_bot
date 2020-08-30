using GiftAGifBot.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftAGifBot.DAL
{
    internal sealed class GifMigrationConfiguration : DbMigrationsConfiguration<GifContext>
    {
        public GifMigrationConfiguration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GifContext context) {
            SeedRoles(context);
            SeedUserAccounts(context);
            RunInitializationScripts(context);
            base.Seed(context);
        }

        private void RunInitializationScripts(GifContext context) {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, System.AppDomain.CurrentDomain.RelativeSearchPath ?? "");
            List<string> sqlFiles = Directory.GetFiles(path + "\\Initialize DB Scripts\\", "*.sql").OrderBy(o => o).ToList();
            foreach (string file in sqlFiles) {
                string query = File.ReadAllText(file);
                if (!string.IsNullOrEmpty(query)) {
                    context.Database.ExecuteSqlCommand(File.ReadAllText(file));
                }
            }
        }
        private void SeedUserAccounts(GifContext context) {
            User Manager = new User() {
                Id = Guid.Parse("D3AF975F-E57C-40D3-05C6-08D847CF3A88"),
                Username = "Manager",
                Usertag = "-1",
                DiscordId = "-1",
                Points = -1,
                UserRoles = new List<UserRole>() { new UserRole { RoleId = Guid.Parse("5fbace51-a3ad-40fe-aeb7-05494dde094a") } }
            };


            context.Users.AddOrUpdate(Manager);
        }

        private void SeedRoles(GifContext context) {
            Role Superuser = new Role() {
                Id = Guid.Parse("5fbace51-a3ad-40fe-aeb7-05494dde094a"),
                Name = "Superuser"                                
            };
            Role Moderator = new Role() {
                Name = "Moderator"
            };
            Role Banned = new Role() {
                Name = "Banned"
            };

            context.Roles.AddOrUpdate(Superuser);
            context.Roles.AddOrUpdate(Moderator);
            context.Roles.AddOrUpdate(Banned);
        }
    }
}
