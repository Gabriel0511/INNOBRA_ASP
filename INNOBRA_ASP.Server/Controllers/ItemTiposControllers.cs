using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("api/Unidades")]
    public class ItemTiposControllers : ControllerBase
    {
        private readonly Context context;
        public ItemTiposControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemTipo>>> get()
        {
            return await context.ItemTipos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ItemTipo entidad)
        {
            try
            {
                context.ItemTipos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/ItemTipos/2
        public async Task<ActionResult> Put(int Id, [FromBody] ItemTipo entidad)
        {
            if (Id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await context.ItemTipos
                .Where(e => e.Id == Id).FirstOrDefaultAsync();

            if (Verif == null)
            {
                return NotFound("No existe el Item buscado.");
            }

            Verif. = entidad.Codigo;
            Verif.Nombre = entidad.Nombre;
            Verif.Unidad_Id = entidad.Unidad_Id;


            try
            {
                context.ItemTipos.Update(Verif);
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