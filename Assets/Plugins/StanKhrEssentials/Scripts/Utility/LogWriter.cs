using System;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace Plugins.StanKhrEssentials.Scripts.Utility
{
    public static class LogWriter
    {
        #region Constants

        private const string FolderName = "Logs";
        private const string FileExtension = ".txt";

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
                case LogType.Exception:
                    Debug.LogException(new Exception(message), source);
                    break;
                case LogType.Log:
                default:
                    UnityEngine.Debug.Log(message, source);
                    return;
            }
#endif
        }

        public static void WriteFileLog(string fileName, string logMessage)
        {
            var directoryPath = Path.Combine(Application.dataPath, FolderName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var filePath = GetFilePath(fileName, directoryPath);
            
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            using StreamWriter writer = File.AppendText(filePath);

            logMessage = $"{System.DateTime.Now.ToString(CultureInfo.InvariantCulture)}; {logMessage}";
            writer.WriteLine(logMessage);
        }

        private static string GetFilePath(string fileName, string directoryPath)
        {
            return Path.Combine(directoryPath, $"{fileName}{FileExtension}");
        }

        #endregion
    }
}