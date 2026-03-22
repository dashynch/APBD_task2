namespace APBD_TASK2.Models
{

    public class Laptop : Equipment
    {
        public int RamGb { get; set; }
        public int ScreenSize { get; set; }

        public Laptop(string name, int screenSize, int ramGb) 
            : base(name)
        {
            RamGb = ramGb;
            ScreenSize = screenSize;
        }
     }
}