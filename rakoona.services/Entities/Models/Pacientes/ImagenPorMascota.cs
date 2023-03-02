namespace rakoona.services.Entities.Models.Pacientes
{
    public class ImagenPorMascota : ModelBase
    {
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string FileType { get; set; }
        public bool Principal { get; set; }

        public int MascotaRef { get; set; }
        public virtual Mascota? Mascota { get; set; }
    }
}
