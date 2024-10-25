using Mailjet.Client;
using Mailjet.Client.Resources;
using System.Threading.Tasks;

namespace EventRegistrationSystem.Service
{
    public class EmailService
    {
        private readonly MailjetClient _client;

        public EmailService(MailjetClient client)
        {
            _client = client;
        }

        public async Task Send(string recipientEmail, string subject, string body)
        {
            var request = new MailjetRequest
            {
                Resource = Send.Resource // Ensure this is properly set up
            }
            .AddParameter("From", "your_email@example.com") // Your sending email
            .AddParameter("To", recipientEmail)
            .AddParameter("Subject", subject)
            .AddParameter("TextPart", body);

            var response = await _client.PostAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error sending email: {response.StatusCode}");
            }
        }
    }
}
