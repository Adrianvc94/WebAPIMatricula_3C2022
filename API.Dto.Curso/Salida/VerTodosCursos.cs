using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Curso.Salida
{
    public class VerTodosCursos : Dto.General.RespuestaAPI
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
