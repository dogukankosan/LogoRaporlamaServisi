using System;
using System.IO;

namespace NoktaBilgiNotificationService.Classes
{
    internal class TextLog
    {
        internal static void TextLogging(string message,string derece="0")
        {
            try
            {
                string basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\Logs"));
                string logFilePath = Path.Combine(basePath, "ServiceLog.txt");
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
                if (derece != "0")
                    EMailManager.ErrorMailSend($"{DateTime.Now}: {message}");
            }
            catch (Exception)
            {

            }
        }
    }
}