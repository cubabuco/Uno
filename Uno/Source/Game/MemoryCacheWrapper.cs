using System;
using System.Collections.Specialized;
using System.Runtime.Caching;

namespace Uno
{
    public class MemoryCacheWrapper<T> 
    {
        private readonly MemoryCache _memoryCache;
        private CacheItemPolicy _cacheItemPolicy;
        private bool _isDisposed;

        public MemoryCacheWrapper(string name)
        {
            _memoryCache = new MemoryCache(name);
            _isDisposed = false;
            CacheItemPolicy = new CacheItemPolicy { SlidingExpiration = new TimeSpan(1, 0, 0) };
        }

        public MemoryCacheWrapper(string name, NameValueCollection config)
        {
            _memoryCache = new MemoryCache(name, config);
            _isDisposed = false;
            CacheItemPolicy = new CacheItemPolicy { SlidingExpiration = new TimeSpan(1, 0, 0) };
        }

        public string Name
        {
            get { return _memoryCache.Name; }
        }

        public long CacheMemoryLimitInBytes
        {
            get { return _memoryCache.CacheMemoryLimit; }
        }

        public long PhysicalMemoryLimit
        {
            get { return _memoryCache.PhysicalMemoryLimit; }
        }

        public TimeSpan PollingInterval
        {
            get { return _memoryCache.PollingInterval; }
        }

        public CacheItemPolicy CacheItemPolicy
        {
            get
            {
                return _cacheItemPolicy;
            }
            set
            {
                if (value != null)
                {
                    _cacheItemPolicy = value;
                }
            }
        }

        public void AddOrUpdate(string key, T value)
        {
            _memoryCache.Set(key, value, CacheItemPolicy);
        }

        public bool TryGetValue(string key, out T value)
        {
            bool result = false;
            value = default(T);

            object item = _memoryCache.Get(key);
            if (item != null)
            {
                value = (T)item;
                result = true;
            }

            return result;
        }

        public bool TryRemove(string key, out T value)
        {
            bool result = false;
            value = default(T);

            object item = _memoryCache.Remove(key);
            if (item != null)
            {
                result = true;
                value = (T)item;
            }

            return result;
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public bool ContainsKey(string key)
        {
            return _memoryCache.Contains(key);
        }

        public long Count
        {
            get { return _memoryCache.GetCount(); }
        }

        ~MemoryCacheWrapper()
        {
            // Garbage collection has kicked in tidy up your object.
            Dispose(false);
        }

        // Implement IDisposable.
        public void Dispose()
        {
            // Dispose has been called clean up your object and members that
            // are disposable.
            Dispose(true);

            // Now Make sure that you don't call the cleanup again via the Finalizer
            // Effectively you are taking over garbage collection so make sure you
            // don't do it again
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Only do this once.
            if (!_isDisposed)
            {
                // If called via IDispose interface then clean up sub-objects.
                // That implement the IDispose interface.
                if (disposing)
                {
                    // Dispose managed resources.
                    _memoryCache.Dispose();
                }

                // Now clean-up and objects that don't implement dispose.
                // i.e close any file handles 

                // Currently nothing to do.    
            }
            _isDisposed = true;
        }
    }
}