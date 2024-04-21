using API.Contexts;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriberController(SubscriberContext context) : ControllerBase {
    private readonly SubscriberContext _subscriberContext = context;

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] SubscriberEntity entity) {
        try {

            if (ModelState.IsValid) {
                if (!await _subscriberContext.Subscribers.AnyAsync(x => x.Email == entity.Email)) {

                    await _subscriberContext.AddAsync(entity);
                    await _subscriberContext.SaveChangesAsync();

                    return Created("Successfully added subscriber", entity);

                } else
                    return Conflict("Email is already registered");

            } else
                BadRequest("Invalid email");

        } catch (Exception e) { Debug.WriteLine(e); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        try {

            var tList = await _subscriberContext.Subscribers.ToListAsync();
            return Ok(tList);

        } catch (Exception e) { Debug.WriteLine(e); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(string email) {
        try {
            var tEntity = new SubscriberEntity {
                Email = email
            };

            _subscriberContext.Subscribers.Remove(tEntity);
            await _subscriberContext.SaveChangesAsync();

            return Ok();

        } catch (Exception e) { Debug.WriteLine(e); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
