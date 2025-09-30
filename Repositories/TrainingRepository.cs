using HrAppApi.Models;
using System.Collections.Concurrent;

namespace HrAppApi.Repositories
{
    public class TrainingRepository
    {
        private readonly ConcurrentDictionary<int, Training> _trainings = new();
        private int _nextId = 1;

        public IEnumerable<Training> GetAll() => _trainings.Values;

        public Training? GetById(int id) =>
            _trainings.TryGetValue(id, out var training) ? training : null;

        public Training Create(Training training)
        {
            training.Id = _nextId++;
            _trainings[training.Id] = training;
            return training;
        }

        public bool Update(int id, Training updatedTraining)
        {
            if (!_trainings.ContainsKey(id)) return false;
            updatedTraining.Id = id;
            _trainings[id] = updatedTraining;
            return true;
        }

        public bool Delete(int id) => _trainings.TryRemove(id, out _);
    }
}
