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

        [HttpGet("GetById/{id:int}")] //api/Recurso/2
        public async Task<ActionResult<Recurso>> GetById(int id)
        {
            var Verif = await context.Recursos.FirstOrDefaultAsync(x => x.Id == id);
            if(Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("GetByNom/{nom}")] //api/Recurso/2
        public async Task<ActionResult<Recurso>> GetByNom(string nom)
        {
            var Verif = await context.Recursos.FirstOrDefaultAsync(x => x.Nombre == nom);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
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
                .Where(reg => reg.Id == Id).FirstOrDefaultAsync();

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

        [HttpDelete("{id:int}")] //api/Recurso/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Recursos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($" El recurso {id} no existe.");
            }

            Recurso EntidadABorrar = new Recurso();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}