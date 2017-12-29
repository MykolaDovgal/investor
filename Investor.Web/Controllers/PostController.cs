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
            var ip = IPAddress.Loopback;
            IPHostEntry ips = Dns.GetHostByName(Dns.GetHostName());
            string myNIC = ips.AddressList[0].ToString();

            string myInternetIP = ips.AddressList[0].ToString();

            //
            //UTF8Encoding utf8 = new UTF8Encoding();
            //string whatIsMyIp = "http://automation.whatismyip.com/n09230945.asp";
            //WebClient wc = new WebClient();
            //string response1 = utf8.GetString(wc.DownloadData(whatIsMyIp));
            //IPAddress myIPAddress = IPAddress.Parse(response1);

            //
            
            String direction = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
            
            using (WebResponse response = request.GetResponse()) 
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            { direction = stream.ReadToEnd(); }
            //Search for the ip in the html 
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body>");
            direction = direction.Substring(first, last - first);

            var ip2 = direction;
            bool i = _accessor.HttpContext.Request.Headers.ContainsKey("X_FORWARDED_FOR");
            ViewBag.IP = _accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            return View("Index");
        }

        public IActionResult LastNews()
        {
            IEnumerable<PostPreview> lastNews = _postService.GetLatestNewsAsync(10).Result.ToList();
            return View(lastNews);
        }


    }
}
