using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xPingu.SharedLib.Models.UserModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }    
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }   
}
