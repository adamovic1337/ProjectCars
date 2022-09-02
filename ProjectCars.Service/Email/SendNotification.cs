using Microsoft.Extensions.Options;
using ProjectCars.Model.DTO.Create;
using ProjectCars.Repository.Contracts;
using System.Net;
using System.Net.Mail;

namespace ProjectCars.Service.Email
{
    public class SendNotification : ISendNotification
    {
        private readonly IUserRepository _userRepository;
        private readonly ICarServiceRepository _carServiceRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IOptions<EmailConfig> _emailConfig;

        public SendNotification(IUserRepository userRepository, ICarServiceRepository carServiceRepository, IStatusRepository statusRepository, IOptions<EmailConfig> emailConfig)
        {
            _userRepository = userRepository;
            _carServiceRepository = carServiceRepository;
            _statusRepository = statusRepository;
            _emailConfig = emailConfig;
        }

        public void SendEmailNotification(EmailNotificationDto emailNotification)
        {
            var userinfo = _userRepository.GetOne(emailNotification.UserId);
            var serviceInfo = _carServiceRepository.GetOne(emailNotification.ServiceId);
            var statusInfo = _statusRepository.GetOne(emailNotification.StatusId);

            var fromAddress = new MailAddress(serviceInfo.Email, serviceInfo.Name);
            var toAddress = new MailAddress(userinfo.Email, $"{userinfo.FirstName} {userinfo.LastName}");

            string subject = "Service request status changed";
            string body = $"Hello [{userinfo.Username}], [{serviceInfo.Name}] has changed your service request status to [{statusInfo.Name}]";
            var smtp = new SmtpClient
            {
                Host = _emailConfig.Value.Host,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_emailConfig.Value.Email, _emailConfig.Value.Password),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}