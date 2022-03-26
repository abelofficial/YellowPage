using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YellowPage.Api.Data;
using YellowPage.Api.Dtos;
using YellowPage.Api.Models;

namespace YellowPage.Api.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson(string? filterTerm)
        {
            return await _context.Person
            .Include(p => p.Contact.Location)
            .Where(p => filterTerm == null ? true :
                           p.FirstName.Contains(filterTerm)
                        || p.LastName.Contains(filterTerm)
                        || p.Contact.Email.Contains(filterTerm)
                        || p.Contact.PhoneNumber.Contains(filterTerm)
                        || p.Contact.Location.Country.Contains(filterTerm)
                        || p.Contact.Location.City.Contains(filterTerm)
                        || p.Contact.Location.Address.Contains(filterTerm)
                        || p.Contact.Location.ZipCode.Contains(filterTerm))
            .ToListAsync();
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
            mappedPerson.AddedBy = _context.User.Find(Int32.Parse(User.Identity.Name));
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
