using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieryResturantServices.InterfaceDTO.Interface
{
    public interface ILoggers
    {
        void LogError(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogInfo(string message);

    }
}
