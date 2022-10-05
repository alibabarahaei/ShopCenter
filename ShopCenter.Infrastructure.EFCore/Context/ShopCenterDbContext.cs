using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopCenter.Domain.Models.Site;
using ShopCenter.Domain.Models.User;
using ShopCenter.Domain.Models.Products;
using ShopCenter.Domain.Models.Store;
using ShopCenter.Domain.Models.Contacts;

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
        #region contacts

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }

        #endregion
        #region store

        public DbSet<Seller> Sellers { get; set; }

        #endregion
        #region products

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductColor> ProductColors { get; set; }

        public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }

        #endregion
        #region on model creating




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {






            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
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

        #endregion

    }
}
