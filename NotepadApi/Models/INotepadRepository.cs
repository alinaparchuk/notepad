using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotepadApi.Models
{
    public interface INotepadRepository
    {
        IEnumerable<Note> GetNotesList(); // получение всех объектов
        Note GetNote(int id); // получение одного объекта по id
        void Create(Note item); // создание объекта
        void Update(Note item); // обновление объекта
        Note Delete(int id); // удаление объекта по id

        //void Save();  // сохранение изменений
    }
}
