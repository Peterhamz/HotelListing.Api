using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Api.Data;
using HotelListing.Api.Contracts_IRepository_;
using HotelListing.Api.Models.Hotel;
using AutoMapper;

namespace HotelListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepository hotelsRepository;
        private readonly IMapper mapper;

        public HotelsController(IHotelsRepository hotelsRepository, IMapper mapper)
        {
            this.hotelsRepository = hotelsRepository;
            this.mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> Gethotels()
        {
            var hotel = await hotelsRepository.GetAllAsync();
            return Ok(mapper.Map<List<HotelDto>>(hotel));
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<HotelDto>(hotel));
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto hotelDto)
        {
            if (id != hotelDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(hotel).State = EntityState.Modified;
            var hotel = await hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            mapper.Map(hotelDto, hotel);

            try
            {
                await hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotelDto)
        {
            var hotel = mapper.Map<Hotel>(createHotelDto);
            await hotelsRepository.AddAsync(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await hotelsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await hotelsRepository.Exists(id);
        }
    }
}
