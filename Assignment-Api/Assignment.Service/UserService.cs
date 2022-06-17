using Assignment.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Assignment.Service
{
    public class UserService : IUserService
    {
        private readonly IHostingEnvironment _env;
        public UserService(IHostingEnvironment env)
        {
            _env = env;
        }
        public async Task SaveUser(UserModel userModel)
        {
            var filePath = Path.Combine(
                 new string[] { _env.ContentRootPath, "wwwroot", "users.txt" });

            var list = new List<UserModel>();

            if (File.Exists(filePath))
            {
                var text = await File.ReadAllTextAsync(filePath);
                list = JsonConvert.DeserializeObject<List<UserModel>>(text);
            }

            list.Add(userModel);

            var serilizedText = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync(filePath, serilizedText);

        }
    }
}
