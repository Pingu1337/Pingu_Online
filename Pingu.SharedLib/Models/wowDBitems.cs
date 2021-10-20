using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xPingu.SharedLib.Models
{
    public class wowDBitems
    {
        [Key]
        public string itemName { get; set; }
        public int minBuyout { get; set; }
        public int itemID { get; set; }
        public int oldPrice { get; set; }
        public string lastUpdated { get; set; }

    }
}
