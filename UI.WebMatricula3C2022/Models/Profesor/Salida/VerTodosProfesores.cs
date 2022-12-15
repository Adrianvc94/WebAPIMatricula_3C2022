namespace UI.WebMatricula3C2022.Models.Profesor.Salida
{
    public class VerTodosProfesores : General.RespuestaAPI
    {
        public List<DatosProfesores> ListaProfesores { get; set; }

        public VerTodosProfesores()
        {
            ListaProfesores = new List<DatosProfesores>();
        }

    }

    public class DatosProfesores
    {
        public int Codigo { get; set; }
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Estado { get; set; }
        public int CodigoColegiatura { get; set; }

    }

}
