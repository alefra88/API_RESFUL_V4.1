using Microsoft.AspNetCore.Mvc;
using WEB_API_CUATRO_AUTH.Models;
using WEB_API_CUATRO_AUTH.Services.Impl;
using WEB_API_CUATRO_AUTH.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API_CUATRO_AUTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _service;
        public AlumnoController(IAlumnoService service)
        {
            _service = service;
        }

        // GET: api/<AlumnoController>
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            var listAlumnos = await _service.GetAsync();
            return Ok(listAlumnos);
        }

        // GET api/<AlumnoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var alumno = await _service.GetAsync(id);
            return Ok(alumno);
        }

        // POST api/<AlumnoController>
        [HttpPost]
        public async Task Post([FromBody] AlumnoModel alumno)
        {
            await _service.AddAlumnoAsync(alumno);
        }

        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlumnoModel alumno)
        {
            var exAlumno = await _service.GetAsync(id);
            if (exAlumno == null)
            {
                return NotFound();
            }
            alumno.Id = id;
            await _service.UpdateAlumnoAsync(alumno);

            return NoContent();
        }

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _service.DeleteAlumnoAsync(id);
        }
    }
}
