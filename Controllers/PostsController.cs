using jsonplaceholderapi.Data;
using jsonplaceholderapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jsonplaceholderapi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController: ControllerBase
{
private readonly JsonPlaceholderDbContext _context;

    public PostsController(JsonPlaceholderDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts(int? id)
    {
        if (id != null)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
                return NotFound(new { Message = "Post not found" });
            return Ok(post);
        }
        var posts = await _context.Posts.ToListAsync();
        if (posts == null)
            return NotFound(new { Message = "No posts" });
        return Ok(posts);
    }

       
    [HttpGet("{postId}/comments")]
    public async Task<IActionResult> GetComments(int postId)
    {
        var comments = await _context.Comments.Where(x => x.PostId == postId).ToListAsync();

        if (comments == null)
        {
            return NotFound();
        }

        return Ok(comments);
    }

    [HttpPost]

    public async Task<IActionResult> PostPosts(List<Post> posts)
    {
        await _context.Posts.AddRangeAsync(posts);
        await _context.SaveChangesAsync();

        return Created("", posts);
    }

    [HttpPost("{postId}/comments")]

    public async Task<IActionResult> PostComments(List<Comment> comments, int postId)
    {
        comments = comments.Select(x => new Comment()
        {
            Name = x.Name, 
            Email = x.Email,
            Body = x.Body,
            PostId = postId
        }).ToList();
        await _context.Comments.AddRangeAsync(comments);
        await _context.SaveChangesAsync();

        return Created("", comments);
    }
}


