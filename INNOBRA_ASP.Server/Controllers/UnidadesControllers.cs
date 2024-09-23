using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("api/Unidades")]
    public class UnidadesControllers : ControllerBase
    {
        private readonly Context context;
        public UnidadesControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Unidad>>> get()
        {
            return await context.Unidades.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Unidad entidad)
        {
            try
            {
                context.Unidades.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Unidad/2
        public async Task<ActionResult> Put(int Id, [FromBody] Unidad entidad)
        {
            if (Id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await context.Unidades
                .Where(e => e.Id == Id).FirstOrDefaultAsync();

            if (Verif == null)
            {
                return NotFound("No existe la unidad buscada.");
            }

            Verif.Codigo = entidad.Codigo;
            Verif.Nombre = entidad.Nombre;
            

            try
            {
                context.Unidades.Update(Verif);
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
