using Demo.Domain.MenuAggregate.Entities;
using Demo.Domain.MenuAggregate.ValueObjects;

namespace Demo.Domain.MenuAggregate
{
    public class Menu
    {
        private readonly List<MenuSection> _sections = new();
        public MenuId Id { get; set; }
        public string Name { get; set; }
        public AverageRating AverageRating { get; set; }
        public IReadOnlyCollection<MenuSection> Sections => _sections.AsReadOnly();
        public List<Customer> Customers { get; set; }

        public void AddSection(MenuSectionId id, string name, string description)
        {
            _sections.Add(new MenuSection(id, name, description));
        }
    }
}
