using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfLesson.Server.API.Models
{
    public class CacheOptions
    {
        readonly TimeSpan _DefaultExpirationTime = new TimeSpan(0, 15, 0);
        public TimeSpan ExpirationTime { get; set; }
        public CacheOptions(string expirationTime)
        {
            bool isCorrentFormat = TimeSpan.TryParse(expirationTime, out TimeSpan expiration);
            if (isCorrentFormat)
                ExpirationTime = expiration;
            else
                ExpirationTime = _DefaultExpirationTime;
        }

    }
}
