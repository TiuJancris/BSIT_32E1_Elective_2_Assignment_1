using Microsoft.AspNetCore.Mvc;
using AssignmentApp.Models;

namespace AssignmentApp.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesApiController : ControllerBase
{
    private static readonly List<Course> _courses = new()
    {
        new Course { Id = 1, Title = "Web Systems and Technologies", Code = "IT-321", Units = 3 },
        new Course { Id = 2, Title = "Advanced Database Management Systems", Code = "IT-322", Units = 3 },
        new Course { Id = 3, Title = "Information Assurance and Security", Code = "IT-323", Units = 3 }
    };

    // GET /api/courses - Safe & Idempotent (Question 6 & 8)
    [HttpGet]
    public ActionResult<IEnumerable<Course>> GetAll()
    {
        return Ok(_courses);
    }

    // GET /api/courses/{id} - Returning ActionResult<T> (Question 9)
    [HttpGet("{id}")]
    public ActionResult<Course> GetById(int id)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id);
        if (course == null)
        {
            return NotFound(new { message = $"Course with ID {id} not found." });
        }
        return Ok(course);
    }

    // POST /api/courses - 201 Created with Location header (Question 4, automatic 400 validation: Question 3)
    [HttpPost]
    public ActionResult<Course> Create([FromBody] Course course)
    {
        course.Id = _courses.Count > 0 ? _courses.Max(c => c.Id) + 1 : 1;
        _courses.Add(course);

        return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
    }

    // DELETE /api/courses/{id} - 204 No Content (Question 5)
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var course = _courses.FirstOrDefault(c => c.Id == id);
        if (course == null)
        {
            return NotFound(new { message = $"Course with ID {id} not found." });
        }

        _courses.Remove(course);
        return NoContent(); // HTTP 204 No Content
    }
}
