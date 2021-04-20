﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentCoursesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/StudentCourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentCourses>>> GetStudentCourses()
        {
            return await _context.StudentCourses.ToListAsync();
        }

        // GET: api/StudentCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentCourses>> GetStudentCourses(int id)
        {
            var studentCourses = await _context.StudentCourses.FindAsync(id);

            if (studentCourses == null)
            {
                return NotFound();
            }

            return studentCourses;
        }

        // PUT: api/StudentCourses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentCourses(int id, StudentCourses studentCourses)
        {
            if (id != studentCourses.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentCourses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentCoursesExists(id))
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

        // POST: api/StudentCourses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentCourses>> PostStudentCourses(StudentCourses studentCourses)
        {
            _context.StudentCourses.Add(studentCourses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentCourses", new { id = studentCourses.Id }, studentCourses);
        }

        // DELETE: api/StudentCourses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentCourses>> DeleteStudentCourses(int id)
        {
            var studentCourses = await _context.StudentCourses.FindAsync(id);
            if (studentCourses == null)
            {
                return NotFound();
            }

            _context.StudentCourses.Remove(studentCourses);
            await _context.SaveChangesAsync();

            return studentCourses;
        }

        private bool StudentCoursesExists(int id)
        {
            return _context.StudentCourses.Any(e => e.Id == id);
        }
    }
}
