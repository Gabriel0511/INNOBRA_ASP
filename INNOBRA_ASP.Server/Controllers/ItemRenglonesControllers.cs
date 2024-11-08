using Microsoft.AspNetCore.Mvc;
using INNOBRA_ASP.DB.Data;
using Microsoft.EntityFrameworkCore;
using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.Shared.DTO;
using AutoMapper;
using INNOBRA_ASP.Server.Repositorio;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("Api/ItemRenglones")]
    public class ItemRenglonesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IItemRenglonRepositorio repositorio;

        public ItemRenglonesController(IItemRenglonRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<ItemRenglon>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<ItemRenglon>> GetById(int id)
        {
            var Verif = await repositorio.SelectById(id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearItemRenglonDTO entidadDTO)
        {
            try
            {
                ItemRenglon entidad = mapper.Map<ItemRenglon>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                {
                    if (e.InnerException != null)
                    {
                        return BadRequest($"Error: {e.Message}. Inner Exception: {e.InnerException.Message}");
                    }
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EditarItemRenglonDTO entidadDTO)
        {

            if (id != entidadDTO.Id)
            {
                return BadRequest("Datos incorrectos.");
            }

            var itemRenglon = await repositorio.SelectById(id);

            if (itemRenglon == null)
            {
                return NotFound("No existe la obra buscada.");
            }

            // Actualizar los campos del presupuesto
            itemRenglon.MaterialPrevisto = entidadDTO.MaterialPrevisto;
            itemRenglon.Cantidad = entidadDTO.Cantidad;

            // Aquí no modificamos la relación con 'Obra' ni 'Items', solo los campos mencionados.

            try
            {
                // Guardar los cambios
                await repositorio.Update(id, itemRenglon);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el item renglon: {ex.Message}");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);

            if (!resp)
            {
                return BadRequest("El Item Renglón no se pudo borrar.");

            }
            return Ok();

        }
    }
}
