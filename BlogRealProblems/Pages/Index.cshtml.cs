using BlogRealProblems.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRealProblems.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Repository _repository;

        public IEnumerable<Noticia> Noticias { get; }

        public IndexModel(Repository repository, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _repository = repository;
            Noticias = _repository.GetNoticias();
        }

        public void OnGet()
        {
        }

        //public IEnumerable<Noticia> OnGetAsync()
        //{
        //     return _repository.GetNoticias();
        //}
    }
}

