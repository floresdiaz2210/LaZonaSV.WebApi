using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaZonaSV.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace LaZonaSV.AccesoADatos
{
    public class CategoriasDAL
    {
        public static async Task<int> CrearAsync(Categorias pCategorias)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCategorias);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Categorias pCategorias)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categorias = await bdContexto.Categorias.FirstOrDefaultAsync(s => s.Id == pCategorias.Id);
                categorias.Categoria = categorias.Categoria;
                bdContexto.Update(categorias);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Categorias pCategorias)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categorias = await bdContexto.Categorias.FirstOrDefaultAsync(s => s.Id == pCategorias.Id);
                bdContexto.Categorias.Remove(categorias);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Categorias> ObtenerPorIdAsync(Categorias pCategorias)
        {
            var categorias = new Categorias();
            using (var bdContexto = new BDContexto())
            {
                categorias = await bdContexto.Categorias.FirstOrDefaultAsync(s => s.Id == pCategorias.Id);
            }
            return categorias;
        }

        public static async Task<List<Categorias>> ObtenerTodosAsync()
        {
            var categorias = new List<Categorias>();
            using (var bdContexto = new BDContexto())
            {
                categorias = await bdContexto.Categorias.ToListAsync();
            }
            return categorias;
        }

        internal static IQueryable<Categorias> QuerySelect(IQueryable<Categorias> pQuery, Categorias pCategorias)
        {
            if (pCategorias.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCategorias.Id);

            if (!string.IsNullOrWhiteSpace(pCategorias.Categoria))
                pQuery = pQuery.Where(s => s.Categoria.Contains(pCategorias.Categoria));

            if (pCategorias.Top_Aux > 0)
                pQuery = pQuery.Take(pCategorias.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Categorias>> BuscarAsync(Categorias pCategorias)
        {
            var categorias = new List<Categorias>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Categorias.AsQueryable();
                select = QuerySelect(select, pCategorias);
                categorias = await select.ToListAsync();
            }
            return categorias;
        }
    }
}
