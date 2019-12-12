using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest
{
    public class Worker
    {
        public static Result Division(string sx, string sy)
        {
            try
            {
                double x = double.Parse(sx, System.Globalization.CultureInfo.InvariantCulture);
                double y = double.Parse(sy, System.Globalization.CultureInfo.InvariantCulture);
                return new Result(x / y);
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }
    }
}
