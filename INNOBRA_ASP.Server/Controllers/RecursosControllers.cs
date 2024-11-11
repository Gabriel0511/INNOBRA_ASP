using INNOBRA_ASP.DB.Data;
using INNOBRA_ASP.DB.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INNOBRA_ASP.Shared.DTO;
using AutoMapper;
using INNOBRA_ASP.Server.Repositorio;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("api/Recursos")]
    public class RecursosControllers : ControllerBase
    {
        private readonly IRecursoRepositorio repositorio;
        private readonly IMapper mapper;
        public RecursosControllers(IRecursoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recurso>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{id:int}")] //api/Avance/2
        public async Task<ActionResult<Recurso>> GetById(int id)
        {
            var Verif = await repositorio.SelectById(id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")] //api/Recursos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearRecursoDTO entidadDTO)
        {
            try
            {
                Recurso entidad = mapper.Map<Recurso>(entidadDTO);
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPut("{Id:int}")] //api/Recursos/2
        public async Task<ActionResult> Put(int Id, [FromBody] EditarRecursoDTO entidadDTO)
        {
            try
            {
                // Aquí mapeas el DTO a la entidad Recurso
                Recurso entidad = mapper.Map<Recurso>(entidadDTO);

                // Revisa que la entidad tenga el ID correcto antes de actualizar
                if (entidad.Id != Id)
                {
                    return BadRequest("El ID del recurso no coincide.");
                }

                await repositorio.Update(entidad.Id, entidad); // Asegúrate de que este método funcione correctamente
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException?.Message ?? e.Message);
            }
        }


        [HttpDelete("{id:int}")] //api/Recursos/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);

            if (!resp)
            {
                return BadRequest("El Recurso no se pudo borrar");

            }
            return Ok();

        }
    }
}

