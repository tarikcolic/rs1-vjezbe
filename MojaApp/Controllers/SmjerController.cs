using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MojaApp.DTOs;
using MojaApp.Models;
using WebApplication1.Data;

namespace MojaApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmjerController (AppDbContext db) : Controller
    {
            [HttpGet]
            public async Task<List<SmjerResponse>> GetAll(CancellationToken ct)
            {
                IQueryable<Smjer> upit = db.Smjerovi;
                return await upit.OrderBy(x => x.Naziv).Select(x => new SmjerResponse
                {
                    Id = x.Id,
                    Naziv = x.Naziv
                }).ToListAsync(ct);
            }
    }
}
