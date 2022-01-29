using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace Marizona.WebUI.Core.Extensions
{
    static public partial class Extension
    {
        static public bool SendEmail(this IConfiguration configuration,
            string to, 
            string subject,
            string body,
            bool appendCC = false) 
        {

            try
            {
                string displayName = configuration["Email:displayname"];
                string smtpServer = configuration["Email:smtpserver"];
                int smtpPort = Convert.ToInt32(configuration["Email:smtpport"]);
                string fromMail = configuration["Email:username"];
                string password = configuration["Email:password"];
                string cc = configuration["Email:cc"];

                using (MailMessage message = new MailMessage(new MailAddress(fromMail, displayName), new MailAddress(to))
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    if (!string.IsNullOrWhiteSpace(cc) && appendCC)
                        message.CC.Add(cc);

                    SmtpClient smtpClient = new SmtpClient(smptpserver, smptport);
                    smtpClient.Credentials = new NetworkCredential(fromMail, password);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                return false;
            }





            return true;
        }
    }
}
