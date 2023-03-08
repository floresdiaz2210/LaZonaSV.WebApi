using Microsoft.VisualStudio.TestTools.UnitTesting;
using LaZonaSV.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaZonaSV.EntidadesDeNegocio;

namespace LaZonaSV.AccesoADatos.Tests
{
    [TestClass()]
    public class CategoriasDALTests
    {

        private static Categorias categoriasInicial = new Categorias { Id = 2 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var categorias = new Categorias();
            categorias.Categoria = "Accesorios";
            int result = await CategoriasDAL.CrearAsync(categorias);
            Assert.AreNotEqual(0, result);
            categoriasInicial.Id = categorias.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var categorias = new Categorias();
            categorias.Id = categoriasInicial.Id;
            categorias.Categoria = "Reparacion";
            int result = await CategoriasDAL.ModificarAsync(categorias);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var categorias = new Categorias();
            categorias.Id = categoriasInicial.Id;
            var resultcategorias = await CategoriasDAL.ObtenerPorIdAsync(categorias);
            Assert.AreEqual(categorias.Id, resultcategorias.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultcategorias = await CategoriasDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultcategorias.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var categorias = new Categorias();
            categorias.Categoria = "a";
            categorias.Top_Aux = 10;
            var resultcategorias = await CategoriasDAL.BuscarAsync(categorias);
            Assert.AreNotEqual(0, resultcategorias.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var categorias = new Categorias();
            categorias.Id = categoriasInicial.Id;
            int result = await CategoriasDAL.EliminarAsync(categorias);
            Assert.AreNotEqual(0, result);
        }
    }
}