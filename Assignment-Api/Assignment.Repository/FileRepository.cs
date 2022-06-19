using Assignment.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public class FileRepository : FileManager, IFileRepository
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly string _fileName;
        public FileRepository(IHostingEnvironment env, IConfiguration Config)
        {
            _env = env;
            _config = Config;
            _fileName = Path.Combine(
               new string[] { _env.ContentRootPath, _config.GetSection("StorageDetails").GetSection("FolderName").Value,
                    _config.GetSection("StorageDetails").GetSection("FileName").Value });
        }
        public void SaveUser(List<UserModel> list)
        {
            var serilizedText = JsonConvert.SerializeObject(list);
            WriteToFile(serilizedText, _fileName);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var text = await ReadAllText(_fileName);
            if (string.IsNullOrEmpty(text))
                return new List<UserModel>();
            return JsonConvert.DeserializeObject<List<UserModel>>(text);
        }
    }
}
