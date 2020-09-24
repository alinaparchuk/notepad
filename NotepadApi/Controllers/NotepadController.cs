using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotepadApi.Models;


namespace NotepadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotepadController : ControllerBase
    {        
        public INotepadRepository Repository { get; }

        public NotepadController(INotepadRepository repository)
        {
            Repository = repository;
        }

        // GET api/notepad
        [HttpGet(Name = "GetAllNotes")]
        public IEnumerable<Note> Get()
        {
            return Repository.GetNotesList();
        }

        // GET api/notepad/id
        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult Get(int id)
        {
            Note currentNote = Repository.GetNote(id);
            if(currentNote == null)
            {
                return NotFound();
            }

            return new ObjectResult(currentNote);
        }

        // POST api/notepad
        [HttpPost]
        public IActionResult Create([FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }
            Repository.Create(note);
            return CreatedAtRoute("GetNote", new { id = note.Id }, note);
        }

        // PUT api/notepad/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Note updatedNote)
        {
            if (updatedNote == null || updatedNote.Id != id)
            {
                return BadRequest();
            }

            var note = Repository.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }

            Repository.Update(updatedNote);
            return RedirectToRoute("GetAllNotes");
        }

        // DELETE api/notepad/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedTodoItem = Repository.Delete(id);

            if (deletedTodoItem == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedTodoItem);
        }
    }
}
