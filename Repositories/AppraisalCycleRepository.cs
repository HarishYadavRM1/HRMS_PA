using HrAppApi.Models;
using System.Collections.Concurrent;

namespace HrAppApi.Repositories
{
    public class AppraisalCycleRepository
    {
        private readonly ConcurrentDictionary<int, AppraisalCycle> _cycles = new();
        private int _nextId = 1;

        public IEnumerable<AppraisalCycle> GetAll() => _cycles.Values;

        public AppraisalCycle? GetById(int id) =>
            _cycles.TryGetValue(id, out var cycle) ? cycle : null;

        public AppraisalCycle Create(AppraisalCycle cycle)
        {
            cycle.Id = _nextId++;
            _cycles[cycle.Id] = cycle;
            return cycle;
        }

        public bool Update(int id, AppraisalCycle updatedCycle)
        {
            if (!_cycles.ContainsKey(id)) return false;
            updatedCycle.Id = id;
            _cycles[id] = updatedCycle;
            return true;
        }

        public bool Delete(int id) => _cycles.TryRemove(id, out _);
    }
}
