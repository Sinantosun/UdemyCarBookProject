using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.WebApi.Dtos.CommentDtos;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }
        [HttpGet("GetCommentById/{id}")]
        public IActionResult GetCommentById(int id)
        {
            var values = _commentRepository.GetById(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(CreateCommentDto comment)
        {
            _commentRepository.Create(new Comment
            {
                BlogId = comment.BlogId,
                CreatedDate = comment.CreatedDate,
                Name = comment.Name,
                CommentContent = comment.CommentContent
            });
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var value = _commentRepository.GetById(updateCommentDto.CommentID);
            value.BlogId = updateCommentDto.BlogId;
            value.CreatedDate = updateCommentDto.CreatedDate;
            value.Name = updateCommentDto.Name;
            value.CommentContent = updateCommentDto.CommentContent;
            _commentRepository.Update(value);
            return Ok();
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok();
        }
    }
}
