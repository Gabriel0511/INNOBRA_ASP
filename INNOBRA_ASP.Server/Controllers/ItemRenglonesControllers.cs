using Microsoft.AspNetCore.Mvc;
using INNOBRA_ASP.DB.Data;
using Microsoft.EntityFrameworkCore;
using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.Shared.DTO;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("Api/ItemRenglones")]
    public class ItemRenglonesController : ControllerBase
    {
        private readonly Context context;

        public ItemRenglonesController(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<ItemRenglon>>> Get()
        {
            return await context.ItemRenglones.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ItemRenglon entidad)
        {
            try
            {
                context.ItemRenglones.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ItemRenglon entidad)
        {

            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos.");
            }

            var verif = await context.ItemRenglones.Where(e => e.Id == id).FirstOrDefaultAsync();

            if (verif == null)
            {
                return NotFound("No existe la obra buscada.");
            }

            verif.MaterialPrevisto = entidad.MaterialPrevisto;
            verif.Cantidad = entidad.Cantidad;

            try
            {
                context.ItemRenglones.Update(verif);
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
