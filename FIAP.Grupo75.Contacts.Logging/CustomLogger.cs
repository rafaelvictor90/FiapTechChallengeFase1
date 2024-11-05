using Microsoft.Extensions.Logging;

namespace FIAP.Grupo75.Contacts.Logging
{
    public class CustomLogger : ILogger
    {
        public static bool FileEnabledWrite { get; set; } = true;
        private readonly string loggerName;
        private readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            this.loggerName = loggerName;
            this.loggerConfig = loggerConfig;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message = string.Format($"{DateTime.Now.TimeOfDay:hh\\:mm\\:ss} {logLevel}: {eventId.Id} - {formatter(state, exception)}");

            if (FileEnabledWrite)
                WriteTextToFile(message);
            if (logLevel.Equals(LogLevel.Information))
                Console.WriteLine(message);
        }

        private void WriteTextToFile(string message)
        {
            string logFilePath = Environment.CurrentDirectory + @$"\Logs\LOG-{DateTime.Now:yyyy-MM-dd}.txt";

            if (!File.Exists(logFilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                File.Create(logFilePath).Dispose();
            }

            using StreamWriter streamWriter = new(logFilePath, true);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}
