using Microsoft.AspNetCore.Mvc;
using HrAppApi.Models;
using HrAppApi.Repositories;

namespace HrAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalsController : ControllerBase
    {
        private readonly GoalRepository _repo;

        public GoalsController(GoalRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GoalSetting>> Get() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public ActionResult<GoalSetting> Get(int id)
        {
            var goal = _repo.GetById(id);
            if (goal == null) return NotFound();
            return Ok(goal);
        }

        [HttpPost]
        public ActionResult<GoalSetting> Post([FromBody] GoalSetting goal)
        {
            var createdGoal = _repo.Create(goal);
            return CreatedAtAction(nameof(Get), new { id = createdGoal.Id }, createdGoal);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GoalSetting goal)
        {
            if (!_repo.Update(id, goal))
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
