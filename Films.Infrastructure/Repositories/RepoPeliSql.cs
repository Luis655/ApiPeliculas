using ApiLibros.Domain.Data;
using Microsoft.EntityFrameworkCore;


namespace ApiLibros.Libros.Infrastructure.Repositories
{
    public class RepoPeliSql
    {
        

        public IEnumerable<Datospelicula> GetAll()
        {
            var _context = new PELICULAContext();
            var query = _context.Datospeliculas.Select(Datospelicula=>Datospelicula);
            return query;
        }

         public Datospelicula GetById(int id)
        {
            var _context = new PELICULAContext();
            var query = _context.Datospeliculas.FirstOrDefault(Datospelicula => Datospelicula.Idpelicula ==id);
            return query;
        }

        public IEnumerable<Datospelicula> GetByGenero(string genero)
        {
            var _context = new PELICULAContext();
            
            var query =  _context.Datospeliculas.Where(Datospelicula => Datospelicula.Genero==genero);
            return query;
        }

        public async Task<int> Create(Datospelicula datospelicula)
        {
           var _context = new PELICULAContext();
           var entity = datospelicula;
           await _context.AddAsync(entity);
           var rows = await _context.SaveChangesAsync();
            
            if (rows <= 0)
                throw new Exception("no se pudo registrar");
            
            return entity.Idpelicula;
        }


         public async Task<bool> Update(int id, Datospelicula datospelicula)
        {
            var _context = new PELICULAContext();
            if(id <= 0 || datospelicula == null)
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");

            var entity =  GetById(id);

            entity.Titulo = datospelicula.Titulo;
            entity.Director = datospelicula.Director;
            entity.Genero = datospelicula.Genero;
            entity.Puntuacion = datospelicula.Puntuacion;
            entity.Rating = datospelicula.Rating;
            entity.Fechalanzamiento = datospelicula.Fechalanzamiento;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }


        public async Task<bool> Delete(int id)
        {
            var _context = new PELICULAContext();
            var entity = GetById(id);
            _context.Remove(entity);


            var rows =await _context.SaveChangesAsync();

            return rows >0;
        }
    }
}