namespace UI.WebMatricula3C2022.Models.Curso.Salida
{
    public class VerTodosCursos : General.RespuestaAPI
    {
        public List<DatosCursos> ListaCursos { get; set; }

        public VerTodosCursos()
        {
            ListaCursos = new List<DatosCursos>();
        }

    }

    public class DatosCursos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Creditos { get; set; }
        public int CodigoHorario { get; set; }
        public string Estado { get; set; }
    }

}
