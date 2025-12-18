using Practice13_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 問題13.1
本文で利用したデータベースを利用し、以下のコードを書いてください。
1.以下の2名の著者と4冊の書籍を追加してください。

2.すべての書籍情報を著者名とともに表示するコードを書き、上記1.のデータが正しく追加されたか確認してください。

3.タイトルの最も長い書籍を求めてください。複数ある場合は、すべてを求めてください。

4.発行年の古い順に3冊だけ書籍を取得し、そのタイトルと著者名を求めてください。

5.著者事に書籍のタイトルと発行年を表示してください。なお、著者は誕生日の遅い順に並べてください。
*/
namespace Practice13_1 {
    internal class Program {
        static void Main(string[] args) {
            AddBooks();
        }
        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子",
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢賢治",
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }
        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author1 = db.Authors.Single(x => x.Name == "与謝野晶子");
                var book1 = new Book {
                    Title = "みだれ髪",
                    PublishedYear = 1901,
                    Author = author1
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(x => x.Name == "宮沢賢治");
                var book2 = new Book {
                    Title = "銀河鉄道の夜",
                    PublishedYear = 1927,
                    Author = author2
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }
        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                         .Where(x => x.Author.Name.StartsWith("夏目"))
                         .ToList();
            }
        }
        static void DisplayAllBooks() {
            var books = GetBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title}{book.PublishedYear}");
            }
            Console.ReadLine();
        }
        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);
                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();
                Console.WriteLine($"{book1.Id},{book2.Id}");
            }
        }


    }
}
