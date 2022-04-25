using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Triperis.Data;
using Triperis.Models;

namespace Triperis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly AppDbContext dbContext;

        public CarsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        //GET all cars
        // api/Cars
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await dbContext.Cars.ToListAsync();
            return Ok(cars);
        }

        //Get one car by id
        // api/Cars/5
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCar([FromRoute] int id)
        {
            var car = await dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if(car == null)
            {
                return NotFound("Car not found");
            }

            return Ok(car);
        }

        //Add car to db
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            car.Data = DateTime.Now;
            car.Parduotas = false;
            dbContext.Cars.Add(car);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        //Update car
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCar([FromRoute] int id, [FromBody] Car car)
        {
            var existingCar = await dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCar != null)
            {
                existingCar.Marke = car.Marke;
                existingCar.Modelis = car.Modelis;
                existingCar.Metai = car.Metai;
                existingCar.KuroTipas = car.KuroTipas;
                existingCar.KebuloTipas = car.KebuloTipas;
                existingCar.VariklioTuris = car.VariklioTuris;
                existingCar.Galia = car.Galia;
                existingCar.Rida = car.Rida;
                existingCar.Defektai = car.Defektai;
                existingCar.Spalva = car.Spalva;
                existingCar.PavaruDeze = car.PavaruDeze;
                existingCar.Aprasymas = car.Aprasymas;
                existingCar.Parduotas = car.Parduotas;
                existingCar.Kaina = car.Kaina;
                existingCar.Vin = car.Vin;
                await dbContext.SaveChangesAsync();
                return Ok(existingCar);
            }
            return NotFound("Car not found");
        }

        //Delete car
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute] int id)
        {
            var existingCar = await dbContext.Cars.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCar != null)
            {
                dbContext.Cars.Remove(existingCar);
                await dbContext.SaveChangesAsync();
                return Ok(existingCar);
            }
            return NotFound("Car not found");
        }
    }
}
