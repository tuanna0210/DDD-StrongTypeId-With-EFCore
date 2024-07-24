// See https://aka.ms/new-console-template for more information
using Demo.Domain.MenuAggregate;
using Demo.Domain.MenuAggregate.ValueObjects;
using Demo.Persistence;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (var context = new MyDbContext())
{
    //CreateMenu(context);
    //GetMenu(Guid.Parse("15536564-6a79-4708-8907-fd1468e5cf16"), context);
    DeleteMenu(Guid.Parse("46c87988-a9ea-4d78-9cd1-89675a720a7a"), context);
}


Menu GetMenu(Guid id, MyDbContext context)
{
    var menu = context.Menus
        .Include(m => m.Customers)
        .Where(m => m.Id == MenuId.Of(id))
        .FirstOrDefault();
    return menu;
}

void DeleteMenu(Guid id, MyDbContext context)
{
    //context.Menus.Where(m => m.Id == MenuId.Of(id)).ExecuteDelete();
    var menu = GetMenu(id, context);
    context.Menus.Remove(menu);
    context.SaveChanges();
}
void CreateMenu(MyDbContext context)
{
    //var menu = new Menu()
    //{
    //    Id = MenuId.Of(Guid.NewGuid()),
    //    Name = "First Menu",
    //    AverageRating = AverageRating.Of(4.5, 100),
    //    Customers = new List<Customer>()
    //    {
    //        new Customer()
    //        {
    //            Id = CustomerId.Of(Guid.NewGuid()),
    //            Name = "First Customer"
    //        },
    //        new Customer()
    //        {
    //            Id = CustomerId.Of(Guid.NewGuid()),
    //            Name = "Second Customer"
    //        }
    //    }
    //};
    var menu = Menu.Create(
        name: "First Menu"
    );
    menu.AddSection(MenuSectionId.Of(Guid.NewGuid()), "Main Course", "Main Course");
    menu.AddSection(MenuSectionId.Of(Guid.NewGuid()), "Appetizers", "Appetizers");

    context.Menus.Add(menu);
    context.SaveChanges();
}