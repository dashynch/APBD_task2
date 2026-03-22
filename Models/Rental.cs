namespace APBD_TASK2.Models
{
    public class Rental
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public User User { get; set; } = null!;
        public Equipment Equipment { get; set; } = null!;
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal? Penalty { get; set; }

        public bool IsReturned => ActualReturnDate.HasValue;
        public bool ReturnedOnTime => !IsReturned && DateTime.Now > ReturnDate;

        public Rental(User user, Equipment equipment, DateTime dateTime)
        {
            Id = _nextId++;
            User = user;
            Equipment = equipment;
            RentDate = DateTime.Now;
            ReturnDate = dateTime;
        }


    }
}