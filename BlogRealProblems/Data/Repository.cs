using BlogRealProblems.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogRealProblems.Models
{
    public class Repository
    {

        public ApplicationContext context;

        public Repository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Noticia> AddNoticia(Noticia noticia)
        {
            try
            {
                if (noticia == null) throw new ArgumentNullException(nameof(noticia));
                await context.Set<Noticia>().AddAsync(noticia);
                await context.SaveChangesAsync();
                var noticiaResultado = await context.Noticias.FirstOrDefaultAsync(f => f.Id == noticia.Id);
                if (noticiaResultado == null) throw new Exception("Nova NotÍcia não encontrada");
                return noticiaResultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Noticia> DeleteNoticia(int id)
        {
            try
            {
                Noticia noticia = GetNoticiaById(id);
                if (noticia == null) throw new Exception("Nova NotÍcia não encontrada");
                context.Noticias.Remove(noticia);
                context.SaveChanges();
                Noticia noticiaResultado = GetNoticiaById(id);
                if (noticiaResultado != null) throw new Exception("Nova não foi deletada");
                return noticia;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Noticia GetNoticiaById(int id)
        {
            try
            {
                Noticia noticia = context.Noticias.FirstOrDefault(f => f.Id == id);
                if (noticia == null) throw new Exception("Noticia não encontrada");
                return noticia;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Noticia> GetNoticias()
        {
            try
            {
                IEnumerable<Noticia> noticias = context.Noticias;
                return noticias;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
