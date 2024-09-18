using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.DB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("api/ItemTipoRenglon")]
    public class ItemTiposRenglonControllers : ControllerBase
    {
        private readonly Context context;
        public ItemTiposRenglonControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemTipoRenglon>>> get()
        {
            return await context.ItemTipoRenglones.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(ItemTipoRenglon entidad)
        {
            try
            {
                context.ItemTipoRenglones.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/ItemTipoRenglon/2
        public async Task<ActionResult> Put(int Id, [FromBody] ItemTipoRenglon entidad)
        {
            if (Id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await context.ItemTipoRenglones
                .Where(e => e.Id == Id).FirstOrDefaultAsync();

            if (Verif == null)
            {
                return NotFound("No existe el renglon buscado.");
            }

            Verif.Item_Tipos_Id = entidad.Item_Tipos_Id;
            Verif.Item = entidad.Item;
            Verif.Recurso_Id = entidad.Recurso_Id;
            Verif.recurso = entidad.recurso;


            try
            {
                context.ItemTipoRenglones.Update(Verif);
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