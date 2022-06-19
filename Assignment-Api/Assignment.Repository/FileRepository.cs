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
    public class FileRepository : IFileRepository
    {
        private readonly IHostingEnvironment _env;
        private IConfiguration _config;
        public FileRepository(IHostingEnvironment env, IConfiguration Config)
        {
            _env = env;
            _config = Config;
        }
        public async Task SaveToFile(List<UserModel> list)
        {
            var filePath = Path.Combine(
                new string[] { _env.ContentRootPath, _config.GetSection("StorageDetails").GetSection("FolderName").Value,
                    _config.GetSection("StorageDetails").GetSection("FileName").Value });

            var serilizedText = JsonConvert.SerializeObject(list);
            await File.WriteAllTextAsync(filePath, serilizedText);
        }
    }
}
