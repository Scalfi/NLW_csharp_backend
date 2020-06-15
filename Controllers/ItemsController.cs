using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLW.Models.Database;
using static System.Net.Mime.MediaTypeNames;

namespace NLW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly DatabaseContext _db;
        public ItemsController(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> GetAsync()
        {

            var arrayItens = await _db.Items
                                    .Select(item => new
                                    {
                                        id = item.Id,
                                        title = item.Title,
                                        image = item.Image
                                    })
                                    .ToListAsync();

            return Ok(arrayItens);
        }

    }
}