using System.Collections.Generic;
using System.Linq;

namespace GeneratedControllers.Persistence
{
    public class Storage<T, TId> where T : class
    {
        private Dictionary<TId, T> storage = new Dictionary<TId, T>();

        public IEnumerable<T> GetAll() => storage.Values;

        public T GetById(TId id)
        {
            return storage.FirstOrDefault(x => x.Key.Equals(id)).Value;
        }

        public void AddOrUpdate(TId id, T item)
        {
            storage[id] = item;
        }
    }
}
