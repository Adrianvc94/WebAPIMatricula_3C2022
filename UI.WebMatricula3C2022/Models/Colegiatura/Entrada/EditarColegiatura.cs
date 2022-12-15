namespace UI.WebMatricula3C2022.Models.Colegiatura.Entrada
{
    public class EditarColegiatura : General.EntradaAPI
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Facultad { get; set; }
        public string GradoAcademico { get; set; }
        public string Acreditada { get; set; }
    }
}
