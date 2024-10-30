using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.DB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using INNOBRA_ASP.Shared.DTO;
using INNOBRA_ASP.Server.Repositorio;
using ItemTipoRenglon = INNOBRA_ASP.DB.Data.Entity.ItemTipoRenglon; //Me recomendo usar este using

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("api/ItemTipoRenglon")]
    public class ItemTiposRenglonControllers : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepositorio<ItemTipoRenglon> repositorio;

        public ItemTiposRenglonControllers(IItemTipoRenglonRepositorio repositorio, IMapper mapper)
        {
            this.mapper = mapper;
            this.repositorio = (IRepositorio<ItemTipoRenglon>?)repositorio;//Le agregue que acepte nulos por que me daba error
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemTipoRenglon>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ItemTipoRenglon>> Get(int id)
        {
            ItemTipoRenglon? sel = await repositorio.SelectById(id);
            if (sel == null)
            {
                return NotFound();
            }
            return sel;
        }

        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Posts(CrearItemRenglonTipoDTO entidadDTO)
        {
            try
            {
                ItemTipoRenglon entidad = mapper.Map<ItemTipoRenglon>(entidadDTO);
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
        public async Task<ActionResult> Put(int id, [FromBody] ItemTipoRenglon entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var sel = await repositorio.SelectById(id);
            if (sel == null)
            {
                return NotFound("El item no existe.");
            }

            mapper.Map(entidad, sel);

            try
            {
                var actualizado = await repositorio.Update(id, sel);
                if (actualizado)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se pudo actualizar los datos.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"El Item {id} no existe");
            }

            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}