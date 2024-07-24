// See https://aka.ms/new-console-template for more information
using Demo.Domain;
using Demo.Domain.ValueObjects;
using Demo.Persistence;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (var context = new MyDbContext())
{
    CreateMenu(context);
    //GetMenu(Guid.Parse("1decbdde-f144-44c7-bb3f-a122b2e86277"), context);
}


void GetMenu(Guid id, MyDbContext context)
{
    var menu = context.Menus
        .Include(m => m.Customers)
        .Where(m => m.Id == MenuId.Of(id))
        .FirstOrDefault();
}
void CreateMenu(MyDbContext context)
{
    var menu = new Menu()
    {
        Id = MenuId.Of(Guid.NewGuid()),
        Name = "First Menu",
        Customers = new List<Customer>()
        {
            new Customer()
            {
                Id = CustomerId.Of(Guid.NewGuid()),
                Name = "First Customer"
            },
            new Customer()
            {
                Id = CustomerId.Of(Guid.NewGuid()),
                Name = "Second Customer"
            }
        }
    };

    context.Menus.Add(menu);
    context.SaveChanges();
}