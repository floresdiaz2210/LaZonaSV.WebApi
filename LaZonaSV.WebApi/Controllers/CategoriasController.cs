using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LaZonaSV.EntidadesDeNegocio;
using LaZonaSV.LogicaDeNegocio;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace LaZonaSV.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // agregar el siguiente metadato para autorizar JWT la Web API
    public class CategoriasController : Controller
    {
        private CategoriasBL categoriasbl = new CategoriasBL();
        // GET: api/<CategoriasController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Categorias>> Get()
        {
            return await categoriasbl.ObtenerTodosAsync();
        }
        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public async Task<Categorias> Get(int id)
        {
            Categorias categorias = new Categorias();
            categorias.Id = id;
            return await categoriasbl.ObtenerPorIdAsync(categorias);
        }
        // POST api/<CategoriasController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categorias categorias)
        {
            try
            {
                await categoriasbl.CrearAsync(categorias);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categorias categorias)
        {

            if (categorias.Id == id)
            {
                await categoriasbl.ModificarAsync(categorias);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Categorias  categorias = new Categorias();
                categorias.Id = id;
                await categoriasbl.EliminarAsync(categorias);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Categorias>> Buscar([FromBody] object pCategorias)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCategorias = JsonSerializer.Serialize(pCategorias);
            Categorias categorias = JsonSerializer.Deserialize<Categorias>(strCategorias, option);
            return await categoriasbl.BuscarAsync(categorias);

        }
    }
}
