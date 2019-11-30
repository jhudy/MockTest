﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Servicio : IServicio
    {
        Random rmd = new Random();
        public List<Alumno> GetAlumnos()
        {
            List<Alumno> result = new List<Alumno>();
            result.Add(new Alumno() { CI = 6642, Nombre = "Andres Calamaro" });
            result.Add(new Alumno() { CI = 5678, Nombre = "Julia Aponte" });
            result.Add(new Alumno() { CI = 2345, Nombre = "Leon Gieco" });
            result.Add(new Alumno() { CI = 1234, Nombre = "Andy Barreto" });
            return result;
        }

        public int GetNota(int CI)
        {
            int nota = rmd.Next(1, 100);
            return nota;
        }

        public void Validar(string token)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new Exception("Token invalido");
            }
        }
    }
}