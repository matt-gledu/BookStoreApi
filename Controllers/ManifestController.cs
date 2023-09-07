using BookStoreApi.Models;
using BookStoreApi.Models.Testplayer;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManifestController : ControllerBase
    {
        private readonly ManifestService _manifestService;

        public ManifestController(ManifestService manifestService) =>
            _manifestService = manifestService;

        [HttpGet]
        public async Task<Manifest> Get() =>
            await _manifestService.GetAsync();

        //[HttpGet("{id:length(24)}")]
        //public async Task<ActionResult<Book>> Get(string id)
        //{
        //    var book = await _manifestService.GetAsync(id);

        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        [HttpPost]
        public async Task<IActionResult> Post(Manifest newManifest)
        {
            await _manifestService.CreateAsync(newManifest);

            return CreatedAtAction(nameof(Get), new { id = newManifest.Id }, newManifest);
        }

        //[HttpPut("{id:length(24)}")]
        //public async Task<IActionResult> Update(string id, Book updatedBook)
        //{
        //    var book = await _manifestService.GetAsync(id);

        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    updatedBook.Id = book.Id;

        //    await _manifestService.UpdateAsync(id, updatedBook);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    var book = await _manifestService.GetAsync(id);

        //    if (book is null)
        //    {
        //        return NotFound();
        //    }

        //    await _manifestService.RemoveAsync(id);

        //    return NoContent();
        //}
    }
}
