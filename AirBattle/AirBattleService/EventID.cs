using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirBattle
{
    /// <summary>
    /// Идентификаторы события в журнале Windows
    /// </summary>
    public enum  EventID
    {
        None,
        Start,
        Stop,
        Pause,
        Continue,
        Exception,
        Timer,
        Watch
    }
}
