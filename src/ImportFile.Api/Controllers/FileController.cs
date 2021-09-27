using ImportFile.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ImportFile.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IImportFileService ImportFileService;
        private readonly IItemService ItemService;

        public FileController(IImportFileService importFileService, IItemService itemService)
        {
            this.ImportFileService = importFileService;
            this.ItemService = itemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var itemList = await this.ItemService.GetAll();
            if (itemList == null || !itemList.Any())
                return NoContent();

            return Ok(itemList);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetByKey([FromRoute] string key)
        {
            if (string.IsNullOrEmpty(key))
                return BadRequest();

            var item = await this.ItemService.GetByKey(key);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            if (file.Length <= 0)
                return BadRequest();

            var streamFile = file.OpenReadStream();
            await this.ImportFileService.UploadItemsByFileStream(streamFile);

            return Ok();
        }
    }
}