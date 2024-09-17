using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("api/Avances")]
    public class AvancesControllers : ControllerBase
    {
        private readonly Context context;
        public AvancesControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Avance>>> get()
        {
            return await context.Avances.ToListAsync();
        }

        [HttpGet("GetById/{id:int}")] //api/Avance/2
        public async Task<ActionResult<Avance>> GetById(int id)
        {
            var Verif = await context.Avances.FirstOrDefaultAsync(x => x.Id == id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Avance entidad)
        {
            try
            {
                context.Avances.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Avance/2
        public async Task<ActionResult> Put(int Id, [FromBody] Avance entidad)
        {
            if (Id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await context.Avances
                .Where(reg => reg.Id == Id).FirstOrDefaultAsync();

            if (Verif == null)
            {
                return NotFound("No existe el avance buscado.");
            }

            Verif.Fecha = entidad.Fecha;
            Verif.MaterialEjecutado = entidad.MaterialEjecutado;
            Verif.FechaFinalizacionReal = entidad.FechaFinalizacionReal;

            try
            {
                context.Avances.Update(Verif);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Avance/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Avances.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($" El avance {id} no existe.");
            }

            Avance EntidadABorrar = new Avance();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
