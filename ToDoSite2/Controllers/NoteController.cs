using ToDoSite2.Models;
using ToDoSite2.Models.Identity;
using ToDoSite2.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ToDoSite2.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly UserManager<AppUser> _userManager;
        public NoteController(INoteService noteService, UserManager<AppUser> userManager)
        {
            _noteService = noteService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var result = _noteService.GetNotes(userId);
                if (result == null)
                {
                    return View();
                }
                return View(result);
            }

            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Note note)
        {
            if (ModelState.IsValid)
            {
                note.UserId = _userManager.GetUserId(HttpContext.User);
                await _noteService.AddNote(note);

                return RedirectToAction("Index", "Note");
            }

            return View();
        }
        [HttpGet]
        [Route("{controller}/{action}/{noteId:int}")]
        public async Task<IActionResult> Delete(int noteId)
        {
            var note = await _noteService.GetNote(noteId);
            if (note.Title == null)
            {
                return BadRequest();
            }

            return View(note);
        }
        [HttpPost]
        [Route("{controller}/{action}/{noteId:int}")]
        public async Task<IActionResult> DeleteConfirmed(int noteId)
        {
            await _noteService.DeleteNote(noteId);

            return RedirectToAction("Index", "Note");
        }
        [HttpGet]
        [Route("{controller}/{action}/{noteId:int}")]
        public async Task<IActionResult> Edit(int noteId)
        {
            var note = await _noteService.GetNote(noteId);
            return View(note);
        }
        [HttpPost]
        [Route("{controller}/{action}/{noteId:int}")]
        public async Task<IActionResult> Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                await _noteService.UpdateNote(note);
                return RedirectToAction("Index", "Note");
            }

            return View();
        }
    }
}
