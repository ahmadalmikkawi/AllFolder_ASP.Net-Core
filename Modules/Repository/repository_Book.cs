using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Modules
{
    public class repository_Book : interface_repository<Book>
    {

        List<Book> book;

        public repository_Book()
        {
            book = new List<Book>
            {
                new Book{id= 1, title= "Java", descreption= "All Detailes Java", author = new Author(),
                UrlFile= null},

                new Book{id= 2, title= "Html", descreption= "All Detailes Html", author = new Author(),
                UrlFile= null},

                new Book{id= 3, title= "ASP.NET", descreption= "All Detailes ASP.NET", author = new Author(),
                UrlFile= null},

                new Book{id= 4, title= "Angular", descreption= "All Detailes Angular", author = new Author(),
                UrlFile= null}
            };
        }

        public void add(Book obj)
        {
            obj.id = book.Max(a => a.id) + 1;
            book.Add(obj);
        }

        public void delete(int id)
        {
            book.Remove(Find(id));
        }

        public Book Find(int id)
        {
            var id_book = book.Find(b => b.id == id);
            return id_book;
        }

        public IList<Book> List_Item()
        {
            return book;
        }

        public List<Book> Search(string word)
        {
            throw new NotImplementedException();
        }

        public void update(int id, Book obj)
        {
            var id_book = Find(id);

            id_book.title = obj.title;
            id_book.descreption = obj.descreption;
            id_book.author.id = obj.author.id;
            id_book.author.full_name = obj.author.full_name;
            id_book.UrlFile = obj.UrlFile;

        }
    }
}
