using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medical_Manager.Data;
using Medical_Manager.Models;

namespace Medical_Manager.Pages.Admin.Consults
{
    public class CreateModel : PageModel
    {
        private readonly Medical_Manager.Data.DataContext _context;

        public CreateModel(Medical_Manager.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Consult Consult { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Consults.Add(Consult);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
