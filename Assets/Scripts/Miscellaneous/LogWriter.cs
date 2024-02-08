using System.Globalization;
using System.IO;
using UnityEngine;

namespace Miscellaneous
{
    public static class LogWriter
    {
        #region Constants

        private const string FolderName = "Logs";

        #endregion

        #region Methods

        // ReSharper disable Unity.PerformanceAnalysis
        public static void DevelopmentLog(string message, LogType logType = LogType.Log, GameObject source = null)
        {
#if DEVELOPMENT_BUILD || UNITY_EDITOR
            switch (logType)
            {
                case LogType.Error:
                    UnityEngine.Debug.LogError(message, source);
                    break;
                case LogType.Assert:
                    UnityEngine.Debug.LogAssertion(message, source);
                    break;
                case LogType.Warning:
                    UnityEngine.Debug.LogWarning(message, source);
                    break;
                default:
                    UnityEngine.Debug.Log(message, source);
                    return;
            }
#endif
        }

        public static void WriteFileLog(string fileName, string logMessage)
        {
            var path = Path.Combine(Application.dataPath, FolderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, $"{fileName}.txt");
            
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            using StreamWriter writer = File.AppendText(path);

            logMessage = $"{System.DateTime.Now.ToString(CultureInfo.InvariantCulture)}; {logMessage}";
            writer.WriteLine(logMessage);
        }

        #endregion
    }
}