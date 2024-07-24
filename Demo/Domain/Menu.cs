using Demo.Domain.ValueObjects;

namespace Demo.Domain
{
    public class Menu
    {
        public MenuId Id { get; set; }
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
