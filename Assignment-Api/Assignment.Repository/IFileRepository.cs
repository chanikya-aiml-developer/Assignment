using Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public interface IFileRepository
    {
        Task<List<UserModel>> GetAllUsers();
        void SaveUser(List<UserModel> list);
    }
}
