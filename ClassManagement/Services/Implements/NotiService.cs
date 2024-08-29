using DemoVerificationOTP.Services.Interfaces;
using System.Net;
using System.Net.Mail;


namespace DemoVerificationOTP.Services.Implements
{
    public class NotiService : INotiService
    {
        private const string senderEmail = "phothanh4a@gmail.com";
        private const string senderPassword = "exswsccsuixnauet";
        public void SendMail(string receiveEmail, string body)
        {
            // Tạo một đối tượng MailMessage
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(receiveEmail);
            mail.Subject = "Email verification code";
            mail.Body = "Đây là email được gửi từ ASP.Net C# \nMã OTP của bạn là:" + body;

            // Tạo một đối tượng SmtpClient
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
