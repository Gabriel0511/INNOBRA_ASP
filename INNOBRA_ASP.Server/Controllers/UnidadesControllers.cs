using AutoMapper;
using INNOBRA_ASP.Shared.DTO;
using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.Server.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("api/Unidades")]
    public class UnidadesControllers : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUnidadRepositorio repositorio;

        public UnidadesControllers(IMapper mapper, IUnidadRepositorio repositorio)
        {
            this.mapper = mapper;
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Unidad>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Unidad>> Get(int id)
        {
            Unidad? sel = await repositorio.SelectById(id);
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
        public async Task<ActionResult<int>> Posts(CrearUnidadDTO entidadDTO)
        {
            try
            {
                Unidad entidad = mapper.Map<Unidad>(entidadDTO);
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
        public async Task<ActionResult> Put(int id, [FromBody] EditarUnidadDTO entidadDTO)
        {


            try
            {
                Unidad entidad = mapper.Map<Unidad>(entidadDTO);
                await repositorio.Update(entidad.Id, entidad);
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }

            
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);
            if (!existe)
            {
                return NotFound($"La unidad {id} no existe");
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
