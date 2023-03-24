<h2 align="center"> Email template using Razor </h2>

<p>This is a demo project which shows how to create a HTML email template as Razor view, send it using MailKit and Ethereal email as a SMTP service</p>

## To try this you have to,

1. Install Visual Studio 22 with asp.net and .net SDK 6 or a higher version.
2. Configure an Ethereal smtp email service.

Inside the `RazorHtmlEmails.Common` library you can find `RegisterAccountService.cs` in '/services' directory. In that class you can find two methods named Register and SendEmail.

1. You have to change the fromAddress to your Etherael email address in Register method.
```csharp
public async Task Register(string email, string baseUrl)
{
        var confirmAccountModel = new ConfirmAccountEmailViewModel($"{baseUrl}/{Guid.NewGuid()}");

        string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/ConfirmAccount/ConfirmAccount.cshtml", confirmAccountModel);

        var toAddresses = new List<string> { email };

        string fromAddress = "marielle.abernathy31@ethereal.email";

        SendEmail(toAddresses, fromAddress, "Confirm your Account", body);
}
```

2. Then change the userName and password to your Ethereal user and password.
```csharp
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
```

Now you can run the program and test it. You can view your email in Etheral inbox.

## Thats it,
