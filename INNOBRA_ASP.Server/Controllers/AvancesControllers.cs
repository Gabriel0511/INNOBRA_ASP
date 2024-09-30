using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INNOBRA_ASP.Shared.DTO;

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

        [HttpPut("{id:int}")] //api/Avances/2
        public async Task<ActionResult> Put(int Id, [FromBody] Avance entidad)
        {
            if (Id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await context.Avances
                .Where(e => e.Id == Id).FirstOrDefaultAsync();

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
    }
}
