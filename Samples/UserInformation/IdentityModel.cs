using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInformation
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public class IdentityModel
    {
        /// <summary>
        /// Домен Active Directory
        /// </summary>
        [Description("Домен Active Directory")]
        public string Domain { get; set; }

        /// <summary>
        /// Учетная запись(логин)
        /// </summary>
        [Description("Учетная запись")]
        public string Login { get; set; }

        /// <summary>
        /// Признак корректности идентификатора
        /// <para>У корректного идентификатора заполнены оба свойства, <seealso cref="Domain"/> и <seealso cref="Login"/></para>
        /// </summary>
        public bool IsValid
        {
            get
            {
                return !(string.IsNullOrEmpty(Domain) || string.IsNullOrEmpty(Login));
            }
        }

        /// <summary>
        /// Строковое представление объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $@"{Domain}\{Login}";

        /// <summary>
        /// Преобразование имени домена к краткой форме
        /// </summary>
        /// <param name="domain">Имя домена в полной или краткой форме</param>
        /// <returns></returns>
        private static string SimpleDomain(string domain)
        {
            const char delimiter = '.';
            if (domain.Contains(delimiter))
            {
                var splitted = domain.Split(delimiter);
                return splitted[0];
            }
            else
            {
                return domain;
            }
        }

        /// <summary>
        /// Выделение из полного регистрационного имени пользователя в формате DOMAIN\USER отдельно домена и отдельно имени пользователя
        /// </summary>
        /// <param name="identity">Полное регистрационное имя в формате DOMAIN\USER или краткое имя без указание домена</param>
        /// <returns>В любом случае возвращается объект</returns>
        public static IdentityModel ParseIdentity(string identity)
        {
            const char delimiter = '\\';

            string domain;
            string login;
            if (identity.Contains(delimiter))
            {
                var splitted = identity.Split(delimiter);
                if (splitted.Length == 2)
                {
                    domain = splitted[0];
                    login = splitted[1];
                }
                else
                {
                    // Возвращаем пустой объект, IsValid у него будет false
                    return new IdentityModel();
                }
            }
            else
            {
                // текущий домен, по умолчанию
                domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                login = identity;
            }
            return new IdentityModel()
            {
                Domain = SimpleDomain(domain),
                Login = login
            };
        }
    }
}
