using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Data;
using VirtualPetAdoption.Models;

namespace VirtualPetAdoption.Pages
{
    public class QuizModel : PageModel
    {
        // Add the database context
        private readonly PetAdoptionContext _context;
        
        // Add this page model with the database context - so the page (html page) can be updated
        // with data from the database 
        public QuizModel(PetAdoptionContext context)
        {
            _context = context;
        }

        // Bind properties persist the form data after the user add their name and thier energy preference
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int EnergyPreference { get; set; }

        // Need to add on get method, but there is nothing we need to do to display the page because 
        // it is straight HTML - no inet
        public void OnGet()
        {
        }

        // onPost method is called when the form submit button is clicked
        // This method contains the logic for displaying a pet to the user 
        public async Task<IActionResult> OnPostAsync()
        {
            //Get a list of pets from the databadse using the db context
            var pets = await _context.Pets.ToListAsync();
            
            // Declare a varible to store the pet that is the best match and a variable 
            Pet bestMatch = null;
            int smallestDifference = int.MaxValue;

            // Find the best pet watch by looping through the pets from the database 
            // and comparing their energy levels to the user's level
            foreach (var pet in pets)
            {
                // Calculate the difference between the user's level and the pet's level of energy
                int difference = Math.Abs(pet.EnergyLevel - EnergyPreference);
                
                // Test is the difference is the smallmest one so far
                if (difference < smallestDifference)
                {
                    // update the varible
                    smallestDifference = difference;
                    bestMatch = pet;
                } // end if 
            } // end method

            // returns the redirect to the results page
            return RedirectToPage("./Results", new { petId = bestMatch.Id, userName = Name });
        }
    }
}

