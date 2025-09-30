using Microsoft.AspNetCore.Mvc;
using HrAppApi.Models;
using HrAppApi.Repositories;

namespace HrAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppraisalsController : ControllerBase
    {
        private readonly AppraisalCycleRepository _repo;

        public AppraisalsController(AppraisalCycleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppraisalCycle>> Get() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public ActionResult<AppraisalCycle> Get(int id)
        {
            var cycle = _repo.GetById(id);
            if (cycle == null) return NotFound();
            return Ok(cycle);
        }

        [HttpPost]
        public ActionResult<AppraisalCycle> Post([FromBody] AppraisalCycle cycle)
        {
            var createdCycle = _repo.Create(cycle);
            return CreatedAtAction(nameof(Get), new { id = createdCycle.Id }, createdCycle);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AppraisalCycle cycle)
        {
            if (!_repo.Update(id, cycle))
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
