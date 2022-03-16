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
    public class BusinessController : ControllerBase
    {
        private readonly YellowPageDb _context;
        public readonly IMapper _mapper;
        public BusinessController(YellowPageDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusiness(string? filterTerm)
        {
            return await _context.Business
            .Include(b => b.Contact.Location)
            .Where(b => filterTerm == null ? true :
                           b.Name.Contains(filterTerm)
                        || b.Contact.Email.Contains(filterTerm)
                        || b.Contact.PhoneNumber.Contains(filterTerm)
                        || b.Contact.Location.Country.Contains(filterTerm)
                        || b.Contact.Location.City.Contains(filterTerm)
                        || b.Contact.Location.Address.Contains(filterTerm)
                        || b.Contact.Location.ZipCode.Contains(filterTerm))
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetBusiness(int id)
        {
            var targetBusiness = await getTargetBusinessQuery(id).SingleOrDefaultAsync();

            if (targetBusiness == null)
            {
                return NotFound();
            }

            return Ok(targetBusiness);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(int id, BusinessRequestDto request)
        {
            var targetBusiness = await getTargetBusinessQuery(id).SingleOrDefaultAsync();

            if (targetBusiness == null)
            {
                return NotFound();
            }
            _mapper.Map(request, targetBusiness);
            _context.Entry(targetBusiness).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return Problem();
            }

            return Ok(targetBusiness);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Business>> PostBusiness(BusinessRequestDto request)
        {
            var mappedBussiness = _mapper.Map<Business>(request);
            var newBusiness = _context.Business.Add(mappedBussiness).Entity;
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBusiness), new { id = newBusiness.Id }, newBusiness);
        }

        // DELETE: api/Business/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteBusiness(int id)
        {
            var targetBusiness = await getTargetBusinessQuery(id).SingleOrDefaultAsync();

            if (targetBusiness == null)
            {
                return NoContent();
            }

            _context.Entry(targetBusiness).State = EntityState.Deleted;
            _context.Entry(targetBusiness.Contact).State = EntityState.Deleted;
            _context.Entry(targetBusiness.Contact.Location).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private IQueryable<Business> getTargetBusinessQuery(int id) => _context.Business
                .Include(b => b.Contact.Location)
                .Where(b => b.Id == id);
    }
}
