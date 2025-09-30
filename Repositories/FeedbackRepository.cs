using HrAppApi.Models;
using System.Collections.Concurrent;

namespace HrAppApi.Repositories
{
    public class FeedbackRepository
    {
        private readonly ConcurrentDictionary<int, Feedback> _feedbacks = new();
        private int _nextId = 1;

        public IEnumerable<Feedback> GetAll() => _feedbacks.Values;

        public Feedback? GetById(int id) =>
            _feedbacks.TryGetValue(id, out var feedback) ? feedback : null;

        public Feedback Create(Feedback feedback)
        {
            feedback.Id = _nextId++;
            _feedbacks[feedback.Id] = feedback;
            return feedback;
        }

        public bool Update(int id, Feedback updatedFeedback)
        {
            if (!_feedbacks.ContainsKey(id)) return false;
            updatedFeedback.Id = id;
            _feedbacks[id] = updatedFeedback;
            return true;
        }

        public bool Delete(int id) => _feedbacks.TryRemove(id, out _);
    }
}
