using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Data;
using TaskOne.Dto;
using TaskOne.Models;


namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArticleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Article>> GetAll()
        {
            var articles = _context.Articles.ToList();
            return Ok(articles);
        }

        [HttpGet("{id}")]

        public ActionResult<Article> GetById(int? id)
        {
            if (id == null)
                return BadRequest(); 
            var article = _context.Articles.FirstOrDefault(x => x.Id == id);
            if (article==null)
                return NotFound();
            return Ok(article);

        }

        [HttpPost]
        public ActionResult Add(ArticleDto article) {
            var artic = new Article()
            {
                Title= article.Title,   
                Content= article.Content,
                PublishedDate= DateTime.Now,
                
            };
            _context.Articles.Add(artic);
            _context.SaveChanges();
            return Ok("Article has Added");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var artic = _context.Articles.Find(id); 
            if (artic==null)
                return NotFound();
            _context.Articles.Remove(artic);
            _context.SaveChanges();
            return Ok("Article has Deleted"); 

        }
        [HttpPut]
        public ActionResult Edit(int id , ArticleDto articleDto)
        {
            var arc = _context.Articles.Find(id);
            if (arc is null)
                return NotFound();
            arc.Title = articleDto.Title;
            arc.Content = articleDto.Content;
            _context.Update(arc);
            _context.SaveChanges();
            return Ok("Article has Upadated"); 
        }

    }
}
