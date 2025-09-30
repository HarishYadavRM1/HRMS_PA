using HrAppApi.Models;
using System.Collections.Concurrent;

namespace HrAppApi.Repositories
{
    public class PromotionRepository
    {
        private readonly ConcurrentDictionary<int, Promotion> _promotions = new();
        private int _nextId = 1;

        public IEnumerable<Promotion> GetAll() => _promotions.Values;

        public Promotion? GetById(int id) =>
            _promotions.TryGetValue(id, out var promotion) ? promotion : null;

        public Promotion Create(Promotion promotion)
        {
            promotion.Id = _nextId++;
            _promotions[promotion.Id] = promotion;
            return promotion;
        }

        public bool Update(int id, Promotion updatedPromotion)
        {
            if (!_promotions.ContainsKey(id)) return false;
            updatedPromotion.Id = id;
            _promotions[id] = updatedPromotion;
            return true;
        }

        public bool Delete(int id) => _promotions.TryRemove(id, out _);
    }
}
