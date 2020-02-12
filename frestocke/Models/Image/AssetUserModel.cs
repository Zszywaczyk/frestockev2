using StockData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frestocke.Models.Image
{
    public class AssetUserModel
    {
        public AssetUserModel()
        {
        }
        public AssetUserModel(string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
            isActive = false;
        }
        public AssetUserModel(User user)
        {
            id = user.id;
            login = user.login;
            password = user.password;
            isActive = user.isActive;
            email = user.email;
        }

        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Boolean isActive { get; set; }
        public string email { get; set; }
    }
}
