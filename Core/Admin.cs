using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Admin
    {
        List<Alumno> ListaAlumnos;
        string token;
        IServicio serv;

        public Admin(string user, string password, IServicio serv)
        {
            if(user == "jhudy" && password =="123")
            {
                token = "Token_Valid";
            }
            serv.Validar(token);
            this.serv = serv;
        }

        public List<Alumno> GetNotas()
        {
            ListaAlumnos = serv.GetAlumnos();
            foreach (var alumno in ListaAlumnos)
            {
                alumno.Nota = serv.GetNota(alumno.CI);
                alumno.Estado = serv.GetEstado(alumno.Nota);
            }
            return ListaAlumnos;
        }

    }
}
