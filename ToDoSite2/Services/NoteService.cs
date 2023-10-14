using ToDoSite2.Data;
using ToDoSite2.Models;
using ToDoSite2.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ToDoSite2.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _dbContext;
        public NoteService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddNote(Note note)
        {
            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNote(int noteId)
        {
            var note = await GetNote(noteId);
            if (note.Title == null)
            {
                return;
            }
            _dbContext.Notes.Remove(note);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Note> GetNote(int id)
        {
            return await _dbContext.Notes.FirstOrDefaultAsync(n => n.Id == id);
        }

        public List<Note> GetNotes(string userId)
        {
            return _dbContext.Notes.Where(n => n.UserId == userId).ToList();
        }

        public async Task UpdateNote(Note note)
        {
            _dbContext.Notes.Update(note);
            await _dbContext.SaveChangesAsync();
        }
    }
}
