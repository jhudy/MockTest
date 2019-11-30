using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IServicio
    {
        void Validar(string token);
        List<Alumno> GetAlumnos();
        int GetNota(int CI);
    }
}
