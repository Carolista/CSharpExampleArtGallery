using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworksController : ControllerBase
    {
        private readonly ArtworkDbContext _context;

        public ArtworksController(ArtworkDbContext context)
        {
            _context = context;
        }

        // GET: api/ArtworkApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtworkDTO>>> GetArtworks()
        {
            return await _context
                .Artworks.Include(a => a.Artist)
                .Include(a => a.Categories)
                .Include(a => a.Details)
                .Select(a => new ArtworkDTO(a))
                .ToListAsync();
        }

        // GET: api/ArtworkApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtworkDTO>> GetArtwork(int id)
        {
            var artwork = await _context
                .Artworks.Include(a => a.Artist)
                .Include(a => a.Categories)
                .Include(a => a.Details)
                .SingleAsync(a => id == a.Id);

            if (artwork == null)
            {
                return NotFound();
            }

            return new ArtworkDTO(artwork);
        }
    }
}
