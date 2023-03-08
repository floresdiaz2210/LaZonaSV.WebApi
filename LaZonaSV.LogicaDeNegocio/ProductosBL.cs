using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LaZonaSV.AccesoADatos;
using LaZonaSV.EntidadesDeNegocio;

namespace LaZonaSV.LogicaDeNegocio
{
    public class ProductosBL
    {

        public async Task<int> CrearAsync(Productos pProductos)
        {
            return await ProductosDAL.CrearAsync(pProductos);
        }
        public async Task<int> ModificarAsync(Productos pProductos)
        {
            return await ProductosDAL.ModificarAsync(pProductos);
        }
        public async Task<int> EliminarAsync(Productos pProductos)
        {
            return await ProductosDAL.EliminarAsync(pProductos);
        }
        public async Task<Productos> ObtenerPorIdAsync(Productos pProductos)
        {
            return await ProductosDAL.ObtenerPorIdAsync(pProductos);
        }
        public async Task<List<Productos>> ObtenerTodosAsync()
        {
            return await ProductosDAL.ObtenerTodosAsync();
        }
        public async Task<List<Productos>> BuscarAsync(Productos pProductos)
        {
            return await ProductosDAL.BuscarAsync(pProductos);
        }
        public async Task<List<Productos>> BuscarIncluirCategoriaAsync(Productos pProductos)
        {
            return await ProductosDAL.BuscarIncluirCategoriaAsync(pProductos);
        }
    }
}
