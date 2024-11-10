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
    [Route("Api/Presupuestos")]
    public class PresupuestosControllers : ControllerBase
    {
        private readonly IPresupuestoRepositorio repositorio;
        private readonly IMapper mapper;

        public PresupuestosControllers(IPresupuestoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<Presupuesto>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{id:int}")] //api/Presupuesto/2
        public async Task<ActionResult<Presupuesto>> GetById(int id)
        {
            var Verif = await repositorio.SelectById(id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")] //api/Presupuesto/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPresupuestoDTO entidadDTO)
        {
            try
            {
                Presupuesto entidad = mapper.Map<Presupuesto>(entidadDTO);

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
        public async Task<ActionResult> Put(int id, [FromBody] EditarPresupuestoDTO entidadDTO)
        {
            if (id != entidadDTO.Id)
            {
                return BadRequest("Datos incorrectos.");
            }

            // Obtener el presupuesto existente
            var presupuesto = await repositorio.SelectById(id);
            if (presupuesto == null)
            {
                return NotFound("No existe el presupuesto buscado.");
            }

            // Actualizar los campos del presupuesto
            presupuesto.Nombre = entidadDTO.Nombre;
            presupuesto.FechaInicioPrevista = entidadDTO.FechaInicioPrevista;
            presupuesto.FechaFinPrevista = entidadDTO.FechaFinPrevista;

            // Aquí no modificamos la relación con 'Obra' ni 'Items', solo los campos mencionados.

            try
            {
                // Guardar los cambios
                await repositorio.Update(id, presupuesto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el presupuesto: {ex.Message}");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            // Llamar al método de eliminación en cascada en el repositorio
            var resp = await repositorio.EliminarPresupuestosYItems(id);

            if (!resp)
            {
                return BadRequest("El presupuesto no se pudo borrar.");
            }
            return Ok();
        }

    }
}
