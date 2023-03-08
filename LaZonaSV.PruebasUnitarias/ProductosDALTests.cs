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
    public class ProductosDALTests
    {
        private static Productos productosInicial = new Productos { Id = 2, categoriasId = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var productos = new Productos();
            productos.categoriasId = productosInicial.categoriasId;
            productos.Producto = "Redmi 9a";
            productos.Detalles = "32 GB de almacenamiento, Bateria de 5.00 mAh";
            productos.Precio = 134m;
            productos.Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSYhb4J0hKd51TUsKOYvuIWqSgR_d17SQGu5Q&usqp=CAU";
            int result = await ProductosDAL.CrearAsync(productos);
            Assert.AreNotEqual(0, result);
            productosInicial.Id = productos.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var productos = new Productos();
            productos.Id = productosInicial.Id;
            productos.categoriasId = productosInicial.categoriasId;
            productos.Producto = "Zte A31lite";
            productos.Detalles = "Pantalla 5 pulgadas";
            productos.Precio = 37m;
            productos.Imagen = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRGLeHxntkY2w7sBJkwwTZRirjIPY5tK6gIfA&usqp=CAU";
            int result = await ProductosDAL.ModificarAsync(productos);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var productos = new Productos();
            productos.Id = productosInicial.Id;
            var resultProductos = await ProductosDAL.ObtenerPorIdAsync(productos);
            Assert.AreEqual(productos.Id, resultProductos.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultProductos = await ProductosDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultProductos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var productos = new Productos();
            productos.categoriasId = productosInicial.categoriasId;
            productos.Producto = "A";
            productos.Detalles = "a";
            productos.Top_Aux = 10;
            var resultProductos = await ProductosDAL.BuscarAsync(productos);
            Assert.AreNotEqual(0, resultProductos.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirCategoriaAsyncTest()
        {
            var productos = new Productos();
            productos.categoriasId = productosInicial.categoriasId; ;
            productos.Producto = "A";
            productos.Detalles = "a";
            productos.Top_Aux = 10;
            var resultProductos = await ProductosDAL.BuscarIncluirCategoriaAsync(productos);
            Assert.AreNotEqual(0, resultProductos.Count);
            var ultimoProductos = resultProductos.FirstOrDefault();
            Assert.IsTrue(ultimoProductos.Categorias != null && productos.categoriasId == ultimoProductos.Categorias.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var productos = new Productos();
            productos.Id = productosInicial.Id;
            int result = await ProductosDAL.EliminarAsync(productos);
            Assert.AreNotEqual(0, result);
        }
    }
}