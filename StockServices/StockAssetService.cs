using Microsoft.EntityFrameworkCore;
using StockData;
using StockData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockServices
{
    public class StockAssetService : IStockAsset
    {

        private StockContext _context;

        public StockAssetService(StockContext context)
        {
            _context = context;
        }

        public void AddHashtag(Hashtag newHashtag)
        {
            _context.Add(newHashtag);
            _context.SaveChanges();
        }

        public void AddImage(Image newImage)
        {
            _context.Add(newImage);
            _context.SaveChanges();
        }

        public void AddUser(User newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public void AddCategory(Category newCategory)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public IEnumerable<Hashtag> GetAllHashtags()
        {
            return _context.Hashtags;
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _context.Images;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }



        public IEnumerable<Hashtag> GetHashtagByName(string name)
        {
            return _context.Hashtags.Where(asset => asset.name == name);
        }

        public Image GetImageById(int id)
        {
            return _context.Images.Find(id);
        }

        public IEnumerable<Image> GetImagesByCategory(int id)
        {
            return _context.Images.Where(asset => asset.categoryid == id);
        }

        public IEnumerable<Image> GetImagesByUser(int id)
        {
            return _context.Images.Where(asset => asset.userid == id);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void DeleteImageById(int id)
        {
            _context.Images.Remove(_context.Images.Find(id));
            _context.SaveChanges();
        }

    }
}
