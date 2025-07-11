using UnityEngine;

namespace SabanMete.DITest
{
    public class DebugLoggerService: ILoggerService
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
}