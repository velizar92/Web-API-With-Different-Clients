namespace ProgrammingWebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ProgrammingModels.Models;
    using ProgrammingServices.ServiceModels;
    using ProgrammingServices.Services;


    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : ControllerBase
    {
        private readonly IProgrammingLanguageService _programmingLanguageService;

        public ProgrammingLanguagesController(IProgrammingLanguageService programmingLanguageService)
        {
            _programmingLanguageService = programmingLanguageService;
        }

        [HttpGet("all")]      
        public async Task<IEnumerable<ProgrammingLanguageServiceModel>> GetAll()
        {
            var programmingLanguages = await _programmingLanguageService.GetAll();

            return programmingLanguages;
        }

        [HttpGet("{id}")]    
        public async Task<ActionResult<ProgrammingLanguageServiceModel>> GetById(int id)
        {
            var programmingLanguage = await _programmingLanguageService.GetById(id);

            return programmingLanguage;
        }

        [HttpPost("create")]       
        public async Task<ActionResult<ProgrammingLanguageServiceModel>> Create([FromBody] ProgrammingLanguage programmingLanguage)
        {
            var newCourse = await _programmingLanguageService.Create(programmingLanguage);

            return CreatedAtAction(nameof(Create), new { id = programmingLanguage.Id }, newCourse);
        }


        [HttpPut(("update/{id}"))]       
        public async Task<ActionResult> Update(int id, [FromBody] ProgrammingLanguage programmingLanguage)
        {
            if (id != programmingLanguage.Id)
            {
                return BadRequest();
            }

            await _programmingLanguageService.Update(programmingLanguage);

            return NoContent();
        }


        [HttpDelete("delete/{id}")]      
        public async Task<ActionResult> Delete(int id)
        {           
            await _programmingLanguageService.Delete(id);

            return NoContent();
        }

    }
}
