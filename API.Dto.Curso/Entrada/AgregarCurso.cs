﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dto.Curso.Entrada
{
    public class AgregarCurso : General.EntradaAPI
    {
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public string Horario { get; set; }
        public string Estado { get; set; }
    }
}