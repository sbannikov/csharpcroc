using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace SampleUdf
{
    /// <summary>
    /// Пользовательские функции для Microsoft SQL Server
    /// </summary>
    public class UserDefinedFunctions
    {
        /// <summary>
        /// Сложение двух чисел
        /// </summary>
        /// <param name="x">Первое слагаемое</param>
        /// <param name="y">Второе слагаемое</param>
        /// <returns></returns>
        [SqlFunction(Name = "UserAdd", IsDeterministic = true, SystemDataAccess = SystemDataAccessKind.None)]
        static public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
