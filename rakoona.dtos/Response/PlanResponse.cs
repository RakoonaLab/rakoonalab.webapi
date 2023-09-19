namespace rakoona.dtos.Response
{
    public class PlanResponse
    {
        public string Id { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public string PrecioRef { get; set; }
        public int NumeroDeClinicas { get; set; }
        public int NumeroDeMedicos { get; set; }
    }
}
