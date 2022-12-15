namespace UI.WebMatricula3C2022.Models.Curso.Entrada
{
    public class AgregarCurso : General.EntradaAPI
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int CodigoHorario { get; set; }
        public string Estado { get; set; }
    }
}
