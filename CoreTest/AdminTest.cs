using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Moq;
using System.Collections.Generic;

namespace CoreTest
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void ValidarToken_test()
        {
            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(x => x.Validar(It.IsAny<string>())); //reemplaza todo lo que no tiene control, mockear para reemplazar
            Admin admin = new Admin("aa", "11", mockServicio.Object);
            Assert.IsNotNull(admin);
        }

        [TestMethod]
        public void GetAlumnosCount_test()
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos.Add(new Alumno() { CI = 123, Nombre = "juan" });
            ListaAlumnos.Add(new Alumno() { CI = 234, Nombre = "maria" });

            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(g => g.GetAlumnos()).Returns(ListaAlumnos);
            //mockServicio.Setup(x => x.Validar(It.IsAny<string>())); 
            Admin admin = new Admin("aa", "11", mockServicio.Object);
            Assert.AreEqual(2, admin.GetNotas().Count);
        }

        [TestMethod]
        public void GetNotas_test()
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos.Add(new Alumno() { CI = 123, Nombre = "juan" });
            ListaAlumnos.Add(new Alumno() { CI = 234, Nombre = "maria" });

            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(g => g.GetAlumnos()).Returns(ListaAlumnos);
            mockServicio.Setup(n => n.GetNota(It.IsAny<int>())).Returns(50);
            Admin admin = new Admin("aa", "11", mockServicio.Object);
            Assert.AreEqual(50, admin.GetNotas()[0].Nota);
        }

        [TestMethod]
        public void GetEstado_test()
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos.Add(new Alumno() { CI = 123, Nombre = "juan" });
            ListaAlumnos.Add(new Alumno() { CI = 234, Nombre = "maria" });

            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(g => g.GetAlumnos()).Returns(ListaAlumnos);
            mockServicio.Setup(m => m.GetEstado(It.IsAny<int>())).Returns("Aprobado");
            Admin admin = new Admin("aa", "11", mockServicio.Object);
            Assert.AreEqual("Aprobado", admin.GetNotas()[0].Estado);
        }

        [TestMethod]
        public void SetNota_test()
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos.Add(new Alumno() { CI = 500, Nombre = "juan"});

            Mock<IServicio> mockServicio = new Mock<IServicio>();
            mockServicio.Setup(g => g.GetAlumnos()).Returns(ListaAlumnos);
            mockServicio.Setup(m => m.GetNota(It.IsAny<int>())).Returns(0);
            Admin admin = new Admin("aa", "11", mockServicio.Object);
            Assert.AreEqual(0, admin.GetNotas()[0].Nota);
        }
    }
}
