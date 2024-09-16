using FociWebapp13BC;
using FociWebapp13BC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FociWebapp13BC.Pages
{
    public class UjMeccsFelveteleModel : PageModel
    {
        [BindProperty]
        public Meccs UjMeccs { get; set;}


        public List<Meccs> meccsekListája { get; set; } = new List<Meccs>();

        private readonly FociDbContext _db;
        public UjMeccsFelveteleModel(FociDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            meccsekListája = _db.Meccsek.ToList();
        }

        public IActionResult OnPost() 
        {
            _db.Meccsek.Add(UjMeccs);
            _db.SaveChanges();
            return Page();
        }
    }
}
