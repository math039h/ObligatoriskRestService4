using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatoriskBibloteksProject;

namespace ObligatoriskRestService.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Bog> Books = new List<Bog>() {
            new Bog("titel", "forfatter", 20, "1234567891113"),
            new Bog("der var engang", "mikkel", 25, "2234567891113"),
            new Bog("søen", "olsen", 28, "3234567891113"),
            new Bog("koen", "thomsen", 22, "4234567891113")
        };
        // GET: api/Books
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return Books;
        }

        // GET: api/Books/5
        [HttpGet("{isbn}", Name = "Get")]
        public Bog Get(string isbn)
        {
            return Books.Find(b => b.Lsbn13 == isbn);
        }

        // POST: api/Books
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            Books.Add(value);
        }

        // PUT: api/Books/5
        [HttpPut("{isbn}")]
        public void Put(string isbn, [FromBody] Bog value)
        {
            Bog bb = Books.Find(b => b.Lsbn13 == isbn);
            bb.Titel = value.Titel;
            bb.Forfatter = value.Forfatter;
            bb.SideTal = value.SideTal;
            bb.Lsbn13 = value.Lsbn13;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
            Books.Remove(Books.Find(b => b.Lsbn13 == isbn));
        }
    }
}
