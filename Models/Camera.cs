namespace APBD_TASK2.Models
{

    public class Camera : Equipment
    {
        public string CameraName { get; set; }
        public int MegaPixels { get; set; }
        public bool Stabilization { get; set; }

        public Camera(string name, string cameraName, int megaPixels, bool stabilization) : base(name) 
        {
            CameraName = cameraName;
            MegaPixels = megaPixels;
            Stabilization = stabilization;
        }
    }
}