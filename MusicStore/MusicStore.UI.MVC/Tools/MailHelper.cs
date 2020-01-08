using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MusicStore.UI.MVC.Tools
{
    public class MailHelper
    {
        public static bool AktivasyonKoduGonder(string username, string mail, Guid confirmationToken)
        {
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.To.Add(mail);
            msg.Subject = "Aktivasyon onay maili";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<!DOCTYPE html><html><head><title>Activasyon Maili</title></head><body><h3>Sayın {0} sitemize hoşgeldiniz.</h3> <p>Activasyonu Gerçekleştirmek için <a href='http://localhost:39816/Account/ActivationUser/{1}'>tıklayınız...</a></p></body></html>", username, confirmationToken);
            msg.From = new MailAddress("YMS5170Coder@outlook.com", "MVC_MusicStoreApp");

            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.EnableSsl = true;
            NetworkCredential cred = new NetworkCredential("YMS5170Coder@outlook.com", "CoderYMS5170");
            smtp.Credentials = cred;
            try
            {
                smtp.Send(msg);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}