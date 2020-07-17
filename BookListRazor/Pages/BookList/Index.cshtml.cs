using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db) {
            _db = db;
        }
        public IEnumerable<Book> Books { get; set; }



        public async Task OnGet(){
            Books = await _db.Book.ToListAsync();
        }
       
        public async Task<IActionResult> OnPostDelete(int id) {
            var BookDb =  await _db.Book.FindAsync(id);
            if(BookDb == null) {
                return NotFound();
            }
            _db.Book.Remove(BookDb);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        
    }
}