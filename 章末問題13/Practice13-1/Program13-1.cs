using Practice13_1.Models;
using System;
using System.Linq;

/* 問題13.1
本文で利用したデータベースを利用し、以下のコードを書いてください。
1.以下の2名の著者と4冊の書籍を追加してください。
菊池寛（1888年12月26日生、男性）
川端康成（1899年6月14日生、男性）

こころ（1991年、夏目漱石）
伊豆の踊子（2003年、川端康成）
真珠夫人（2002年、菊池寛）
注文の多い料理店（2000年、宮沢賢治）

2.すべての書籍情報を著者名とともに表示するコードを書き、上記1.のデータが正しく追加されたか確認してください。

3.タイトルの最も長い書籍を求めてください。複数ある場合は、すべてを求めてください。

4.発行年の古い順に3冊だけ書籍を取得し、そのタイトルと著者名を求めてください。

5.著者事に書籍のタイトルと発行年を表示してください。なお、著者は誕生日の遅い順に並べてください。
*/
namespace Practice13_1 {
    class Program {
        static void Main(string[] args) {
            ResetDatabaseWithIdReset();
            InsertBooks(
                new Book("坊ちゃん", 2003, "夏目漱石", new DateTime(1867, 2, 9), "M"),
                new Book("人間失格", 1990, "太宰治", new DateTime(1909, 6, 19), "M"),
                new Book("みだれ髪", 1901, "与謝野晶子", new DateTime(1878, 12, 7), "F"),
                new Book("銀河鉄道の夜", 1927, "宮沢賢治", new DateTime(1896, 8, 27), "M"));
            Console.WriteLine($"\n{new string('=', 50)}");
            InsertBooks(
                new Book("こころ", 1991, "夏目漱石", new DateTime(1867, 2, 9), "M"),
                new Book("伊豆の踊子", 2003, "川端康成", new DateTime(1899, 6, 14), "M"),
                new Book("真珠夫人", 2002, "菊池寛", new DateTime(1888, 12, 26), "M"),
                new Book("注文の多い料理店", 2000, "宮沢賢治", new DateTime(1896, 8, 27), "M"),
                new Book(null, 2025, null, new DateTime(2001, 7, 14), "F"));
            ShowAllBooksInfo();
            DisplayLongestTitleBooks();
            DisplayOldestThreeBooks();
            DisplayBooksByAuthorBirthdayDesc();
            Console.WriteLine("\nEnterキーを押して終了してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 書籍の情報をデータベースに追加する
        /// </summary>
        /// <param name="vBooks">追加する書籍</param>
        static void InsertBooks(params Book[] vBooks) {
            using (var wDataBase = new BooksDbContext()) {
                Console.WriteLine("\n--- 以下のデータを追加 ---");
                foreach (var wBook in vBooks) {
                    var wAuthor = GetAuthorInfo(wDataBase, wBook.Author);
                    GetBookInfo(wDataBase, wBook, wAuthor);
                }
                wDataBase.SaveChanges();
            }
        }
        /// <summary>
        /// 著者の情報を取得する
        /// </summary>
        /// <param name="vDataBase">データベースコンテキスト</param>
        /// <param name="vAuthor">情報を取得したい著者</param>
        /// <returns>著書の情報</returns>
        static Author GetAuthorInfo(BooksDbContext vDataBase, Author vAuthor) {
            if (vAuthor == null || String.IsNullOrWhiteSpace(vAuthor.Name)) {
                Console.WriteLine("著者の名前が設定されていません。スキップします。");
                return null;
            }
            var wExistAuthor = vDataBase.Authors.FirstOrDefault(x => x.Name == vAuthor.Name);
            if (wExistAuthor != null) {
                Console.WriteLine($"著者「{vAuthor.Name}」は既に存在します。");
                return wExistAuthor;
            }
            var wNewAuthor = new Author(vAuthor.Name, vAuthor.Birthday, vAuthor.Gender);
            vDataBase.Authors.Add(wNewAuthor);
            Console.WriteLine($"著者「{vAuthor.Name}」を追加しました。");
            return wNewAuthor;
        }
        /// <summary>
        /// 書籍の情報を取得する
        /// </summary>
        /// <param name="vDataBase">データベースコンテキスト</param>
        /// <param name="vBook">追加する書籍の情報</param>
        /// <param name="vAuthor"></param>
        static void GetBookInfo(BooksDbContext vDataBase, Book vBook, Author vAuthor) {
            if (String.IsNullOrWhiteSpace(vBook.Title)) {
                Console.WriteLine($"タイトルが設定されていません。スキップします。");
                return;
            }
            if (vAuthor == null) {
                Console.WriteLine($"著者情報が無効です。スキップします。");
                return;
            }
            var wExistBook = vDataBase.Books.FirstOrDefault(x => x.Title == vBook.Title && x.Author.Name == vAuthor.Name);
            if (wExistBook != null) {
                Console.WriteLine(
                    $"書籍「{vBook.Title}」({vAuthor.Name}著) は既に存在します。"
                );
                return;
            }
            var wNewBook = new Book(vBook.Title, vBook.PublishedYear, vAuthor);
            vDataBase.Books.Add(wNewBook);
            Console.WriteLine(
                $"書籍「{vBook.Title}」({vAuthor.Name}著) を追加しました。"
            );
        }
        /// <summary>
        /// すべての書籍情報を表示する
        /// </summary>
        static void ShowAllBooksInfo() {
            using (var wDataBase = new BooksDbContext()) {
                Console.WriteLine("\n--- 2. すべての書籍情報 ---");
                var wBooks = wDataBase.Books.Include("Author").ToList();
                foreach (var wBook in wBooks) {
                    Console.WriteLine($"ID: {wBook.Id}, {wBook}");
                }
                Console.WriteLine($"合計: {wBooks.Count}冊");
            }
        }
        /// <summary>
        /// タイトルが最も長い書籍を表示する
        /// </summary>
        static void DisplayLongestTitleBooks() {
            using (var wDataBase = new BooksDbContext()) {
                Console.WriteLine("\n--- 3. タイトルが最も長い書籍 ---");
                if (!wDataBase.Books.Any()) {
                    Console.WriteLine("書籍が登録されていません。");
                    return;
                }
                var wMaxTitleLength = wDataBase.Books.Max(x => x.Title.Length);
                var wLongestBooks = wDataBase.Books.Include("Author").Where(x => x.Title.Length == wMaxTitleLength).ToList();
                foreach (var wBook in wLongestBooks) {
                    Console.WriteLine(wBook);
                }
            }
        }
        /// <summary>
        /// 発行年の古い順に3冊表示する
        /// </summary>
        static void DisplayOldestThreeBooks() {
            using (var wDataBase = new BooksDbContext()) {
                Console.WriteLine("\n--- 4. 発行年の古い順に3冊 ---");
                if (!wDataBase.Books.Any()) {
                    Console.WriteLine("書籍が登録されていません。");
                    return;
                }
                var wOldBooks = wDataBase.Books.Include("Author").OrderBy(x => x.PublishedYear).Take(3).ToList();
                foreach (var wBook in wOldBooks) {
                    Console.WriteLine(wBook);
                }
            }
        }
        /// <summary>
        /// 著者別に書籍の情報を表示する
        /// 著者は誕生日の遅い順（降順）で並べ、各著者の書籍は発行年の古い順で表示
        /// </summary>
        static void DisplayBooksByAuthorBirthdayDesc() {
            using (var wDataBase = new BooksDbContext()) {
                Console.WriteLine("\n--- 5. 著者別書籍表示（誕生日の遅い順） ---");
                var wAuthors = wDataBase.Authors.Include("Books").OrderByDescending(x => x.Birthday).ToList();
                if (!wAuthors.Any()) {
                    Console.WriteLine("著者が登録されていません。");
                    return;
                }
                foreach (var wAuthor in wAuthors) {
                    Console.WriteLine($"\n{wAuthor}");
                    foreach (var wBook in wAuthor.Books.OrderBy(x => x.PublishedYear)) {
                        Console.WriteLine($"  - {wBook.ToStringWithoutAuthor()}");
                    }
                }
                Console.WriteLine();
            }
        }
        // 削除用に保管しています
        /// <summary>
        /// データをリセットする（IDもリセット）
        /// </summary>
        static void ResetDatabaseWithIdReset() {
            using (var wDataBase = new BooksDbContext()) {
                wDataBase.Books.RemoveRange(wDataBase.Books);
                wDataBase.Authors.RemoveRange(wDataBase.Authors);
                wDataBase.SaveChanges();
                wDataBase.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Books', RESEED, 0)");
                wDataBase.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Authors', RESEED, 0)");
                Console.WriteLine("データベースをリセットしました。次のIDは1から始まります。");
            }
        }
    }
}
