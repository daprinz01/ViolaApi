using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ViolaApi.DLL
{
    public class ViolaUser : IdentityUser
    {
        public ViolaUser()
        {
            SocialNetworks = new ObservableCollection<SocialNetworks>();
            //ViolaUserClaims = new ObservableCollection<ViolaUserClaims>();
            //ViolaUserLogin = new ObservableCollection<ViolaUserLogin>();
            //ViolaUserRoles = new ObservableCollection<ViolaUserRoles>();
            //ViolaRoles = new ObservableCollection<ViolaRoles>();
            //ViolaRoleClaims = new ObservableCollection<ViolaRoleClaims>();
            IdentityUser user = new IdentityUser();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public ObservableCollection<SocialNetworks> SocialNetworks { get; set; }
        //public ObservableCollection<ViolaUserRoles> ViolaUserRoles { get; set; }
        //public ObservableCollection<ViolaUserClaims> ViolaUserClaims { get; set; }
        //public ObservableCollection<ViolaUserLogin> ViolaUserLogin { get; set; }
        //public ObservableCollection<ViolaRoles> ViolaRoles { get; set; }
        //public ObservableCollection<ViolaRoleClaims> ViolaRoleClaims { get; set; }
    }

    public class ViolaUserRoles : IdentityUserRole<string>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
    public class ViolaUserClaims : IdentityUserClaim<string>
    {
        
    }
    public class ViolaUserLogin : IdentityUserLogin<string>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
    public class ViolaRoles : IdentityRole<string>
    {
        //public ViolaRoles(string roleName) : base(roleName)
        //{

        //}
        
    }
    public class ViolaRoleClaims: IdentityRoleClaim<string>
    {
        
    }

}
