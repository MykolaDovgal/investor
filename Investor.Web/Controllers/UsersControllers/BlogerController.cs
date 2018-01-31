using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Investor.Model;
using Investor.Service.Interfaces;
using Investor.Service.Utils.Interfaces;
using Investor.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Investor.Web.Controllers.UsersControllers
{
    [Authorize(Roles = "bloger")]
    public class BlogerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public BlogerController(IUserService userService, IBlogService blogService, IImageService imageService, IMapper mapper)
        {
            _userService = userService;
            _imageService = imageService;
            _blogService = blogService;
            _mapper = mapper;
        }
        public IActionResult Profile()
        {
            ViewBag.Header = "_AccountHeaderSection";
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.PersonalData = _mapper.Map<User, UserPersonalDataViewModel>(currentUser);
            ViewBag.PasswordChange = _mapper.Map<User, UserPasswordChangeViewModel>(currentUser);
            ViewBag.Description = _mapper.Map<User, UserDescriptionViewModel>(currentUser);
            return View(currentUser);
        }
        public IActionResult Account()
        {
            ViewBag.Header = "_AccountHeaderSection";
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.User = currentUser;
            var res = _blogService.GetBlogsByUserIdAsync(currentUser?.Id).Result;
            return View(res);
        }

        [HttpPost]
        public IActionResult CreatePost([FromForm] BlogViewModel blog, [FromForm]IFormFile image)
        {
            if (ModelState.IsValid)
            {
                blog.Image = image != null ? _imageService.SaveImage(image) : null;
                var newBlog = _mapper.Map<BlogViewModel, Blog>(blog);
                var tmp = _blogService.AddBlogAsync(newBlog).Result;
                return Json(Url.Action("Account", "Bloger"));
            }
            return View(_mapper.Map<BlogViewModel, Blog>(blog));
        }

        [HttpPost]
        public IActionResult UpdatePost([FromForm] BlogViewModel blog, [FromForm]IFormFile image)
        {
            blog.Image = image != null ? _imageService.SaveImage(image) : null;
            //_blogService.AddTagsToBlogAsync(blog.PostId, blog.Tags).Wait();
            var newBlog = _mapper.Map<BlogViewModel, Blog>(blog);
            var tmp = _blogService.UpdateBlogAsync(newBlog).Result;
            return Json(Url.Action("Account", "Bloger"));
        }

        public IActionResult CreatePost(string id)
        {
            ViewBag.Header = "_AccountHeaderSection";
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.User = currentUser;
            ViewBag.IsOwner = currentUser != null && (String.IsNullOrWhiteSpace(id) && String.IsNullOrWhiteSpace(currentUser.Id) &&
                                                      id == currentUser.Id);

            return View();
        }

        public IActionResult UpdatePost(int id)
        {
            ViewBag.Header = "_AccountHeaderSection";
            ViewBag.Tags = _blogService.GetAllTagsByBlogIdAsync(id).Result.ToList();
            var blog = _blogService.GetBlogByIdAsync<Blog>(id).Result;
            return View("CreatePost", blog);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUserDescription(UserDescriptionViewModel model, [FromForm]IFormFile Image, [FromForm]List<int> Points)
        {
            model.CropPoints = Points;
            model.Photo = Image != null ? _imageService.SaveAccountImage(Image, Points) : _imageService.CropExistingImage(Path.GetFileName(model.Photo), Points);
            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(_mapper.Map<UserDescriptionViewModel, User>(model));
                return RedirectToAction("Profile", "Bloger");
            }
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.PersonalData = _mapper.Map<User, UserPersonalDataViewModel>(currentUser);
            ViewBag.PasswordChange = _mapper.Map<User, UserPasswordChangeViewModel>(currentUser);
            ViewBag.Description = model;
            return View("Profile", currentUser);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUserPersonalData(UserPersonalDataViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(_mapper.Map<UserPersonalDataViewModel, User>(model));
                return RedirectToAction("Profile", "Bloger");

            }
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.PersonalData = model;
            ViewBag.PasswordChange = _mapper.Map<User, UserPasswordChangeViewModel>(currentUser);
            ViewBag.Description = _mapper.Map<User, UserDescriptionViewModel>(currentUser);
            return View("Profile", currentUser);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(UserPasswordChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.ChangePasswordAsync(_mapper.Map<UserPasswordChangeViewModel, User>(model), model.NewPassword);
                return RedirectToAction("Profile");
            }
            var currentUser = _userService.GetCurrentUserAsync().Result;
            ViewBag.PersonalData = _mapper.Map<User, UserPersonalDataViewModel>(currentUser);
            ViewBag.PasswordChange = model;
            ViewBag.Description = _mapper.Map<User, UserDescriptionViewModel>(currentUser);
            return View("Profile", currentUser);
        }
    }
}
