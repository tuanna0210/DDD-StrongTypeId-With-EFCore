// See https://aka.ms/new-console-template for more information
using Demo.Domain;
using Demo.Domain.ValueObjects;
using Demo.Persistence;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using (var context = new MyDbContext())
{
    //CreateMenu(context);
    GetMenu(Guid.Parse("3180b64f-b15a-481b-9e4a-1624a053d6e1"), context);
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
        AverageRating = AverageRating.Of(4.5, 100),
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