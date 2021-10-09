using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Models.Repositories;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository<booksModel> bookRepository;
        private readonly IBookRepository<AutherModel> autherrepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public BookController(IBookRepository<booksModel> bookRepository, IBookRepository<AutherModel> autherrepository,IHostingEnvironment hostingEnvironment)
        {
            this.bookRepository = bookRepository;
            this.autherrepository = autherrepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: Book
        public ActionResult Index()
        {
            var book = bookRepository.List();
            return View(book);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var bookDetails = bookRepository.Find(id);

            return View(bookDetails);
        }
        List<AutherModel> listauters()
        {
            List<AutherModel> autherData = autherrepository.List().ToList();
            autherData.Insert(0,new AutherModel()
            {
                Id = -1,
                FullName = "Enter an Auther !",
            });
           
            return autherData;
        }

        // GET: Book/Createv
        public ActionResult Create()
        {
            var bookCreate = new AuterBookViewModel {
                authers = listauters()
            };
            return View(bookCreate);
        }   

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuterBookViewModel booksModel)
        {
            if (booksModel is null)
            {
                throw new ArgumentNullException(nameof(booksModel));
            }

            try
            {
                String pathName = UploadFile(booksModel.File)?? String.Empty;             
               if (booksModel.AuterId==-1)
                {
                    ViewBag.message = "Please Select an AUTER";
                    var bookCreates = new AuterBookViewModel
                    {
                        authers = listauters()
                    };
                    return View(bookCreates);
                }
                var auther = autherrepository.Find(booksModel.AuterId);
                booksModel books = new booksModel() {
                    Auther = auther,
                    Id = booksModel.BookId,
                    Descrption = booksModel.Descrption,
                    Title = booksModel.Title,
                    ImageUrl = pathName,
                };
                bookRepository.Add(books);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)

        {
            var editTem = bookRepository.Find(id);
            var authorId = editTem.Auther == null ? editTem.Auther.Id = 0 : editTem.Auther.Id;
            var datanew = new AuterBookViewModel
            {
                Descrption = editTem.Descrption,
                Title = editTem.Title,
                AuterId = authorId,
                authers = autherrepository.List().ToList(),
                BookId= editTem.Id,
                ImageUrl= editTem.ImageUrl,

            };

            return View(datanew);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuterBookViewModel booksModel)
        {
            try
            {
                string fileName = UploadFileEdit(booksModel.File, booksModel.ImageUrl);

                var author = autherrepository.Find(booksModel.AuterId);
                booksModel book = new booksModel
                {
                    Id = booksModel.BookId,
                    Title = booksModel.Title,
                    Descrption = booksModel.Descrption,
                    Auther = author,
                    ImageUrl = fileName
                };
                bookRepository.Update(book, booksModel.BookId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)

        {
            var delItem = bookRepository.Find(id);
            return View(delItem);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, booksModel bookRebo)
        {
            try
            {
                bookRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(String input)
        {
          var booksSearch=  bookRepository.Search(input);
            return View("Index", booksSearch) ;
        }
        string UploadFileEdit(IFormFile file, string imageUrl)
        {
            if (file != null)
            {
                string uploads = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
                string newPath = Path.Combine(uploads, file.FileName);
                string oldPath = Path.Combine(uploads, imageUrl);
                if (oldPath != newPath)
                {
                    System.IO.File.Delete(oldPath);
                    file.CopyTo(new FileStream(newPath, FileMode.Create));
                }

                return file.FileName;
            }

            return imageUrl;
        }
        String UploadFile(IFormFile file)
        {
            if (file != null)
            {
                String path = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
                String fullpath = Path.Combine(path, file.FileName);
                file.CopyTo(new FileStream(fullpath, FileMode.Create));
                return file.FileName; 
            }
            return null;
        }
       
    }
    
   
}