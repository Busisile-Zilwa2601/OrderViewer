using Microsoft.Extensions.Logging;

namespace OrderViewer.Service.OrderAPI.Logging
{
    public class FileLoggerProvider(string filePath) : ILoggerProvider
    {
        private readonly string _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_filePath, categoryName);
        }
        public void Dispose(){
            
            GC.SuppressFinalize(this);
        }
    }
}
