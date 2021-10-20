using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using xPingu.SharedLib.Data;
using xPingu.SharedLib.Models;

namespace PinguBackend.Pages.WarcraftDB
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly xPingu.SharedLib.Data.WarcraftContext _context;

        public CreateModel(xPingu.SharedLib.Data.WarcraftContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public wowDBitems wowDBitems { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.prices.Add(wowDBitems);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
