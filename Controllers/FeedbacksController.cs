using Microsoft.AspNetCore.Mvc;
using HrAppApi.Models;
using HrAppApi.Repositories;

namespace HrAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly FeedbackRepository _repo;

        public FeedbacksController(FeedbackRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Feedback>> Get() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Feedback> Get(int id)
        {
            var feedback = _repo.GetById(id);
            if (feedback == null) return NotFound();
            return Ok(feedback);
        }

        [HttpPost]
        public ActionResult<Feedback> Post([FromBody] Feedback feedback)
        {
            var createdFeedback = _repo.Create(feedback);
            return CreatedAtAction(nameof(Get), new { id = createdFeedback.Id }, createdFeedback);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Feedback feedback)
        {
            if (!_repo.Update(id, feedback))
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
