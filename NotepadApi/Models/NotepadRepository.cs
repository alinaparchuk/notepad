using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotepadApi.Models
{
    public class NotepadRepository:INotepadRepository
    {
        private NoteContext Context;
        public IEnumerable<Note> GetNotesList()
        {
            return Context.Notes;
        }
        public Note GetNote(int Id)
        {
            return Context.Notes.Find(Id);
        }
        public NotepadRepository(NoteContext context)
        {
            Context = context;
        }
        public void Create(Note createdNote)
        {
            Context.Notes.Add(createdNote);
            Context.SaveChanges();
        }
        public void Update(Note updatedNote)
        {
            Note currentNote = GetNote(updatedNote.Id);
            currentNote.Text = updatedNote.Text;

            Context.Notes.Update(currentNote);
            Context.SaveChanges();
        }

        public Note Delete(int Id)
        {
            Note currentNote = GetNote(Id);

            if (currentNote != null)
            {
                Context.Notes.Remove(currentNote);
                Context.SaveChanges();
            }

            return currentNote;
        }
    }
}
