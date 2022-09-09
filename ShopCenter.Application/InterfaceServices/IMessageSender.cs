using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IMessageSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false);
    }
}
