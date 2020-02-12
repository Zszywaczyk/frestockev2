using System;
using System.Collections.Generic;
using System.Text;
using StockData.Models;

namespace StockData
{
    public interface IStockAsset
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);

        IEnumerable<Hashtag> GetAllHashtags();
        IEnumerable<Hashtag> GetHashtagByName(string name);
        void AddHashtag(Hashtag newHashtag);


        IEnumerable<Image> GetAllImages();
        Image GetImageById(int id);
        IEnumerable<Image> GetImagesByCategory(int id);
        IEnumerable<Image> GetImagesByUser(int id);
        void AddImage(Image newImage);


        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User newUser);
        void AddCategory(Category newCategory);
        void DeleteImageById(int id);

    }
}
