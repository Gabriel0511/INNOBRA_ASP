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
    [Route("Api/Obras")]
    public class ObrasControllers : ControllerBase
    {
        private readonly IObraRepositorio repositorio;
        private readonly IMapper mapper;

        public ObrasControllers(IObraRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<Obra>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{id:int}")] //api/Obra/2
        public async Task<ActionResult<Obra>> GetById(int id)
        {
            var Verif = await repositorio.SelectById(id);
            if (Verif == null)
            {
                return NotFound();
            }
            return Verif;
        }

        [HttpGet("existe/{id:int}")] //api/Obra/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearObraDTO entidadDTO)
        {
            try
            {
                // Mapear el DTO a la entidad de base de datos
                var entidad = mapper.Map<Obra>(entidadDTO);

                // Insertar la entidad en la base de datos
                var id = await repositorio.Insert(entidad);

                return CreatedAtAction(nameof(Post), new { id }, id);
            }
            catch (Exception e)
            {
                // Manejo de excepciones más limpio
                var errorMessage = e.InnerException != null
                    ? $"Error: {e.Message}. Inner Exception: {e.InnerException.Message}"
                    : e.Message;

                return BadRequest(errorMessage);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] EditarObraDTO entidadDTO)
        {

            if (id != entidadDTO.Id)
            {
                return BadRequest("Datos incorrectos.");
            }

            var obra = await repositorio.SelectById(id);

            if (obra == null)
            {
                return NotFound("No existe la obra buscada.");
            }

            // Actualizar los campos del presupuesto
            obra.Nombre = entidadDTO.Nombre;
            obra.FechaInicio = entidadDTO.FechaInicio;
            obra.FechaFin = entidadDTO.FechaFin;
            obra.Imagen = entidadDTO.Imagen;

            // Aquí no modificamos la relación con 'Obra' ni 'Items', solo los campos mencionados.

            try
            {
                // Guardar los cambios
                await repositorio.Update(id, obra);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar la obra: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            // Llamar al método de eliminación en cascada en el repositorio
            var resp = await repositorio.EliminarObraConPresupuestosYItems(id);

            if (!resp)
            {
                return BadRequest("La obra no se pudo borrar.");
            }
            return Ok();
        }

    }
}