using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace xPingu.SharedLib.UserData.Data
{
    // Add profile data for application users by adding properties to the PinguUser class
    public class PinguUser : IdentityUser
    {
        public string usrname { get; set; }

        public string Role { get; set; }

    }
}
