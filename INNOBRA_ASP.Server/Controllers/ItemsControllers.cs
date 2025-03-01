﻿using Microsoft.AspNetCore.Mvc;
using INNOBRA_ASP.DB.Data;
using Microsoft.EntityFrameworkCore;
using INNOBRA_ASP.DB.Data.Entity;
using INNOBRA_ASP.Shared.DTO;
using AutoMapper;
using INNOBRA_ASP.Server.Repositorio;

namespace INNOBRA_ASP.Server.Controllers
{
    [ApiController]
    [Route("Api/Items")]
    public class ItemsControllers : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IItemRepositorio repositorio;

        public ItemsControllers(IItemRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<List<Item>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("GetById/{id:int}")] 
        public async Task<ActionResult<Item>> GetById(int id)
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
        public async Task<ActionResult<int>> Post(CrearItemDTO entidadDTO)
        {
            try
            {
                Item entidad = mapper.Map<Item>(entidadDTO);

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
        public async Task<ActionResult> Put(int id, [FromBody] EditarItemDTO entidadDTO)
        {

			if (id != entidadDTO.Id)
			{
				return BadRequest("Datos incorrectos.");
			}

			var item = await repositorio.SelectById(id);

			if (item == null)
			{
				return NotFound("No existe la obra buscada.");
			}

			// Actualizar los campos del presupuesto
			item.Tiempo_estimado = entidadDTO.Tiempo_estimado;
            item.Unidad_Tiempo = entidadDTO.Unidad_Tiempo;
            item.Material_estimado = entidadDTO.Material_estimado;
            item.Item_Tipos_Id = entidadDTO.Item_Tipos_Id;

            // Aquí no modificamos la relación con 'Obra' ni 'Items', solo los campos mencionados.

            try
			{
				// Guardar los cambios
				await repositorio.Update(id, item);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest($"Error al actualizar el item: {ex.Message}");
			}

		}

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);

            if (!resp)
            {
                return BadRequest("El Item no se pudo borrar");

            }
            return Ok();

        }
    }
}