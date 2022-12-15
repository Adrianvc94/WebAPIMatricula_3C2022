namespace UI.WebMatricula3C2022.Models.Nota.Entrada
{
    public class EditarNota : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public int CodigoCurso { get; set; }
        public int CodigoEstudiante { get; set; }
        public int CodigoProfesor { get; set; }
        public decimal Nota { get; set; }
        public string Estado { get; set; }
    }
}
