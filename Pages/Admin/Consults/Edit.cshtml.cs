using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medical_Manager.Data;
using Medical_Manager.Models;

namespace Medical_Manager.Pages.Admin.Consults
{
    public class EditModel : PageModel
    {
        private readonly Medical_Manager.Data.DataContext _context;

        public EditModel(Medical_Manager.Data.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Consult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultExists(Consult.id))
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

        private bool ConsultExists(int id)
        {
            return _context.Consults.Any(e => e.id == id);
        }
    }
}
