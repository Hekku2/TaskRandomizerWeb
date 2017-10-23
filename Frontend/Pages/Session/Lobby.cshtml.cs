using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Frontend.Pages.Session
{
    public class LobbyModel : PageModel
    {
        [BindProperty]
        public Guid Id { get; set; }

        public void OnGet(Guid id)
        {
            Id = id;
        }
    }
}