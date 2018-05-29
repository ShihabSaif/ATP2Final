using BMSEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSInterface
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
        int Insert(User bk);
        int Update(User book,int id);
        int Delete(int id);
    }
}
