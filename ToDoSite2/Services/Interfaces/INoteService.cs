using ToDoSite2.Models;

namespace ToDoSite2.Services.Interfaces
{
    public interface INoteService
    {
        public Task<Note> GetNote(int id);
        public List<Note> GetNotes(string userName);
        public Task DeleteNote(int noteId);
        public Task UpdateNote(Note note);
        public Task AddNote(Note note);
        
    }
}
