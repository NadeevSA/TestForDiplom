using OOP.Context;
using OOP.Contracts;
using OOP.Interfaces;

namespace OOP.Logger
{
    public class MyLogger : IMyLogger
    {
        public void Info(string text)
        {
            Log("INFO", DateTime.Now.ToShortTimeString(), text);
        }

        public void Error(string text)
        {
            Log("ERROR", DateTime.Now.ToShortTimeString(), text);
        }

        private void Log(string type, string datetime, string text) 
            => Console.WriteLine($"[{datetime}][{type}] {text}");
    }
}
