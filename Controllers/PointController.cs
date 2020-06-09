using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLW.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace NLW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PointController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public PointController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] string city, string uf, string itens)
        {

            var arrayItens = itens
                                .Split(",")
                                .Select(x => int.Parse(x))
                                .ToList();



            var points = await _db.PointItems
                                  .Include(pointItems => pointItems.Points)
                                  .Where(pointItems => arrayItens.Contains(pointItems.Item_id))
                                  .Where(pointItems => pointItems.Points.City.Equals(city))
                                  .Where(pointItems => pointItems.Points.Uf.Equals(uf))
                                  .Select(pointItems => pointItems.Points)
                                  .ToListAsync();


            return Ok(points);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var point = await _db.Points.Where(point => point.Id.Equals(id)).FirstOrDefaultAsync();

            if (point != null)
            {
                return NotFound("Point not found");
            }


            var intes = await _db.PointItems
                                  .Include(pointItems => pointItems.Items)
                                  .Where(pointItems => pointItems.Points.Id.Equals(id))
                                  .Select(pointItems => pointItems.Items)
                                  .ToListAsync();

            return Ok(new
            {
                point,
                intes
            });

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Point newPoint)
        {
            if (ModelState.IsValid)
            {
                var point = new Point
                {
                    Name = newPoint.Name,
                    Email = newPoint.Email,
                    Whatsapp = newPoint.Whatsapp,
                    Latidude = newPoint.Latidude,
                    Longitude = newPoint.Longitude,
                    City = newPoint.City,
                    Uf = newPoint.Uf,
                    Image = newPoint.Image,
                };

                await _db.Points.AddAsync(point);
                await _db.SaveChangesAsync();

                foreach (var item in newPoint.IntesId)
                {
                    var pointItems = new PointItems
                    {
                        Point_id = point.Id,
                        Item_id = item
                    };

                    await _db.PointItems.AddAsync(pointItems);
                }

               await _db.SaveChangesAsync();
            }

            return BadRequest(ModelState.IsValid);
        }
    }
}