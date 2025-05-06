using System;
using System.IO;
using System.Windows.Forms;

namespace NoktaBilgiNotificationUI.Classes
{
    internal class TextLog
    {
        internal static void TextLogging(string message,string derece="0")
        {
            try
            {
                string logFilePath = $"{Application.StartupPath}\\Logs\\UILog.txt";
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
                if (derece!="0")
                    EMailManager.ErrorMailSend($"{DateTime.Now}: {message}");

            }
            catch (Exception)
            {

            }
        }
    }
}