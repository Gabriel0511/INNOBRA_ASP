using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("api/Recursos")]
    public class RecursosControllers : ControllerBase
    {
        private readonly Context context;
        public RecursosControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recurso>>> get()
        {
            return await context.Recursos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Recurso entidad)
        {
            try
            {
                context.Recursos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Recurso/2
        public async Task<ActionResult> Put(int Id, [FromBody] Recurso entidad)
        {
            if (Id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var Verif = await context.Recursos
                .Where(e => e.Id == Id).FirstOrDefaultAsync();

            if (Verif == null)
            {
                return NotFound("No existe el recurso buscado.");
            }

            Verif.Tipo = entidad.Tipo;
            Verif.Nombre = entidad.Nombre;
            Verif.Cantidad = entidad.Cantidad;
            Verif.UnidadMedida = entidad.UnidadMedida;

            try
            {
                context.Recursos.Update(Verif);
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