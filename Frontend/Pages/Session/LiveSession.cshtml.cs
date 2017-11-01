using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Frontend.Pages.Session
{
    public class LiveSessionModel : PageModel
    {
        [BindProperty]
        public Guid SessionId { get; set; }

        [BindProperty]
        public string PlayerName { get; set; }

        public void OnGet(Guid sessionId, string playerName)
        {
            SessionId = sessionId;
            PlayerName = playerName;
        }
    }
}