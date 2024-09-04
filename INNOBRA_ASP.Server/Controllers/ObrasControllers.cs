using Microsoft.AspNetCore.Mvc;
using INNOBRA_ASP.DB.Data;
using Microsoft.EntityFrameworkCore;
using INNOBRA_ASP.DB.Data.Entity;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("Api/Obras")]
    public class ObrasControllers : ControllerBase
    {
        private readonly Context context;

        public ObrasControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Obra>>> Get()
        {
            return await context.Obras.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Obra entidad)
        {
            try
            {
                context.Obras.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Obra entidad)
        {

            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos.");
            }

            // En vez de var puede ser Obra :D
            var verif = await context.Obras.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (verif == null)
            {
                return NotFound("No existe la obra buscada.");
            }

            verif.Nombre = entidad.Nombre;
            verif.FechaInicio = entidad.FechaInicio;
            verif.FechaFin = entidad.FechaFin;

            try
            {
                context.Obras.Update(verif);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}