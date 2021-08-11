using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Modules.Repository
{
    public class DB_repository_author : interface_repository<Author>
    {

        BookDBContent DB;

        public DB_repository_author(BookDBContent DB)
        {
            this.DB = DB;
        }

        public void add(Author obj)
        {
            DB.DBAuthor.Add(obj);
            SaveChanges();
        }

        public void delete(int id)
        {
            DB.DBAuthor.Remove(Find(id));
            SaveChanges();
        }

        public Author Find(int id)
        {
            var id_author = DB.DBAuthor.SingleOrDefault(a => a.id == id);
            return id_author;
        }

        public IList<Author> List_Item()
        {
            return DB.DBAuthor.ToList();
        }

        public void update(int id, Author obj)
        {
            DB.Update(obj);
            SaveChanges();

        }

        public void SaveChanges()
        {
            DB.SaveChanges();
        }

        public List<Author> Search(string word)
        {
            // To Ignore Implement This Method
            throw new NotImplementedException();
        }
    }
}

