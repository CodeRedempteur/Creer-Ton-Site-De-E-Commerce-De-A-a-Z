using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mercure.CoreServiceApi.Context;
using Mercure.Data.Cards;
namespace Mercure.CoreServiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController :ControllerBase
    {
        private readonly CardWebsiteContext _context;
        public TestsController(CardWebsiteContext context)
        {
            _context = context;
        }

        //Get api/test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Test>>> GetTests()
        {
            return await _context.Tests.ToListAsync();
        }
    }
}
