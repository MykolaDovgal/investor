using Investor.Model;
using Investor.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;

namespace Investor.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly INewsService _postService;
        private readonly ITagService _tagService;
        private IHttpContextAccessor _accessor;
        public PostController(INewsService postService, ITagService tagService, IHttpContextAccessor accessor)
        {
            _postService = postService;
            _tagService = tagService;
            _accessor = accessor;
        }
        public IActionResult Index(int id)
        {
            ViewBag.PathBase = Request.Host.Value;
            var post = _postService.GetNewsByIdAsync(id).Result;

            if (!(post?.IsPublished) ?? true)
            {
                Response.StatusCode = 403;
                return StatusCode(Response.StatusCode);
            }
            ViewBag.Post = post;
            ViewBag.LatestPosts = _postService.GetLatestNewsAsync(10).Result?.ToList();
            ViewBag.ImportantPosts = _postService.GetImportantNewsAsync(10).Result?.ToList();
            ViewBag.Tags = _postService.GetAllTagsByNewsIdAsync(id).Result?.ToList();
            ViewBag.PopularTags = _tagService.GetPopularTagsAsync(5).Result?.ToList();
            var ip = GetRequestIP(true);
            //var ip = IPAddress.Loopback;
            //IPHostEntry ips = Dns.GetHostByName(Dns.GetHostName());
            //string myNIC = ips.AddressList[0].ToString();

            //string myInternetIP = ips.AddressList[0].ToString();

            ////
            ////UTF8Encoding utf8 = new UTF8Encoding();
            ////string whatIsMyIp = "http://automation.whatismyip.com/n09230945.asp";
            ////WebClient wc = new WebClient();
            ////string response1 = utf8.GetString(wc.DownloadData(whatIsMyIp));
            ////IPAddress myIPAddress = IPAddress.Parse(response1);

            ////

            //String direction = "";
            //WebRequest request = WebRequest.Create("http://checkip.dyndns.org");

            //using (WebResponse response = request.GetResponse()) 
            //using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            //{ direction = stream.ReadToEnd(); }
            ////Search for the ip in the html 
            //int first = direction.IndexOf("Address: ") + 9;
            //int last = direction.LastIndexOf("</body>");
            //direction = direction.Substring(first, last - first);

            //var ip2 = direction;
            //bool i = _accessor.HttpContext.Request.Headers.ContainsKey("X_FORWARDED_FOR");
            ViewBag.IP = ip;

            return View("Index");
        }

        public IActionResult LastNews()
        {
            IEnumerable<PostPreview> lastNews = _postService.GetLatestNewsAsync(10).Result.ToList();
            return View(lastNews);
        }

        public string GetRequestIP(bool tryUseXForwardHeader = true)
        {
            string ip = null;

            // todo support new "Forwarded" header (2014) https://en.wikipedia.org/wiki/X-Forwarded-For

            // X-Forwarded-For (csv list):  Using the First entry in the list seems to work
            // for 99% of cases however it has been suggested that a better (although tedious)
            // approach might be to read each IP from right to left and use the first public IP.
            // http://stackoverflow.com/a/43554000/538763
            //
            if (tryUseXForwardHeader)
                ip = GetHeaderValueAs<string>("X-Forwarded-For").SplitCsv().FirstOrDefault();

            // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
            if (ip.IsNullOrWhitespace() && _accessor.HttpContext?.Connection?.RemoteIpAddress != null)
                ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();

            if (ip.IsNullOrWhitespace())
                ip = GetHeaderValueAs<string>("REMOTE_ADDR");

            // _httpContextAccessor.HttpContext?.Request?.Host this is the local host.

            if (ip.IsNullOrWhitespace())
                throw new Exception("Unable to determine caller's IP.");

            return ip;
        }

        public T GetHeaderValueAs<T>(string headerName)
        {
            StringValues values;

            if (_accessor.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!String.IsNullOrEmpty(rawValues))
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }
    }
    static class Help
    {
        public static List<string> SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false)
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

        public static bool IsNullOrWhitespace(this string s)
        {
            return String.IsNullOrWhiteSpace(s);
        }
    }
}


