using OOP.Contracts.Enums;

namespace OOP.Contracts
{
    public record User
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public Gender gender { get; set; }
    }
}
