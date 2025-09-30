using HrAppApi.Models;
using System.Collections.Concurrent;

namespace HrAppApi.Repositories
{
    public class GoalRepository
    {
        private readonly ConcurrentDictionary<int, GoalSetting> _goals = new();
        private int _nextId = 1;

        public IEnumerable<GoalSetting> GetAll() => _goals.Values;

        public GoalSetting? GetById(int id) =>
            _goals.TryGetValue(id, out var goal) ? goal : null;

        public GoalSetting Create(GoalSetting goal)
        {
            goal.Id = _nextId++;
            _goals[goal.Id] = goal;
            return goal;
        }

        public bool Update(int id, GoalSetting updatedGoal)
        {
            if (!_goals.ContainsKey(id)) return false;
            updatedGoal.Id = id;
            _goals[id] = updatedGoal;
            return true;
        }

        public bool Delete(int id) => _goals.TryRemove(id, out _);
    }
}
