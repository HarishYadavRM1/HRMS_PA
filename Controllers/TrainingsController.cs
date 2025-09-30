using Microsoft.AspNetCore.Mvc;
using HrAppApi.Models;
using HrAppApi.Repositories;

namespace HrAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingsController : ControllerBase
    {
        private readonly TrainingRepository _repo;

        public TrainingsController(TrainingRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Training>> Get() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Training> Get(int id)
        {
            var training = _repo.GetById(id);
            if (training == null) return NotFound();
            return Ok(training);
        }

        [HttpPost]
        public ActionResult<Training> Post([FromBody] Training training)
        {
            var createdTraining = _repo.Create(training);
            return CreatedAtAction(nameof(Get), new { id = createdTraining.Id }, createdTraining);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Training training)
        {
            if (!_repo.Update(id, training))
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repo.Delete(id))
                return NotFound();
            return NoContent();
        }
    }
}
