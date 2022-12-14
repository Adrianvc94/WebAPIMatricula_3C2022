namespace UI.WebMatricula3C2022.Models.Horario.Salida
{
    public class VerTodosHorarios : General.RespuestaAPI
    {
        public List<DatosHorario> ListaHorarios { get; set; }



        public VerTodosHorarios()
        {
            ListaHorarios = new List<DatosHorario>();
        }
    }



    public class DatosHorario
    {
        public int Codigo { get; set; }
        public string Dia { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Sede { get; set; }
        public string Aula { get; set; }
    }
}