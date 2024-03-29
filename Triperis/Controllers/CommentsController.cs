﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Triperis.Data;
using Triperis.Models;

namespace Triperis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public CommentsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentCreateDto comment)
        {
            var newComment = new Comment()
            {
                Text = comment.Text,
                Username = comment.Username,
                CarId = comment.CarId,

                CreationDate = DateTime.Now
            };
            dbContext.Comments.Add(newComment);
            await dbContext.SaveChangesAsync();

            return Ok(new { newComment });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var existingComment = await dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (existingComment != null)
            {
                dbContext.Comments.Remove(existingComment);
                await dbContext.SaveChangesAsync();
                return Ok(existingComment);
            }
            return NotFound("Comment not found");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCommentsById([FromRoute] int id)
        {
            var comments = await dbContext.Comments.Where(x => x.CarId == id).ToListAsync();
            if(comments.Count != 0)
            {
                var commentDtos = new List<CommentDto>();
                foreach (var comment in comments)
                {
                    var commentDto = new CommentDto()
                    {
                        Id = comment.Id,
                        Text = comment.Text,
                        CreationDate = comment.CreationDate,
                        Username = comment.Username,
                        CarId = comment.CarId
                    };
                    commentDtos.Add(commentDto);
                }
                return Ok(commentDtos);
            }
            return NotFound("No Comments");
        }
    }
}
