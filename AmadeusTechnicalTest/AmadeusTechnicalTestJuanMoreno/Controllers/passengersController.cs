using AmadeusTechnicalTestJuanMoreno.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmadeusTechnicalTestJuanMoreno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class passengersController : ControllerBase
    {
        private readonly passengerContex _contex;

        public passengersController(passengerContex contex)
        {
            _contex = contex;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreatePassanger(passenger passenger)
        {
            await _contex.passengers.AddAsync(passenger);
            await _contex.SaveChangesAsync();
            return Ok(passenger); // Devuelve el pasajero creado
        }

        [HttpGet]
        [Route("Read")]
        public async Task<ActionResult<IEnumerable<passenger>>> passengerList()
        {
            var passengers = await _contex.passengers.ToListAsync();
            return Ok(passengers);
        }

        [HttpGet]
        [Route("ReadDetails/{id:int}")]
        public async Task<IActionResult> PassengerDetails(int id)
        {
            var passenger = await _contex.passengers.FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }
            return Ok(passenger);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdatePassenger(int id, passenger passenger)
        {
            var existingPassenger = await _contex.passengers.FindAsync(id);

            if (existingPassenger == null)
            {
                return NotFound();
            }

            existingPassenger.Firstname = passenger.Firstname;
            existingPassenger.Lastname = passenger.Lastname;
            existingPassenger.Age = passenger.Age;
            existingPassenger.Departure = passenger.Departure;
            existingPassenger.Arrival = passenger.Arrival;

            await _contex.SaveChangesAsync();

            return Ok(existingPassenger);
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var passengerDelete = await _contex.passengers.FindAsync(id);

            if (passengerDelete == null)
            {
                return NotFound();
            }

            _contex.passengers.Remove(passengerDelete);
            await _contex.SaveChangesAsync();
            return Ok(passengerDelete);
        }
    }
}
