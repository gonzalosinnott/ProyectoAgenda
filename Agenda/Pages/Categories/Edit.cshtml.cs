using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Data;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async void OnGet(int id)
        {
            Category = await _context.Category.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CategoryFromDb = await _context.Category.FindAsync(Category.Id);
                CategoryFromDb.Name = Category.Name;
                CategoryFromDb.CreationDate = Category.CreationDate;
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            
            return RedirectToPage();
        }
    }
}
