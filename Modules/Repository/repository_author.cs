using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Modules
{
    public class repository_author : interface_repository<Author>
    {

        List<Author> author;

        public repository_author()
        {
            author = new List<Author>
            {
                new Author{id= 1, full_name="Ahmed" },
                new Author{id= 2, full_name="Khalid" },
                new Author{id= 3, full_name="Mohammed" }
            };
        }




        public void add(Author obj)
        {
            author.Add(obj);
        }

        public void delete(int id)
        {
            author.Remove(Find(id));
        }

        public Author Find(int id)
        {
            var id_author = author.SingleOrDefault(a => a.id == id);
            return id_author;
        }

        public IList<Author> List_Item()
        {
            return author;
        }

        public List<Author> Search(string word)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Author obj)
        {
            var id_author = Find(id);

            id_author.full_name = obj.full_name;



        }
    }
}
