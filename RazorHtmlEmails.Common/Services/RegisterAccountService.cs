using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using RazorEmailTemplateClassLibrary.Services.Interfaces;
using RazorEmailTemplateClassLibrary.Views.Emails.ConfirmAccount;
using RazorHtmlEmails.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorHtmlEmails.Common.Services
{
    public class RegisterAccountService : IRegisterAccountService
    {
        public RegisterAccountService(IRazorViewToString razorViewToString)
        {
            _razorViewToStringRenderer = razorViewToString;
        }

        private readonly IRazorViewToString _razorViewToStringRenderer;

        public async Task Register(string email, string baseUrl)
        {
            var confirmAccountModel = new ConfirmAccountEmailViewModel($"{baseUrl}/{Guid.NewGuid()}");

            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/ConfirmAccount/ConfirmAccount.cshtml", confirmAccountModel);

            var toAddresses = new List<string> { email };

            string fromAddress = "marielle.abernathy31@ethereal.email";

            SendEmail(toAddresses, fromAddress, "Confirm your Account", body);
        }

        private void SendEmail(List<string> toAddresses, string fromAddress, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("SenderFirstName SenderLastName", fromAddress));
            foreach (var to in toAddresses)
            {
                message.To.Add(new MailboxAddress("RecipientFirstName RecipientLastName", to));
            }
            message.Subject = subject;

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            using var client = new SmtpClient();

            string user = "marielle.abernathy31@ethereal.email";
            string password = "tKNvbXMYeufFj5jSda";

            client.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            client.Authenticate(user, password);

            client.Send(message);
            client.Disconnect(true);
        }
    }
}
