using API.Contexts;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController(CourseContext context) : ControllerBase {

    private readonly CourseContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Create(CourseEntity newEntity) {

        try {
            if (ModelState.IsValid) {
                if (!await _context.Courses.AnyAsync(x => x.Title == newEntity.Title)) {
                    await _context.Courses.AddAsync(newEntity);
                    await _context.SaveChangesAsync();

                    return Created("", newEntity);

                } else
                    return Conflict("Course with same title already exists");
            }

            return BadRequest();

        } catch (Exception e) { Debug.WriteLine(e); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try {

            var tList = await _context.Courses.ToListAsync();

            return Ok(tList);

        } catch (Exception e) { Debug.WriteLine(e); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(string id) {
        try {

            var tEntity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (tEntity != null)
                return Ok(tEntity);
            else
                return NotFound();

        } catch (Exception e) { Debug.WriteLine(e); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
