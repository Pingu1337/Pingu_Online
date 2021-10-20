using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using xPingu.SharedLib.Data;
using xPingu.SharedLib.Models;

namespace PinguBackend.Pages.WarcraftDB
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly xPingu.SharedLib.Data.WarcraftContext _context;

        public DeleteModel(xPingu.SharedLib.Data.WarcraftContext context)
        {
            _context = context;
        }

        [BindProperty]
        public wowDBitems wowDBitems { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            wowDBitems = await _context.prices.FirstOrDefaultAsync(m => m.itemName == id);

            if (wowDBitems == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            wowDBitems = await _context.prices.FindAsync(id);

            if (wowDBitems != null)
            {
                _context.prices.Remove(wowDBitems);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
