using Assignment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service
{
    public interface IUserService
    {
        Task SaveUser(UserModel userModel);
    }
}
