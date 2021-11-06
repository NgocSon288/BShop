using EShop.Utilities.Models;
using System.Threading.Tasks;

namespace EShop.Utilities.Helpers
{
    public interface IMailHelperService
    {
        Task SendMail(MailContent mailContent);
    }
}