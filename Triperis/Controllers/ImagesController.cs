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
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                
                for(int i = 0; i < files.Count; i++)
                {
                    var fileName = Guid.NewGuid().ToString() + ".png";

                    var fullPath = Path.Combine(savePath, fileName);
                    var dbPath = Path.Combine("Images", fileName);

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
    }
}
