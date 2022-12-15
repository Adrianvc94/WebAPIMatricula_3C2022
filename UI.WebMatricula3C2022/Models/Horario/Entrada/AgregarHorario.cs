namespace UI.WebMatricula3C2022.Models.Horario.Entrada
{
    public class AgregarHorario : General.EntradaAPI
    {
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Sede { get; set; }
        public string Aula { get; set; }
    }
}
