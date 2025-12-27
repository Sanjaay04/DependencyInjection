using DependencyInjection.Interface;
namespace DependencyInjection.Service
{
    public class LoggerService : Ilogger
    {
        public void Log(String message)
        {
           
            {
                Console.WriteLine($"[MyLogger] {DateTime.Now:HH:mm:ss} - {message}");
            }
        }
    }
    
}

