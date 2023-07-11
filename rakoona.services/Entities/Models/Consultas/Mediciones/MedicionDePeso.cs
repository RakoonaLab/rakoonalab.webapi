﻿using rakoona.services.Entities.Models.Pacientes;

namespace rakoona.services.Entities.Models.Consultas.Mediciones
{
    public class MedicionDePeso : ModelBase
    {
        public DateTime FechaAplicacion { get; set; }
        public double Valor { get; set; }
        public int MascotaRef { get; set; }
        public Mascota? Mascota { get; set; }
        public Consulta? Consulta { get; set; }
    }
}
