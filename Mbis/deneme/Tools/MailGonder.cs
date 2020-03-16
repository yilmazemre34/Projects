using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace deneme.Tools
{
    public class MailGonder
    {
        public static bool IsAtamaMaili(string username, string mail,string description)
        {
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.To.Add(mail);
            msg.Subject = username.ToString()+" isimli personele iş atandı.";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<!DOCTYPE html><html><head><title>İş Uyarı</title></head><body><p>{1}</p><br/><h3> {0} isimli personele iş atanmıştır.</body></html>", username,description);
            msg.From = new MailAddress("emrebeybau@gmail.com", "İş Takip");

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            NetworkCredential cred = new NetworkCredential("emrebeybau@gmail.com", "1634hunter");
            smtp.Credentials = cred;
            try
            {
                smtp.Send(msg);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}