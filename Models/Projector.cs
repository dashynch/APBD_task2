namespace APBD_TASK2.Models
{

    public class Projector : Equipment
    {
        public int ProjectorLumens { get; set; }
        public string Resolution { get; set; }

        public Projector(string name, int projectorLumens, string resolution) : base(name)
        {
            ProjectorLumens = projectorLumens;
            Resolution = resolution;
        }

        
    }
}