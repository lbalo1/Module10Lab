using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly PetAdoptionContext _context;

        public ResultsModel(PetAdoptionContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int PetId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        public Pet Pet { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (PetId <= 0)
            {
                return RedirectToPage("./Index");
            }

            Pet = await _context.Pets.FindAsync(PetId);

            if (Pet == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}