using EventRegistrationSystem.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EventRegistrationSystem.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly EmailService _emailService;

        public RegistrationsController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(Registration model)
        {
            if (ModelState.IsValid)
            {
                // Save registration data to the database (omitted for brevity)

                // Prepare email details
                string recipientEmail = model.Email;
                string subject = "Registration Confirmation";
                string body = $"Thank you for registering for the event!";

                // Send confirmation email
                await _emailService.Send(recipientEmail, subject, body); // Ensure to include parentheses

                return RedirectToAction("Index", "Home");
            }

            return View(model); // Return the view with the model if validation fails
        }
    }
}
