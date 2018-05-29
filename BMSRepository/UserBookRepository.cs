using BMSEntity;
using BMSInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMSRepository
{
    public class UserBookRepository : IUserBookRepository
    {
        private BMSDBContext context = new BMSDBContext();

        public int Delete(int id)
        {
            UserBook bk = context.userBooks.SingleOrDefault(b => b.BookId == id);
            if (bk != null)
            {
                context.userBooks.Remove(bk);
            }
            return context.SaveChanges();
        }

        public double GetAverageRating(int id)
        {
            //userBook bk = context.userBooks.First(b => b.BookId == id);

            if (context.userBooks.Any(b => b.BookId == id && b.Rating != 0))
            {
                return context.userBooks.Where(c => c.BookId == id && c.Rating != 0)
                                    .Average(c => c.Rating);
            }
            else
            {
                return 0.000;
            }
        }

        public double GetAverageRatingForUser(int id)
        {
            //userBook bk = context.userBooks.First(b => b.BookId == id);

            if (context.userBooks.Any(b => b.userId == id && b.Rating != 0))
            {
                return context.userBooks.Where(c => c.userId == id && c.Rating != 0)
                                    .Average(c => c.Rating);
            }
            else
            {
                return 0.000;
            }
        }

        public int GetBookCount(int id)
        {
            //userBook bk = context.userBooks.First(b => b.BookId == id);

            if (context.userBooks.Any(b => b.userId == id))
            {
                return context.userBooks.Where(c => c.userId == id)
                                    .Count();
            }
            else
            {
                return 0;
            }
        }

        public UserBook Get(int id)
        {
            return context.userBooks.SingleOrDefault(b => b.BookId == id);
        }

        public UserBook GetUserAndBookId(int UserId, int BookId)
        {
            UserBook ub = context.userBooks.SingleOrDefault(b => b.BookId == BookId && b.userId == UserId);

            if (ub != null)
            {
                return ub;
            }
            else
            {
                return null;
            }
        }

        public List<UserBook> GetAll()
        {
            return context.userBooks.ToList();
        }

        public int Insert(UserBook bk)
        {
            context.userBooks.Add(bk);
            return context.SaveChanges();
        }

        //public int UpdateRating(userBook book)
        //{
        //    userBook bk = context.userBooks.SingleOrDefault(b => b.userBookId == book.userBookId);

        //    //bk.userId = book.userId;
        //    //bk.BookId = book.BookId;
        //    //bk.readStatus = book.readStatus;
        //    bk.Rating = book.Rating;

        //    return context.SaveChanges();
        //}

        //public int UpdateStatus(userBook book)
        //{
        //    userBook bk = context.userBooks.SingleOrDefault(b => b.userBookId == book.userBookId);

        //    //bk.userId = book.userId;
        //    //bk.BookId = book.BookId;
        //    //bk.readStatus = book.readStatus;
        //    bk.readStatus = book.readStatus;

        //    return context.SaveChanges();
        //}

        public int Update(UserBook book,int id)
        {
            UserBook bk = context.userBooks.SingleOrDefault(b => b.userBookId == book.userBookId);

            bk.userId = book.userId;
            bk.BookId = book.BookId;
            bk.readStatus = book.readStatus;


            return context.SaveChanges();
        }

        public List<Book> GetUserBookList(int userId, int readStatus)
        {
            List<Book> list = (from d in context.userBooks
                               join f in context.Books
                               on d.BookId equals f.BookId
                               where d.userId == userId && d.readStatus == readStatus
                               select f).ToList();

            return list;
        }
    }
}
