using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using frestocke.Models;
using StockData;
using frestocke.Models.Image;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;

namespace frestocke.Controllers
{
    public class HomeController : Controller
    {
        private IStockAsset _assets;
        public HomeController(IStockAsset asset)
        {
            _assets = asset;
        }

        public IActionResult Index()
        {
            var imgModel = _assets.GetAllImages();
            var userModel = _assets.GetAllUsers();
            var categoryModel = _assets.GetAllCategories();

            var imgResult = imgModel
                .Select(result => new AssetImageModel
                {
                    id = result.id,
                    title = result.title,
                    user = new AssetUserModel(_assets.GetUserById(result.userid)),
                    category = new AssetCategoryModel(_assets.GetCategoryById(result.categoryid)),
                    filetype = result.filetype,
                    xsize = result.xsize,
                    ysize = result.ysize,
                    filename = result.filename,
                    filepath = result.filepath,
                    DateOfAdd = result.DateOfAdd,
                });

            var categoryResult = categoryModel
                .Select(result => new AssetCategoryModel
                {
                    id = result.id,
                    name = result.name
                });


            var model = new AssetIndexModel()
            {
                Images = imgResult,
                Categories = categoryResult
            };

            ViewBag.activeUserId = Request.HttpContext.Session.GetInt32("activeUserId");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Login")] string login, [Bind("Password")] string password)
        {
            var userModel = _assets.GetAllUsers();

            var isUserExiste = userModel.Where(result => result.login == login && result.password == password).FirstOrDefault();

            if (isUserExiste != null)
            {
                //HttpContext.Session.Set("loggedUser", isUserExiste)
                HttpContext.Session.SetInt32("activeUserId", isUserExiste.id);
                HttpContext.Session.SetString("activeUserLogin", isUserExiste.login);
                return RedirectToAction(nameof(Index));
            }

            HttpContext.Session.SetString("alert", "Nieprawidłowy login lub hasło");
            HttpContext.Session.SetString("alertIcon", "glyphicon-remove-sign");

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount([Bind("cLogin")] string clogin, [Bind("cPassword")] string cpassword, [Bind("cEmail")] string cemail)
        {

            var userModel = _assets.GetAllUsers();
            var isLoginExist = userModel.Where(result => result.login == clogin).FirstOrDefault();

            if(isLoginExist != null)
            {
                HttpContext.Session.SetString("alert", "Login niestety zajęty");
                HttpContext.Session.SetString("alertIcon", "glyphicon-remove-sign");
                return RedirectToAction(nameof(Index));
            }

            _assets.AddUser(new StockData.Models.User()
            {
                login = clogin,
                password = cpassword,
                email = cemail,
                isActive = false
            });

                HttpContext.Session.SetString("alert", "Konto utworzone prawidłowo");
                HttpContext.Session.SetString("alertIcon", "glyphicon-ok-sign");
                return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage([Bind("imageTitle")] string imageTitle, [Bind("imageCategory")] string imageCategory, [Bind("imageFile")] IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                //sprawdzamy czy kategori juz isnieje czy trzeba jednak ja dodac
                var categoryModel = _assets.GetAllCategories();
                var isCategoryExist = categoryModel.Where(result => result.name.ToLower() == imageCategory.ToLower()).FirstOrDefault();

                Guid hash = Guid.NewGuid();

                var fileType = Path.GetExtension(imageFile.FileName);
                var fileName = hash + fileType;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\stockthumbnails", fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileSteam);
                }
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\stockImages", fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileSteam);
                }
                var img = Image.FromFile(filePath);

                int imgWidth = img.Width;
                int imgHeight = img.Height;

                if (isCategoryExist != null )
                {
                    _assets.AddImage(new StockData.Models.Image()
                    {
                        title = imageTitle,
                        userid = (int)HttpContext.Session.GetInt32("activeUserId"),
                        categoryid = isCategoryExist.id,
                        filetype = fileType,
                        xsize = imgWidth,
                        ysize = imgHeight,
                        filename = hash + fileType,
                        filepath = "images/stockImages/"+ hash + fileType,
                        Hashtagid = 1,
                        DateOfAdd = DateTime.Now,
                    });
                }
                else
                {
                    _assets.AddCategory(new StockData.Models.Category()
                    {
                        name = imageCategory
                    });
                    categoryModel = _assets.GetAllCategories();
                    isCategoryExist = categoryModel.Where(result => result.name.ToLower() == imageCategory.ToLower()).FirstOrDefault();

                    _assets.AddImage(new StockData.Models.Image()
                    {
                        title = imageTitle,
                        userid = (int)HttpContext.Session.GetInt32("activeUserId"),
                        categoryid = isCategoryExist.id,
                        filetype = fileType,
                        xsize = imgWidth,
                        ysize = imgHeight,
                        filename = hash + fileType,
                        filepath = "images/stockImages/" + hash + fileType,
                        Hashtagid = 1,
                        DateOfAdd = DateTime.Now,
                    });

                }


                HttpContext.Session.SetString("alert", "Udało się poprawnie dodać obrazek");
                HttpContext.Session.SetString("alertIcon", "glyphicon-ok-sign");
                return RedirectToAction(nameof(Index));
            }


            HttpContext.Session.SetString("alert", "Nie udało się dodać obrazka");
            HttpContext.Session.SetString("alertIcon", "glyphicon-remove-sign");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ActualUser()
        {
            var imgModel = _assets.GetAllImages().Where(result => result.userid == HttpContext.Session.GetInt32("activeUserId"));
            var userModel = _assets.GetAllUsers();
            var categoryModel = _assets.GetAllCategories();

            var imgResult = imgModel
                .Select(result => new AssetImageModel
                {
                    id = result.id,
                    title = result.title,
                    user = new AssetUserModel(_assets.GetUserById(result.userid)),
                    category = new AssetCategoryModel(_assets.GetCategoryById(result.categoryid)),
                    filetype = result.filetype,
                    xsize = result.xsize,
                    ysize = result.ysize,
                    filename = result.filename,
                    filepath = result.filepath,
                    DateOfAdd = result.DateOfAdd,
                });

            var categoryResult = categoryModel
                .Select(result => new AssetCategoryModel
                {
                    id = result.id,
                    name = result.name
                });


            var model = new AssetIndexModel()
            {
                Images = imgResult,
                Categories = categoryResult
            };

            ViewBag.activeUserId = Request.HttpContext.Session.GetInt32("activeUserId");

            return View(model);
        }

        public IActionResult DeleteImage(int? id)
        {
            var deletingImg = _assets.GetImageById((int)id);

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\stockthumbnails", deletingImg.filename);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
            fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\stockImages", deletingImg.filename);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }


            //string category = Request.QueryString
            _assets.DeleteImageById((int)id);

            return RedirectToAction(nameof(ActualUser));
        }



            public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
