using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfLesson.Server.API.Interfaces
{
    public interface ICache
    {
        T GetOrUpdate<T>(string key, Func<T> func);
    }
}
