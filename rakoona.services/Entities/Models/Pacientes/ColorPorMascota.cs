namespace rakoona.services.Entities.Models.Pacientes
{
    public class ColorPorMascota : ModelBase
    {
        public int MascotaRef { get; set; }
        public string Nombre { get; set; }

        public virtual Mascota? Mascota { get; set; }
    }
}
