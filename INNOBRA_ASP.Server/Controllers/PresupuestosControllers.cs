using Microsoft.AspNetCore.Mvc;
using INNOBRA_ASP.DB.Data;
using Microsoft.EntityFrameworkCore;
using INNOBRA_ASP.DB.Data.Entity;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("Api/Presupuesto")]
    public class PresupuestosControllers : ControllerBase
    {
        private readonly Context context;

        public PresupuestosControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Presupuesto>>> Get()
        {
            return await context.Presupuestos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Presupuesto entidad)
        {
            try
            {
                context.Presupuestos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Presupuesto entidad)
        {

            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos.");
            }

            // En vez de var puede ser Presupuesto :D
            var verif = await context.Presupuestos.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (verif == null)
            {
                return NotFound("No existe el presupuesto buscado.");
            }

            verif.Nombre = entidad.Nombre;
            verif.FechaInicioPrevista = entidad.FechaInicioPrevista;
            verif.FechaFinPrevista = entidad.FechaFinPrevista;

            try
            {
                context.Presupuestos.Update(verif);
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
