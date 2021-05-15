using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseApplication.Models;

namespace CourseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseApplicationContext _context;

        public CoursesController(CourseApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseApplicationItem>>> GetCourseApplications()
        {
            return await _context.CourseApplications.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseApplicationItem>> GetCourseApplicationItem(long id)
        {
            var courseApplicationItem = await _context.CourseApplications.FindAsync(id);

            if (courseApplicationItem == null)
            {
                return NotFound();
            }

            return courseApplicationItem;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourseApplicationItem(long id, CourseApplicationItem courseApplicationItem)
        {
            if (id != courseApplicationItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(courseApplicationItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseApplicationItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseApplicationItem>> PostCourseApplicationItem(CourseApplicationItem courseApplicationItem)
        {
            _context.CourseApplications.Add(courseApplicationItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourseApplicationItem", new { id = courseApplicationItem.Id }, courseApplicationItem);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseApplicationItem(long id)
        {
            var courseApplicationItem = await _context.CourseApplications.FindAsync(id);
            if (courseApplicationItem == null)
            {
                return NotFound();
            }

            _context.CourseApplications.Remove(courseApplicationItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseApplicationItemExists(long id)
        {
            return _context.CourseApplications.Any(e => e.Id == id);
        }
    }
}
