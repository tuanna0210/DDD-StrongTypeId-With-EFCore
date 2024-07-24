using Demo.Domain.MenuAggregate.ValueObjects;

namespace Demo.Domain.MenuAggregate.Entities;

public class MenuSection
{
    internal MenuSection(MenuSectionId id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public MenuSectionId Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
