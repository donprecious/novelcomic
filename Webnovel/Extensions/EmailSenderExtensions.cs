using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Webnovel.Services;

namespace Webnovel.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }

        public static Task SendEmailAsync(this IEmailSender emailSender, string email, string subject, string message, string link, string linkText="Click to View")
        {
            return emailSender.SendEmailAsync(email, subject,
                $"{message} <br/> " +
                $"<a href='{HtmlEncoder.Default.Encode(link)}'> {linkText}</a>");
        }
        
    }
}
