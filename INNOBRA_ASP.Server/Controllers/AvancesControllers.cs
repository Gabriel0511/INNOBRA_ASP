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
    [Route("api/Avances")]
    public class AvancesControllers : ControllerBase
    {
        private readonly IAvanceRepositorio repositorio;
        private readonly IMapper mapper;
        public AvancesControllers(IAvanceRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Avance>>> get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{id:int}")] //api/Avances/2
        public async Task<ActionResult<Avance>> GetById(int id)
        {
            var Verif = await repositorio.SelectById(id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")] //api/Avances/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearAvanceDTO entidadDTO)
        {
            try
            {
                Avance entidad = mapper.Map<Avance>(entidadDTO);
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

        [HttpPut("{Id:int}")] //api/Avances/2
        public async Task<ActionResult> Put(int Id, [FromBody] EditarAvanceDTO entidadDTO)
        {
            try
            {
                Avance entidad = mapper.Map<Avance>(entidadDTO);

                await repositorio.Update(entidad.Id, entidad);
                return Ok();
                //return Ok(new { message = "Actualización exitosa" });
            }

            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Avances/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);

            if (!resp)
            {
                return BadRequest("El avance no se pudo borrar");

            }
            return Ok();

        }
    }
}

