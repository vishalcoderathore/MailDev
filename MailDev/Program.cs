using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

var message = new MimeMessage();
var from = new MailboxAddress("Alice", "alice@example.com");
message.From.Add(from);
var to = new MailboxAddress("Bob", "bob@example.com");
message.To.Add(to);
message.Subject = "Hi Bob!";

var bb = new BodyBuilder();
bb.TextBody = "Hi Bob in plain text.";
bb.HtmlBody = "<p>Hi Bob in HTML.</p>";
message.Body = bb.ToMessageBody();

using var smtp = new SmtpClient();
await smtp.ConnectAsync("localhost", 1025, false);
await smtp.SendAsync(message);
await smtp.DisconnectAsync(true);
Console.WriteLine($"Mail sent to {to.Address}");