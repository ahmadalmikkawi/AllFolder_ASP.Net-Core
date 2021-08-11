using Book_Store.Modules;
using Book_Store.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Controllers
{
    public class controller_book : Controller
    {
        private readonly interface_repository<Book> my_books;
        private readonly interface_repository<Author> my_authors;
        private readonly IHostingEnvironment  Host;



        public controller_book(interface_repository<Book> books,
            interface_repository<Author> authors, IHostingEnvironment host)
        {
            this.my_books = books;
            this.my_authors = authors;
            this.Host = host;
        }

        // GET: controller_book
        [Route("")]
        public ActionResult Index()
        {
            var book = my_books.List_Item();
            return View(book);
        }

        // GET: controller_book/Details/5
        public ActionResult Details(int id)
        {
            var book = my_books.Find(id);
            return View(book);
        }

        // GET: controller_book/Create
        public ActionResult Create()
        {
            AddAttributeToBook book = new AddAttributeToBook()
            {
                 authors = SelectList()
            };

            return View(book);
        }

        // POST: controller_book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddAttributeToBook book)
        {
            try
            {
                string pathFile = null;

                if(ModelState.IsValid)
                {
                    if (book.Files != null)
                    {
                        //====== Start Store Files In Application:
                        //path for folder (AllFiles)
                        string pathAllFiles = Path.Combine(Host.WebRootPath, "AllFiles");
                        //path for file
                        pathFile = book.Files.FileName;
                        //All path to store file in Folder (AllFiles)
                        string AllPath = Path.Combine(pathAllFiles, pathFile);
                        // Execute Copy File In Folder (AllFiles)
                         book.Files.CopyTo(new FileStream(AllPath, FileMode.Create));
                        //====== End Store Files In Application:                       
                    }

                    if (book.authorId == 0)
                    {
                        ViewBag.ErrorMess = "Please Choose Any Author";

                        var display_book = new AddAttributeToBook()
                        {
                            authors = SelectList()
                        };
                        return View(display_book);
                    }
                    else
                    {
                        Book bo = new Book()
                        {
                            title = book.title,
                            descreption = book.descreption,
                            author = my_authors.Find(book.authorId),
                            UrlFile = pathFile
                        };

                        my_books.add(bo);
                        return RedirectToAction(nameof(Index));
                    }
                }

               
                var my_book = new AddAttributeToBook()
                {
                    authors = SelectList()
                };

                return View(my_book);
            }
              
            catch
            {
                return View(book);
            }
        }

        // GET: controller_book/Edit/5
        public ActionResult Edit(int id)
        {
            var book = my_books.Find(id);
            int result_auth;
            if (book.author == null)
            {
                result_auth = book.author.id = 0;
            }else
            {
                result_auth = book.author.id;
            }

            AddAttributeToBook EditBook = new AddAttributeToBook()
            {
                id = book.id,
                title = book.title,
                descreption = book.descreption,
                authorId = result_auth,
                authors = SelectList(),
                url = book.UrlFile
            };

            return View(EditBook);
        }

        // POST: controller_book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddAttributeToBook BookEdit)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string pathFile = BookEdit.url;

                    if (BookEdit.Files != null)
                   {
                     
                        //====== Start Store Files In Application:
                        //path for folder (AllFiles)
                        string pathAllFiles = Path.Combine(Host.WebRootPath, "AllFiles");
                        //path for file
                        pathFile = BookEdit.Files.FileName;
                        //All path to store file in Folder (AllFiles)
                        string AllPath = Path.Combine(pathAllFiles, pathFile);

                        // Execute Copy File In Folder (AllFiles)
                        BookEdit.Files.CopyTo(new FileStream(AllPath, FileMode.Create));



                        //====== End Store Files In Application:
                 
                }


                    if (BookEdit.authorId == 0)
                    {
                        ViewBag.ErrorMessage = "Error, Please Choose Any Author";

                        var bo = new AddAttributeToBook()
                        {
                            authors = SelectList()
                        };
                        return View(bo);
                    }
                    else
                    {
                        var auth = my_authors.Find(BookEdit.authorId);
                        Book book = new Book()
                        {
                            id = BookEdit.id,
                            title = BookEdit.title,
                            descreption = BookEdit.descreption,
                            author = auth,
                            UrlFile = pathFile
                        };

                        my_books.update(BookEdit.id, book);

                        return RedirectToAction(nameof(Index));
                    }
                }

                var my_bo = new AddAttributeToBook()
                {
                    authors = SelectList()
                };
                return View(my_bo);
            }
            catch
            {
                return View();
            }
        }

        // GET: controller_book/Delete/5
        public ActionResult Delete(int id)
        {
            var bookId = my_books.Find(id);
            return View(bookId);
        }

        // POST: controller_book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book return_book)
        {
            try
            {
                my_books.delete(return_book.id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public List<Author> SelectList()
        {
            var MyList = my_authors.List_Item().ToList();
            MyList.Insert(0, new Author() { id = 0, full_name = " **** Please Choose Any Author **** " });
            return MyList;
        }

        public ActionResult SearchBook(string word)
        {
            var Result_Search = my_books.Search(word);
            return View("Index", Result_Search);
        }
    }
}
