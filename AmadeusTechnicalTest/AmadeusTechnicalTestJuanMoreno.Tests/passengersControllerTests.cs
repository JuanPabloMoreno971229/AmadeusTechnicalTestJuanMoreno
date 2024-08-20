using AmadeusTechnicalTestJuanMoreno.Controllers;
using AmadeusTechnicalTestJuanMoreno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AmadeusTechnicalTestJuanMoreno.Tests
{
    public class PassengersControllerTests
    {
        private readonly passengersController _controller;
        private readonly passengerContex _context;

        public PassengersControllerTests()
        {
            var options = new DbContextOptionsBuilder<passengerContex>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new passengerContex(options);

            _context.Database.EnsureCreated();

            if (!_context.passengers.Any())
            {
                _context.passengers.AddRange(
                    new passenger { Id = 1, Firstname = "John", Lastname = "Doe", Age = 30, Departure = "NYC", Arrival = "LAX" },
                    new passenger { Id = 2, Firstname = "Jane", Lastname = "Smith", Age = 25, Departure = "LAX", Arrival = "NYC" }
                );
                _context.SaveChanges();
            }

            _controller = new passengersController(_context);
        }

        [Fact]
        public async Task CreatePassenger_ReturnsOkObjectResult_WhenPassengerIsCreated()
        {
            var passenger = new passenger { Id = 3, Firstname = "Bob", Lastname = "Brown", Age = 40, Departure = "SFO", Arrival = "SEA" };

            var result = await _controller.CreatePassanger(passenger);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okObjectResult.StatusCode);

            var createdPassenger = await _context.passengers.FindAsync(3);
            Assert.NotNull(createdPassenger);
        }


        [Fact]
        public async Task PassengerList_ReturnsOkResult_WithListOfPassengers()
        {
            var result = await _controller.passengerList();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<passenger>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task PassengerDetails_ReturnsNotFoundResult_WhenPassengerDoesNotExist()
        {
            var result = await _controller.PassengerDetails(999);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
