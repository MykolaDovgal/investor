using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Investor.Service.Utils
{
    public class IpService
    {
        private readonly IHttpContextAccessor _accessor;
        public IpService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string GetRequestIp(bool tryUseXForwardHeader = true)
        {
            string ip = null;

            if (tryUseXForwardHeader)
                ip = SplitCsv(GetHeaderValueAs<string>("X-Forwarded-For")).FirstOrDefault();

            if (String.IsNullOrWhiteSpace(ip) && _accessor.HttpContext?.Connection?.RemoteIpAddress != null)
                ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

            if (String.IsNullOrWhiteSpace(ip))
                ip = GetHeaderValueAs<string>("REMOTE_ADDR");

            if (String.IsNullOrWhiteSpace(ip))
                throw new Exception("Unable to determine caller's IP.");

            return ip;
        }

        private T GetHeaderValueAs<T>(string headerName)
        {
            StringValues values;

            if (!(_accessor.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ??
                  false)) return default(T);

            var rawValues = values.ToString();

            if (!String.IsNullOrEmpty(rawValues))
                return (T)Convert.ChangeType(values.ToString(), typeof(T));
            return default(T);
        }

        private IEnumerable<string> SplitCsv(string csvList, bool nullOrWhitespaceInputReturnsNull = false)
        {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }
    }
}
