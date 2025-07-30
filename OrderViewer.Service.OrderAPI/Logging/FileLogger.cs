using Microsoft.Extensions.Logging;
using System;
using System.IO;


namespace OrderViewer.Service.OrderAPI.Logging
{
    public class FileLogger(string filePath, string category) : ILogger
    {
        private readonly string _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        private readonly string _category = category ?? throw new ArgumentNullException(nameof(category));

        public IDisposable? BeginScope<TState>(TState state) where TState: notnull { return null!; }
        public bool IsEnabled(LogLevel logLevel) => logLevel >= LogLevel.Information;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (IsEnabled(logLevel)) return;
            
            var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {_category} - {formatter(state, exception)}";

            if (exception != null)
            {
                logMessage += $"\nException: {exception}";
            }

            try
            {
                File.AppendAllText(_filePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                //Write to console if file logging fails
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed to log to file: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine(logMessage);
            }
        }
    }
}
