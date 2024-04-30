using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }
        //当 OnGet 返回 void 或 OnGetAsync 返回 Task 时，不使用任何返回语句。 当返回类型是 IActionResult 或
        //Task<IActionResult> 时，必须提供返回语句
        //这里是数据查询界面，不需要作跳转页面操作，但在添加页面，添加完成后需要跳转到数据查询展示页面
        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet =true)]
        public string SearchString {  get; set; }
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet =true)]
        public string MovieGenre {  get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery= from m in _context.Movie
                                           orderby m.Genre
                                           select m.Genre;

            var movies=from m in _context.Movie select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if(!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres=new SelectList(await genreQuery.Distinct().ToListAsync());
            if (_context.Movie != null)
            {
                Movie = await movies.ToListAsync();
            }
        }
    }
}
