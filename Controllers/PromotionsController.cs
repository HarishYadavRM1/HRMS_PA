using Microsoft.AspNetCore.Mvc;
using HrAppApi.Models;
using HrAppApi.Repositories;

namespace HrAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController : ControllerBase
    {
        private readonly PromotionRepository _repo;

        public PromotionsController(PromotionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Promotion>> Get() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Promotion> Get(int id)
        {
            var promotion = _repo.GetById(id);
            if (promotion == null) return NotFound();
            return Ok(promotion);
        }

        [HttpPost]
        public ActionResult<Promotion> Post([FromBody] Promotion promotion)
        {
            var createdPromotion = _repo.Create(promotion);
            return CreatedAtAction(nameof(Get), new { id = createdPromotion.Id }, createdPromotion);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Promotion promotion)
        {
            if (!_repo.Update(id, promotion))
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
