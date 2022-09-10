using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopCenter.Domain.Models;
using ShopCenter.Domain.Models.Site;

namespace ShopCenter.Infrastructure.EFCore.Context
{
    public class ShopCenterDbContext : IdentityDbContext<ApplicationUser>
    {

        public ShopCenterDbContext(DbContextOptions<ShopCenterDbContext> options) : base(options)
        {

        }

        #region site
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Banner> Banners { get; set; }
        #endregion



















        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {






            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }


            base.OnModelCreating(modelBuilder);



            #region ChangeTableName(Identity)
            modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            #endregion


        }



    }
}
