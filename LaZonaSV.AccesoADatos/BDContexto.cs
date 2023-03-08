using LaZonaSV.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaZonaSV.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; } = null!;
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source =LAPTOP-F1UGIK5C;Initial Catalog=Lazonacel;Integrated Security=True");

            //MI CONEXION A LA BASE DE DATOS QUE TENGO EN LOCAL

            //optionsBuilder.UseSqlServer(@"Data Source =LAPTOP-F1UGIK5C;Initial Catalog=Lazonacel;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source =lazonacelDB.mssql.somee.com; Initial Catalog=lazonacelDB;User Id=lazonaProject; pwd=admin2022");

            //DESKTOP-PHJBKME
        }
    }
}
