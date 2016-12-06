using DeviceReg.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeviceReg.Common.Data.DeviceRegDB
{

    //public class DeviceRegDBContext : IdentityDbContext<ApplicationUser>
    public class DeviceRegDBContext:DbContext
    {
        
        public DeviceRegDBContext():base("DefaultConnection") {
            Database.SetInitializer(new DeviceRegDBInitializer());
        }
        public virtual DbSet<Device> Devices
        {
            get; set;
        }
        public virtual DbSet<AspNetUser> AspNetUsers
        {
            get; set;
        }
        //public virtual DbSet<Medium> Mediums
        //{
        //    get; set;
        //}
        //public virtual DbSet<TypeOfDevice> Types
        //{
        //   get; set;
        //}

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AspNetUser>()
                        .HasMany<AspNetRole>(s => s.Roles)
                        .WithMany(c => c.Users)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UserId");
                            cs.MapRightKey("RoleId");
                            cs.ToTable("AspNetUserRoles");
                        });

        }
    }
}


