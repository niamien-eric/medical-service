using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medical_Manager.Data;
using Medical_Manager.Models;
using Microsoft.AspNetCore.Authorization;

namespace Medical_Manager.Pages.Admin.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Medical_Manager.Data.DataContext _context;

        public IndexModel(Medical_Manager.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
