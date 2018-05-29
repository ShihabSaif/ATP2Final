using BMSEntity;
using BMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSRepository
{
    public class UserRepository : IUserRepository
    {
        private BMSDBContext context = new BMSDBContext();

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User Get(int id)
        {
            return context.Users.SingleOrDefault(b => b.userId == id);
        }

        public User GetName(string name)
        {
            return context.Users.SingleOrDefault(b => b.user_name == name);
        }

        public int Insert(User bk)
        {
            context.Users.Add(bk);
            return context.SaveChanges();
        }

        public int Update(User user,int id)
        {
            User bk = context.Users.SingleOrDefault(b => b.userId == id);

            bk.user_name = user.user_name;
            bk.password = user.password;
            bk.image_link = user.image_link;

            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            User bk = context.Users.SingleOrDefault(b => b.userId == id);
            if (bk != null)
            {
                context.Users.Remove(bk);
            }
            return context.SaveChanges();
        }

        public User GetEmailNdPass(string email, string password)
        {
            User bk = context.Users.Where(u => u.email == email && u.password == password).FirstOrDefault();
            if (bk != null)
            {
                return bk;
            }
            else
                return null;
        }

        public bool DuplicateMail(User us)
        {
            return context.Users.Any(u => u.email == us.email);
        }
    }
}
