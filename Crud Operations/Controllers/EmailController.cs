using Crud_Operations.Controllers;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Crud_Operations.Models;


namespace Crud_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController(IEmailService adcontext) : Controller
    {
        [HttpPost("SendingEmail")]
        public async Task<IActionResult> Add([FromForm] MailModel interviewDetails)
        {
            MailModel mail = new MailModel()
            {
                id = interviewDetails.id,
                Date = interviewDetails.Date,
                Time = interviewDetails.Time,
                Location = interviewDetails.Location,
                Recruiter = interviewDetails.Recruiter,
                Contact = interviewDetails.Contact,
                Status = interviewDetails.Status,
                Mail = interviewDetails.Mail,

            };

            await SendEmailToCenterAsync(mail);
            return CreatedAtAction(nameof(Add), interviewDetails);

        }


        private async Task SendEmailToCenterAsync(MailModel interviewDetails)
        {
            try
            {

                var centerEmail = "dharshinipriya0720@gmail.com"; // Replace with actual admin email address
                var subject = $"Your Interview Details";
                var body = $"Interview Date: {interviewDetails.Date}\n Interview Time: {interviewDetails.Time} \n Location: {interviewDetails.Location}\n Recruiter Name: {interviewDetails.Recruiter}\n Contact Number: {interviewDetails.Contact}";

                await adcontext.SendEmailAsync(centerEmail, subject, body);
                // Log success or handle any exceptions
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return;
            }
        }
    }
}
// Define an interface for your email service
public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}

// Implement your email service (e.g., using SmtpClient)
public class EmailService : IEmailService
{
    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using (var client = new SmtpClient("smtp-mail.outlook.com"))
        {
            client.Port = 587;
            client.Credentials = new NetworkCredential("dharshinipriya0720@gmail.com", "dharshini@20");
            client.EnableSsl = true;

            var message = new MailMessage
            {
                From = new MailAddress("dharshinipriya0720@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };
            message.To.Add(toEmail);

            await client.SendMailAsync(message);
        }
    }
}


