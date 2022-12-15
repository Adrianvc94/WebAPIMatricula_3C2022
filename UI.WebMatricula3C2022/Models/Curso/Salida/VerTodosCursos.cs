﻿namespace UI.WebMatricula3C2022.Models.Curso.Salida
{
    public class VerTodosCursos : General.RespuestaAPI
    {
        public List<DatosCurso> ListaCursos { get; set; }



        public VerTodosCursos()
        {
            ListaCursos = new List<DatosCurso>();
        }
    }



    public class DatosCurso
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public int CodigoHorario { get; set; }
        public string Estado { get; set; }
    }
}
