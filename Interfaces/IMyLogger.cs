using OOP.Contracts;

namespace OOP.Interfaces
{
    public interface IMyLogger
    {
        public void Info(string text);
        public void Error(string text);
    }
}
