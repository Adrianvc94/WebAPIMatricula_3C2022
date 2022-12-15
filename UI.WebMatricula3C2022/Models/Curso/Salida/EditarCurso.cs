namespace UI.WebMatricula3C2022.Models.Curso.Salida
{
    public class EditarCurso : General.RespuestaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int CodigoHorario { get; set; }
        public string Estado { get; set; }
    }
}
