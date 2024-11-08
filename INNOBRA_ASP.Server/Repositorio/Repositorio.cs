using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using INNOBRA_ASP.DB.Data;

namespace INNOBRA_ASP.Server.Repositorio
{ 
    public class Repositorio<E> : IRepositorio<E> where E: class, IEntityBase
    {
        private readonly Context context;

        public Repositorio(Context context)
        {
            this.context = context;
        }

        public async Task<bool> Existe(int id)
        {
            var existe = await context.Set<E>()
                             .AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E> SelectById(int id)
        {
            E? sel = await context.Set<E>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return sel;
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(int id, E entidad)
        {
            if (id != entidad.Id)
            {
                return false;
            }

            var EntidadExistente = await SelectById(id);

            if (EntidadExistente == null)
            {
                return false;
            }

            try
            {
                context.Set<E>().Update(entidad);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entidad = await SelectById(id);

            if (entidad == null)
            {
                return false;
            }

            context.Set<E>().Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarObraConPresupuestosYItems(int id)
        {
            var obra = await context.Obras
                .Include(o => o.Presupuestos)
                    .ThenInclude(p => p.Items) // Incluir los Items de cada Presupuesto
                .FirstOrDefaultAsync(o => o.Id == id);

            if (obra == null)
            {
                return false; // Si la obra no existe, retornar falso
            }

            // Eliminar Items asociados a cada Presupuesto
            foreach (var presupuesto in obra.Presupuestos)
            {
                context.Items.RemoveRange(presupuesto.Items);
            }

            // Eliminar Presupuestos asociados
            context.Presupuestos.RemoveRange(obra.Presupuestos);

            // Eliminar la Obra
            context.Obras.Remove(obra);

            // Guardar cambios en la base de datos
            await context.SaveChangesAsync();

            return true; // Retornar true si se eliminó correctamente
        }

    }
}
