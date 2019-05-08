using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AirBattle
{
    [ServiceBehavior (
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Single)]
    public class WcfService : IWcfService
    {
        public void DoWork()
        {
        }
    }
}
