using Assignment.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;
using Assignment.Repository;

namespace Assignment.Service
{
    public class UserService : IUserService
    {
        private readonly IFileRepository _fileRepository;

        public UserService( IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task SaveUser(UserModel userModel)
        {
            var list = await _fileRepository.GetAllUsers();
            list.Add(userModel);
            _fileRepository.SaveUser(list);

        }
    }
}
