using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UserInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            var di = new System.IO.DirectoryInfo(args[0]);
            var ds = di.GetAccessControl();
            // Имя прользователя - владельца каталога
            string userName = ds.GetOwner(typeof(NTAccount)).Value;
            var im = IdentityModel.ParseIdentity(userName);
            if (!im.IsValid)
            {
                Console.WriteLine($"Некорректное имя пользователя: {userName}");
                return;
            }

            // Запрос домена
            PrincipalContext domain;
            try
            {
                // Для безопасного защищённого соединения с доменом требуется использовать опции
                // var options = ContextOptions.SecureSocketLayer | ContextOptions.Negotiate;
                domain = new PrincipalContext(ContextType.Domain, im.Domain /*, null, options*/);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetUserInformation: Ошибка получения контекста домена {im.Domain} для пользователя {userName}. {ex.Message} {ex.InnerException}");
                return;
            }

            // Запрос пользователя в домене
            UserPrincipal user;
            try
            {
                user = UserPrincipal.FindByIdentity(domain, im.Login);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetUserInformation: Ошибка получения контекста пользователя {im}. {ex.Message} {ex.InnerException}");
                return;
            }

            if (user == null)
            {
                Console.WriteLine($"GetUserInformation: Не удалось найти пользователя {im}");
                return ;
            }

            Console.WriteLine($"{userName} = {user.EmailAddress}");          
        }
    }
}
