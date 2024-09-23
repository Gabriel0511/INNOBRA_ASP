using Microsoft.AspNetCore.Mvc;
using INNOBRA_ASP.DB.Data;
using Microsoft.EntityFrameworkCore;
using INNOBRA_ASP.DB.Data.Entity;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("Api/Items")]
    public class ItemsControllers : ControllerBase
    {
        private readonly Context context;

        public ItemsControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Item>>> Get()
        {
            return await context.Items.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Item entidad)
        {
            try
            {
                context.Items.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Item entidad)
        {

            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos.");
            }

            var verif = await context.Items.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (verif == null)
            {
                return NotFound("No existe la obra buscada.");
            }

            verif.Tiempo_estimado = entidad.Tiempo_estimado;
            verif.Material_estimado = entidad.Material_estimado;

            try
            {
                context.Items.Update(verif);
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