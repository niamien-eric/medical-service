using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medical_Manager.Data;
using Medical_Manager.Models;

namespace Medical_Manager.Pages.Admin.Consults
{
    public class DeleteModel : PageModel
    {
        private readonly Medical_Manager.Data.DataContext _context;

        public DeleteModel(Medical_Manager.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Consult Consult { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Consult = await _context.Consults.FirstOrDefaultAsync(m => m.id == id);

            if (Consult == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Consult = await _context.Consults.FindAsync(id);

            if (Consult != null)
            {
                _context.Consults.Remove(Consult);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
