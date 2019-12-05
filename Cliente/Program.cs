using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("......");
            IServicio serv = new Servicio();
            Admin admin = null;
            try
            {
                admin = new Admin("jhudy", "123", serv);
                List<Alumno> ListaNota = admin.GetNotas();
              
                foreach (var item in ListaNota)
                {
                    Console.WriteLine("CI: {0} - Nombre: {1} - Nota: {2} - Estado: {3}", item.CI, item.Nombre, item.Nota, item.Estado);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
            Console.WriteLine(".....");
            Console.ReadKey();
        }
    }
}
