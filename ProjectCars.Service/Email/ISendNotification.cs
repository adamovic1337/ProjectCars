using ProjectCars.Model.DTO.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCars.Service.Email
{
    public interface ISendNotification
    {
        void SendEmailNotification(EmailNotificationDto emailNotification);
    }
}
