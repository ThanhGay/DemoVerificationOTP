using DemoVerificationOTP.Exceptions;
using DemoVerificationOTP.Services.Interfaces;
using System.Net;
using System.Net.Mail;


namespace DemoVerificationOTP.Services.Implements
{
    public class NotiService : INotiService
    {
        /// <summary>
        /// Truy cập link để cài đặt và cấu hình SMTP Gmail
        /// https://security.google.com/settings/security/apppasswords
        /// 
        /// Đặt tên ứng dụng là: "Smtp Gmail"
        /// 
        /// Sau đó copy mật khẩu hiển thị trên màn hình vào senderPassword
        /// senderPassword không có khoảng trắng
        /// 
        /// </summary>
        /// ví dụ
        /// senderEmail = "phoducthanh@gmail.com"
        /// senderPassword = "jnncnisknewjeptc"
        /// <param name="senderEmail">Email người gửi</param>
        /// <param name="senderPassword">Mật khẩu ứng dụng - Không phải mật khẩu truy cập Email</param>
        /// 

        private const string senderEmail = "your_email@gmail.com";
        private const string senderPassword = "your_password";

        public void SendMail(string receiveEmail, string body)
        {
            // Tạo một đối tượng MailMessage
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(senderEmail);
            mail.To.Add(receiveEmail);
            mail.Subject = "[C# .NET] Email verification code";
            mail.Body = "Đây là email được gửi từ ASP.Net\n" + body;

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
                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}
