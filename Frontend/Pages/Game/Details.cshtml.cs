using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Game
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public long Id { get; set; }

        public void OnGet(long id)
        {
            Id = id;
        }
    }
}