using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViolaApi.DLL
{
    public class ViolaDbContext: DbContext
    {
        public ViolaDbContext(DbContextOptions<ViolaDbContext> options) : base(options)
        {
            
        }
        public DbSet<ViolaUser> ViolaUser { get; set; }
        public DbSet<SocialNetworks> SocialNetworks { get; set; }
        public DbSet<ApiAssets> ApiAssets { get; set; }
        public DbSet<ViolaRoles> ViolaRoles { get; set; }
        public DbSet<ViolaUserLogin> ViolaUserLogins { get; set; }
        public DbSet<ViolaUserRoles> ViolaUserRoles { get; set; }
        public DbSet<ViolaUserClaims> ViolaUserClaims { get; set; }
        public DbSet<ViolaRoleClaims> ViolaRoleClaims { get; set; }

        //Override EntityFramework pattern for creating Role, Login and Claims tables
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            

        //    builder.Entity<ViolaRoles>().HasKey(e => e.Id);
        //    builder.Entity<ViolaUserClaims>().HasKey(e => e.Id);
        //    builder.Entity<ViolaUserLogin>().HasKey(e => e.ProviderKey);
        //    builder.Entity<ViolaUserRoles>().HasKey(e => e.RoleId);
        //    builder.Entity<ViolaRoleClaims>().HasKey(e => e.Id);

        //    builder.Entity<ViolaUser>()
        //        .HasMany(e => e.ViolaRoleClaims)
        //        .WithOne()
        //        .HasForeignKey(e => e.Id)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ViolaUser>()
        //        .HasMany(e => e.ViolaUserClaims)
        //        .WithOne()
        //        .HasForeignKey(e => e.UserId)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ViolaUser>()
        //        .HasMany(e => e.ViolaRoles)
        //        .WithOne()
        //        .HasForeignKey(e => e.Id)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ViolaUser>()
        //        .HasMany(e => e.ViolaUserLogin)
        //        .WithOne()
        //        .HasForeignKey(e => e.UserId)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<ViolaUser>()
        //        .HasMany(e => e.ViolaUserRoles)
        //        .WithOne()
        //        .HasForeignKey(e => e.UserId)
        //        .IsRequired()
        //        .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
