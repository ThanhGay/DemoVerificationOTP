namespace DemoVerificationOTP.Services.Interfaces
{
    public interface INotiService
    {
        public void SendMail(string to, string body);
    }
}
