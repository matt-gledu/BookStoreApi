using BookStoreApi.Interfaces;
using BookStoreApi.Models;
using BookStoreApi.Models.Testplayer;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using Newtonsoft.Json;
//using MongoDB.Bson.IO;
using System.Text.Json;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageController : ControllerBase
    {
        private readonly IPageService _pageService;

        public PageController(IPageService pageService) =>
            _pageService = pageService;

        [HttpGet]
        public async Task<ActionResult<List<Page>>> Get()
        {
            var result = await _pageService.GetAsync();
            var ser = JsonConvert.SerializeObject(result);
            var ser2 = System.Text.Json.JsonSerializer.Serialize(result);
            return result;
        }

        //[HttpGet("{id:length(24)}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> Get(string id)
        {
            var page = await _pageService.GetAsync(id);

            if (page is null)
            {
                return NotFound();
            }

            return page;
        }

        //[HttpGet("bson/{id:length(24)}")]
        //public async Task<ActionResult<Page>> GetByBsonId(string id)
        //{
        //    var page = await _pageService.GetByDocumentIdAsync(id);

        //    if (page is null)
        //    {
        //        return NotFound();
        //    }

        //    return page;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Post(Manifest newManifest)
        //{
        //    await _manifestService.CreateAsync(newManifest);

        //    return CreatedAtAction(nameof(Get), new { id = newManifest.Id }, newManifest);

        //}
    }
}
