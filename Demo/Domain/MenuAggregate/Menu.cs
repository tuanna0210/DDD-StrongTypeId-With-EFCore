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

        private Menu()
        {

        }
        private Menu(
            MenuId menuId,
            string name,
            AverageRating averageRating,
            List<MenuSection>? sections)
        {
            Id = menuId;
            Name = name;
            _sections = sections;
            AverageRating = averageRating;
        }

        public static Menu Create(
            string name,
            List<MenuSection>? sections = null)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                name,
                AverageRating.Of(0),
                sections ?? new());

            //menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }

        public void AddSection(MenuSectionId id, string name, string description)
        {
            _sections.Add(new MenuSection(id, name, description));
        }


    }
}
