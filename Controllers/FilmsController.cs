using Microsoft.AspNetCore.Mvc;
using ApiLibros.Libros.Infrastructure.Repositories;
using ApiLibros.Domain.Data;
using Microsoft.AspNetCore.Http;

namespace ApiLibros.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmsController : ControllerBase
{
    
        private readonly IHttpContextAccessor _httpContext;

        public FilmsController(IHttpContextAccessor httpContext)
        {
           
            this._httpContext = httpContext;
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var pelis = new RepoPeliSql();
            var respuesta = pelis.GetAll();
            return Ok(respuesta);
        }
        
        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pelis = new RepoPeliSql();
            var pelicula =  pelis.GetById(id);
            if(pelicula==null)
                return NotFound("no se encontraron valores");
            return Ok(pelicula);
        } 

        [HttpGet]
        [Route("GetByGenero/{genero}")]
        public async Task<IActionResult> GetByGenero(string genero)
        {
            var pelis = new RepoPeliSql();
            var pelicula =  pelis.GetByGenero(genero);
            if(pelicula==null)
                return NotFound("no se encontraron valores");
            return Ok(pelicula);
        } 


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Datospelicula datospelicula)
        {
            var pelis = new RepoPeliSql();
            
            var id = await pelis.Create(datospelicula);
            if (id<=0)
                return Conflict("el registro no puedo ser realizado");
            var urlresult =$"https://{_httpContext.HttpContext.Request.Host.Value}/Films/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]Datospelicula datospelicula)
        {
            var pelis = new RepoPeliSql();
            if(id <= 0)
                return NotFound("El registro no fué encontrado, veifica tu información...");

            datospelicula.Idpelicula = id;


            var update = await pelis.Update(id, datospelicula);

            if(!update)
                return Conflict("Ocurrió un fallo al intentar realizar la modificación...");

            return NoContent();            
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pelis = new RepoPeliSql();
            var pelucula = await pelis.Delete(id);
           
            if(pelucula==false)
                return NotFound("no se encontraron valores");
            
            return NoContent();
        } 
}
