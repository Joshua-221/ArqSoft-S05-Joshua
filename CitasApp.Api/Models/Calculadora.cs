namespace CitasApp.Api.Models
{
    public class Calculadora
    {
        public string Operacion { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double Resultado { get; set; } = 0;
    }
}