using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YellowPage.Api.Dtos;
using YellowPage.Api.Models;

namespace YellowPage.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly YellowPageDb _context;
        public readonly IMapper _mapper;

        public PersonController(YellowPageDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            return await _context.Person.Include(b => b.Contact.Location).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var targetPerson = await getTargetPersonQuery(id).SingleOrDefaultAsync();

            if (targetPerson == null)
            {
                return NotFound();
            }

            return Ok(targetPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, PersonRequestDto request)
        {
            var targetPerson = await getTargetPersonQuery(id).SingleOrDefaultAsync();

            if (targetPerson == null)
            {
                return BadRequest();
            }

            _mapper.Map(request, targetPerson);
            _context.Entry(targetPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Problem();
            }
            return Ok(targetPerson);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Person>> PostPerson(PersonRequestDto request)
        {
            var mappedPerson = _mapper.Map<Person>(request);
            var newPerson = _context.Person.Add(mappedPerson).Entity;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPerson), new { id = newPerson.Id }, newPerson);
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var targetPerson = await getTargetPersonQuery(id).SingleOrDefaultAsync();

            if (targetPerson == null)
            {
                return NoContent();
            }

            _context.Entry(targetPerson).State = EntityState.Deleted;
            _context.Entry(targetPerson.Contact).State = EntityState.Deleted;
            _context.Entry(targetPerson.Contact.Location).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private IQueryable<Person> getTargetPersonQuery(int id) => _context.Person
                .Include(p => p.Contact.Location)
                .Where(p => p.Id == id);
    }
}
