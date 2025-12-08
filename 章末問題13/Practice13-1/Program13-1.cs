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
            InsertBooks();
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
