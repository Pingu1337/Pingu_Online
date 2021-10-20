using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using xPingu.SharedLib.Data;
using xPingu.SharedLib.Models;

namespace PinguBackend.Pages.WarcraftDB
{
    public class IndexModel : PageModel
    {
        private readonly xPingu.SharedLib.Data.WarcraftContext _context;

        public IndexModel(xPingu.SharedLib.Data.WarcraftContext context)
        {
            _context = context;
        }

        public IList<wowDBitems> wowDBitems { get;set; }

        public async Task OnGetAsync()
        {
            wowDBitems = await _context.prices.ToListAsync();
            foreach (var item in wowDBitems)
            {
                
                var newTimeFormat = item.lastUpdated.Replace(".", ":");
                item.lastUpdated = newTimeFormat;
            }
        }
    }
}
