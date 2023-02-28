using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ICacheService
    {
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value);
        T GetOrAdd<T>(string key, Func<T> action) where T : class;
        Task Clear(string key);
        void ClearAll();
    }

}
