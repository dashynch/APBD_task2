

using APBD_TASK2.Database;
using APBD_TASK2.Models;
using APBD_TASK2.Services;
using APBD_TASK2.Enum;

var db = Singleton.Instance;
var service = new RentalService();

Console.WriteLine("Adding Equipment");
service.AddEquipment(new Laptop("MacBook Pro", 13, 8));
service.AddEquipment(new Laptop("MacBook Air", 16, 32));
service.AddEquipment(new Camera("Canon EOS 90D", "Canon EOS", 32, true));
service.AddEquipment(new Projector("Epson EB-X51", 3600, "1024x768"));

Console.WriteLine("\nAdding Users");
service.AddUser(new User("Maria Nowak", "mari@university.pl", UserType.Student));
service.AddUser(new User("Jan Kowalski", "jan@university.pl", UserType.Student));
service.AddUser(new User("Piotr Mickiewicz", "piotr@university.pl", UserType.Employee));

Console.WriteLine("\nAll Equipment");
foreach (var e in service.GetAllEquipment()) 
    Console.WriteLine($"({e.Id}) {e.Name} - {e.Status}");

Console.WriteLine("\nAvailable Equipment");
foreach (var e in service.GetAvailableEquipment())
    Console.WriteLine($"({e.Id}) {e.Name}");

Console.WriteLine("\nRenting Equipment");
service.RentEquipment(1, 1, DateTime.Now.AddDays((4)));
service.RentEquipment(2, 2, DateTime.Now.AddDays((7)));
service.RentEquipment(3, 3, DateTime.Now.AddDays((1)));

Console.WriteLine("\nInvalid Rental because of the limit");
service.RentEquipment(1, 4, DateTime.Now.AddDays((3)));

Console.WriteLine("\nMark Equipment Unavailable");
service.EquipmentUnavailable(3);

Console.WriteLine("\nInvalid Rental because unavailable");
service.RentEquipment(2, 4, DateTime.Now.AddDays(4));

Console.WriteLine("\nActive Rentals for User 1");
foreach (var r in service.GetAvtiveRentals(1))
    Console.WriteLine($"Rental ({r.Id}): {r.Equipment.Name} until {r.ReturnDate:yy-MM-dd}");

Console.WriteLine("\nReturn Rental On Time");
service.ReturnEquipment(2);

Console.WriteLine("\nReturn Late");
var lateRental = new Rental(
    db.Users[0],
    db.Equipment[1],
    DateTime.Now.AddDays(-4)
);
db.Rentals.Add(lateRental);
service.ReturnEquipment(lateRental.Id);

Console.WriteLine("\nReturned Rentals");
var returnRent = db.Rentals.Where(r => r.IsReturned).ToList();
if (returnRent.Count == 0)
{
    Console.WriteLine("No returns rentals");
}
else
{
    foreach (var r in returnRent) 
        Console.WriteLine($"Rental ({r.Id}): {r.Equipment.Name} - {r.User.Name}");
    
}

Console.WriteLine("\nFinal Print Rentals");
service.PrintRentals();



