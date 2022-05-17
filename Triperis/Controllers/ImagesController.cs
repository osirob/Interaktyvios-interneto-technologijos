using Microsoft.AspNetCore.Mvc;
using Triperis.Data;
using Triperis.Models;

namespace Triperis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public ImagesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("Upload/{id}")]
        public async Task<IActionResult> UploadImage([FromRoute] int id)
        {
            var files = Request.Form.Files; //i guess i dont index this if i want o upload more than 1 image?

            if (files.Count > 0)
            {
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "../Triperis_Angular/Triperis/src/assets");

                for (int i = 0; i < files.Count; i++)
                {
                    //var fileName = Guid.NewGuid().ToString() + ".png";
                    var fileName = "Car" + id.ToString() + "_" + (i + 1).ToString() + ".png";

                    var fullPath = Path.Combine(savePath, fileName);
                    var dbPath = Path.Combine("/assets", fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        files[i].CopyTo(stream);
                    }

                    var imageDb = new Image()
                    {
                        Path = dbPath,
                        CarId = id
                    };

                    dbContext.Images.Add(imageDb);
                    await dbContext.SaveChangesAsync();
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetFirstImage/{id}")]
        public async Task<IActionResult> GetFirstImageURL([FromRoute] int id)
        {
            var carImages = dbContext.Images.Where(x => x.CarId == id).OrderBy(x => x.Path).ToList();
            return Ok( new {path = carImages.First().Path});
        }

        [HttpDelete]
        [Route("DeleteCarImages/{id}")]
        public async Task<IActionResult> DeleteCarImages([FromRoute] int id)
        {
            var carImages = dbContext.Images.Where(x => x.CarId == id);
            foreach(var image in carImages)
            {
                 dbContext.Images.Remove(image);
            }
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
