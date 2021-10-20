using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using xPingu.SharedLib.Data;
using xPingu.SharedLib.Models;
using xPingu.SharedLib.UserData.Data;

namespace PinguBackend.Pages.WarcraftDB
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly xPingu.SharedLib.Data.WarcraftContext _context;

        public EditModel(xPingu.SharedLib.Data.WarcraftContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(wowDBitems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!wowDBitemsExists(wowDBitems.itemName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool wowDBitemsExists(string id)
        {
            return _context.prices.Any(e => e.itemName == id);
        }
    }
}
