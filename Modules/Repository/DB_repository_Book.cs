using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Modules.Repository
{
    public class DB_repository_Book : interface_repository<Book>
    {

        BookDBContent DB;

        public DB_repository_Book(BookDBContent DB)
        {
            this.DB = DB; 
        }

        public void add(Book obj)
        {
            DB.DBBook.Add(obj);
            SaveChanges();
        }

        public void delete(int id)
        {
            DB.DBBook.Remove(Find(id));
            SaveChanges();
        }

        public Book Find(int id)
        {
            var id_book = DB.DBBook.Include(a => a.author).SingleOrDefault(b => b.id == id);
            return id_book;
        }

        public IList<Book> List_Item()
        {
            return DB.DBBook.Include(a => a.author).ToList();
        }

        public void update(int id, Book obj)
        {
            DB.Update(obj);
            SaveChanges();

        }

        public void SaveChanges()
        {
            DB.SaveChanges();
        }

        public List<Book> Search(string word)
        {
            var ResultSearch = DB.DBBook.Include(a => a.author).Where(b => b.title.Contains(word) ||
                                                b.descreption.Contains(word) ||
                                                b.author.full_name.Contains(word)).ToList();
            return ResultSearch;
        }
    }
}
  

