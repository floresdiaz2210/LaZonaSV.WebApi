using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaZonaSV.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace LaZonaSV.AccesoADatos
{
    public class ProductosDAL
    {
        public static async Task<int> CrearAsync(Productos pProductos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pProductos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Productos pProductos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var productos = await bdContexto.Productos.FirstOrDefaultAsync(s => s.Id == pProductos.Id);
                productos.categoriasId = pProductos.categoriasId;
                productos.Producto = pProductos.Producto;
                productos.Detalles = pProductos.Detalles;
                productos.Imagen = pProductos.Imagen;
                productos.Precio = pProductos.Precio;
                bdContexto.Update(productos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Productos pProductos)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var productos = await bdContexto.Productos.FirstOrDefaultAsync(s => s.Id == pProductos.Id);
                bdContexto.Productos.Remove(productos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Productos> ObtenerPorIdAsync(Productos pProductos)
        {
            var productos = new Productos();
            using (var bdContexto = new BDContexto())
            {
                productos = await bdContexto.Productos.FirstOrDefaultAsync(s => s.Id == pProductos.Id);
            }
            return productos;
        }

        public static async Task<List<Productos>> ObtenerTodosAsync()
        {
            var productos = new List<Productos>();
            using (var bdContexto = new BDContexto())
            {
                productos = await bdContexto.Productos.ToListAsync();
            }
            return productos;
        }

        internal static IQueryable<Productos> QuerySelect(IQueryable<Productos> pQuery, Productos pProductos)
        {
            if (pProductos.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pProductos.Id);

            if (pProductos.categoriasId > 0)
                pQuery = pQuery.Where(s => s.categoriasId == pProductos.categoriasId);

            if (!string.IsNullOrWhiteSpace(pProductos.Producto))
                pQuery = pQuery.Where(s => s.Producto.Contains(pProductos.Producto));

            if (!string.IsNullOrWhiteSpace(pProductos.Detalles))
                pQuery = pQuery.Where(s => s.Detalles.Contains(pProductos.Detalles));

            if (!string.IsNullOrWhiteSpace(pProductos.Imagen))
                pQuery = pQuery.Where(s => s.Imagen.Contains(pProductos.Imagen));

            if (pProductos.Precio > 0)
                pQuery = pQuery.Where(s => s.Precio == pProductos.Precio);

            if (pProductos.Top_Aux > 0)
                pQuery = pQuery.Take(pProductos.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Productos>> BuscarAsync(Productos pProductos)
        {
            var productos = new List<Productos>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Productos.AsQueryable();
                select = QuerySelect(select, pProductos);
                productos = await select.ToListAsync();
            }
            return productos;
        }

        public static async Task<List<Productos>> BuscarIncluirCategoriaAsync(Productos pProductos)
        {
            var productos = new List<Productos>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Productos.AsQueryable();
                select = QuerySelect(select, pProductos).Include(s => s.Categorias).AsQueryable();
                productos = await select.ToListAsync();
            }
            return productos;
        }
    }
}
