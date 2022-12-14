namespace UI.WebMatricula3C2022.Models.Colegiatura.Salida
{
    public class VerTodosColegiaturas : General.RespuestaAPI
    {
        public List<DatosColegiaturas> ListaColegiaturas { get; set; }

        public VerTodosColegiaturas()
        {
            ListaColegiaturas = new List<DatosColegiaturas>();
        }

    }

    public class DatosColegiaturas
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Facultad { get; set; }
        public string GradoAcademico { get; set; }
        public string Acreditada { get; set; }
    }

}
