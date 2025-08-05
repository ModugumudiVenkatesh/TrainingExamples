using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreRazorExample.Models;

namespace CoreRazorExample.Pages.Emp
{
    public class CreateModel : PageModel
    {
        private readonly CoreRazorExample.Models.OrgContext _context;

        public CreateModel(CoreRazorExample.Models.OrgContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeptId"] = new SelectList(_context.departments, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
