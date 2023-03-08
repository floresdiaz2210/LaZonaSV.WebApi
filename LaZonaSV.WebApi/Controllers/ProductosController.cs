using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Agregar la siguiente libreria para la seguridad JWT
using LaZonaSV.EntidadesDeNegocio;
using LaZonaSV.LogicaDeNegocio;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace LaZonaSV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class ProductosController : Controller
    {
        private ProductosBL productosbl = new ProductosBL();
        // GET: api/<ProductosController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Productos>> Get()
        {
            return await productosbl.ObtenerTodosAsync();
        }
        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public async Task<Productos> Get(int id)
        {
            Productos productos = new Productos();
            productos.Id = id;
            return await productosbl.ObtenerPorIdAsync(productos);
        }
        // POST api/<ProductosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Productos productos)
        {
            try
            {
                await productosbl.CrearAsync(productos);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pProductos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProductos = JsonSerializer.Serialize(pProductos);
            Productos productos = JsonSerializer.Deserialize<Productos>(strProductos, option);
            if (productos.Id == id)
            {
                await productosbl.ModificarAsync(productos);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Productos productos = new Productos();
                productos.Id = id;
                await productosbl.EliminarAsync(productos);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Productos>> Buscar([FromBody] object pProductos)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strProductos = JsonSerializer.Serialize(pProductos);
            Productos producto = JsonSerializer.Deserialize<Productos>(strProductos, option);
            var productos = await productosbl.BuscarIncluirCategoriaAsync(producto);
            productos.ForEach(s => s.Categorias.Productos = null); // Evitar la redundacia de datos
            return productos;
        }
    }
}
