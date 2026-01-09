using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Practice13_1.Models;

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

5.著者ごとに書籍のタイトルと発行年を表示してください。なお、著者は誕生日の遅い順に並べてください。
*/
namespace Practice13_1 {
    class Program {
        static void Main(string[] args) {
            ResetDatabaseWithIdReset();
            var wAuthorsToRegister = new[] {
                new Author("夏目漱石", new DateTime(1867, 2, 9), Gender.Male),
                new Author("太宰治", new DateTime(1909, 6, 19), Gender.Male),
                new Author("与謝野晶子", new DateTime(1878, 12, 7), Gender.Female),
                new Author("宮沢賢治", new DateTime(1896, 8, 27), Gender.Male),
                new Author("川端康成", new DateTime(1899, 6, 14), Gender.Male),
                new Author("菊池寛", new DateTime(1888, 12, 26), Gender.Male)
            };
            var wAddedAuthors = RegisterAuthors(wAuthorsToRegister);
            DisplayAuthors(wAddedAuthors);

            Console.WriteLine($"\n{new string('=', 50)}");

            var wInitialBooksToRegister = new[] {
                CreateBookWithExistingAuthor("坊ちゃん", 2003, "夏目漱石"),
                CreateBookWithExistingAuthor("人間失格", 1990, "太宰治"),
                CreateBookWithExistingAuthor("みだれ髪", 1901, "与謝野晶子"),
                CreateBookWithExistingAuthor("銀河鉄道の夜", 1927, "宮沢賢治")
            };
            var wAddedInitialBooks = RegisterBooks(wInitialBooksToRegister);
            DisplayRegisteredBooks(wAddedInitialBooks);

            Console.WriteLine($"\n{new string('=', 50)}");

            var wNewBooksToRegister = new[] {
                CreateBookWithExistingAuthor("こころ", 1991, "夏目漱石"),
                CreateBookWithExistingAuthor("伊豆の踊子", 2003, "川端康成"),
                CreateBookWithExistingAuthor("真珠夫人", 2002, "菊池寛"),
                CreateBookWithExistingAuthor("注文の多い料理店", 2000, "宮沢賢治")
            };
            var wAddedNewBooks = RegisterBooks(wNewBooksToRegister);
            DisplayRegisteredBooks(wAddedNewBooks);

            ShowAllBooksInfo();
            DisplayBooks(GetLongestTitleBooks());
            DisplayBooks(GetOldestBooks(3));
            ShowAuthorsByBooks(GetAuthorsByBirthdayDesc());
            Console.WriteLine("\nEnterキーを押して終了してください...");
            Console.ReadKey();
        }
        #region 登録メソッド
        /// <summary>
        /// 著者をデータベースに登録する
        /// </summary>
        /// <param name="vAuthors">登録する著者のコレクション</param>
        /// <returns>登録された著者のコレクション</returns>
        static IEnumerable<Author> RegisterAuthors(IEnumerable<Author> vAuthors) {
            using (var wDataBase = new BooksDbContext()) {
                var wAddedAuthors = new List<Author>();
                foreach (var wAuthor in vAuthors) {
                    if (wAuthor == null || string.IsNullOrWhiteSpace(wAuthor.Name)) {
                        Console.WriteLine("無効な著者データがあります。");
                        continue;
                    }
                    if (wDataBase.Authors.FirstOrDefault(x => x.Name == wAuthor.Name) != null &&
                        !wAddedAuthors.Any(x => x.Name == wAuthor.Name)) {
                        Console.WriteLine($"著者「{wAuthor.Name}」は既にデータベースに存在します。");
                    }
                    wDataBase.Authors.Add(wAuthor);
                    wAddedAuthors.Add(wAuthor);
                }
                wDataBase.SaveChanges();
                return wAddedAuthors;
            }
        }

        /// <summary>
        /// 書籍をデータベースに登録する
        /// </summary>
        /// <param name="vBooks">登録する書籍のコレクション</param>
        /// <returns>登録された書籍のコレクション</returns>
        static IEnumerable<Book> RegisterBooks(IEnumerable<Book> vBooks) {
            using (var wDataBase = new BooksDbContext()) {
                var wAddedBooks = new List<Book>();
                foreach (var wBook in vBooks) {
                    if (wBook == null || string.IsNullOrWhiteSpace(wBook.Title)) {
                        Console.WriteLine($"書籍データが無効です。{wBook}");
                        continue;
                    }
                    if (wBook.Author == null) {
                        Console.WriteLine($"書籍「{wBook.Title}」の著者情報が無効です。");
                        continue;
                    }
                    var wExistingAuthor = wDataBase.Authors.FirstOrDefault(x => x.Id == wBook.Author.Id);
                    if (wExistingAuthor != null) {
                        wBook.Author = wExistingAuthor;
                    } else {
                        wDataBase.Authors.Attach(wBook.Author);
                    }
                    var wExistingBook = wDataBase.Books.FirstOrDefault(x => x.Title == wBook.Title && x.Author.Id == wBook.Author.Id);
                    if (wExistingBook != null) {
                        Console.WriteLine($"書籍「{wBook.Title}」({wBook.Author.Name}著)は既にデータベースに存在します。");
                        continue;
                    }
                    wDataBase.Books.Add(wBook);
                    wAddedBooks.Add(wBook);
                }
                wDataBase.SaveChanges();
                return wAddedBooks;
            }
        }
        #endregion

        #region 表示メソッド
        /// <summary>
        /// 著者の登録結果をコンソールに表示する
        /// </summary>
        /// <param name="vAddedAuthors">表示する著者のコレクション</param>
        static void DisplayAuthors(IEnumerable<Author> vAddedAuthors) {
            Console.WriteLine("\n--- 著者の登録 ---");
            var wAuthorList = vAddedAuthors?.ToList();
            if (wAuthorList == null || !wAuthorList.Any()) {
                Console.WriteLine("表示する著者データがありません。");
                return;
            }
            foreach (var wAuthor in wAuthorList) {
                Console.WriteLine($"著者「{wAuthor.Name}」を登録しました。");
            }
            Console.WriteLine($"登録完了: {wAuthorList.Count()}件");
        }

        /// <summary>
        /// 書籍の登録結果をコンソールに表示する
        /// </summary>
        /// <param name="vAddedBooks">表示する書籍のコレクション</param>
        static void DisplayRegisteredBooks(IEnumerable<Book> vAddedBooks) {
            Console.WriteLine("\n--- 書籍の登録 ---");
            var wBookList = vAddedBooks?.ToList();
            if (wBookList == null || !wBookList.Any()) {
                Console.WriteLine("表示する書籍データがありません。");
                return;
            }
            foreach (var wBook in wBookList) {
                Console.WriteLine($"書籍「{wBook.Title}」({wBook.Author.Name}著)を登録しました。");
            }
            Console.WriteLine($"登録完了: {wBookList.Count()}件");
        }
        #endregion

        /// <summary>
        /// 既存の著者を参照してBookオブジェクトを作成する
        /// </summary>
        /// <param name="vTitle">書籍タイトル</param>
        /// <param name="vYear">出版年</param>
        /// <param name="vAuthorName">著者名</param>
        /// <returns>作成されたBookオブジェクト</returns>
        static Book CreateBookWithExistingAuthor(string vTitle, int vYear, string vAuthorName) {
            using (var wDataBase = new BooksDbContext()) {
                var vAuthor = wDataBase.Authors.FirstOrDefault(x => x.Name == vAuthorName);
                if (vAuthor == null) {
                    Console.WriteLine($"著者「{vAuthorName}」が見つかりません。書籍「{vTitle}」をスキップします。");
                    return null;
                }
                return new Book(vTitle, vYear, vAuthor);
            }
        }

        /// <summary>
        /// すべての書籍情報を表示する
        /// </summary>
        static void ShowAllBooksInfo() {
            Console.WriteLine("\n--- 2. すべての書籍情報 ---");
            using (var wDataBase = new BooksDbContext()) {
                var wBooks = wDataBase.Books.Include(x => x.Author).ToList();
                foreach (var wBook in wBooks) {
                    Console.WriteLine($"ID: {wBook.Id}, {wBook}");
                }
                Console.WriteLine($"合計: {wBooks.Count}冊");
            }
        }

        /// <summary>
        /// タイトルが最も長い書籍を取得する
        /// </summary>
        /// <returnsタイトルが最も長い書籍のコレクション</returns>
        static IEnumerable<Book> GetLongestTitleBooks() {
            Console.WriteLine("\n--- 3. タイトルが最も長い書籍 ---");
            using (var wDataBase = new BooksDbContext()) {
                var wAllBooks = wDataBase.Books.Include(x => x.Author).ToList();
                if (!wAllBooks.Any()) {
                    return Enumerable.Empty<Book>();
                }

                var wMaxTitleLength = wAllBooks.Max(x => x.Title.Length);
                return wAllBooks.Where(x => x.Title.Length == wMaxTitleLength);
            }
        }

        /// <summary>
        /// 発行年の古い順に指定件数の書籍を取得する
        /// </summary>
        /// <param name="vCount">取得する書籍の件数</param>
        /// <returns>発行年の古い順の書籍のコレクション</returns>
        static IEnumerable<Book> GetOldestBooks(int vCount) {
            Console.WriteLine($"\n--- 4. 発行年の古い順に{vCount}冊 ---");
            using (var wDataBase = new BooksDbContext()) {
                if (vCount <= 0) {
                    return new List<Book>();
                }
                return wDataBase.Books
                    .Include(x => x.Author)
                    .OrderBy(x => x.PublishedYear)
                    .Take(vCount)
                    .ToList();
            }
        }

        /// <summary>
        /// 書籍のコレクションを表示する
        /// </summary>
        /// <param name="vBooks">表示する書籍のコレクション</param>
        static void DisplayBooks(IEnumerable<Book> vBooks) {
            var wBookList = vBooks?.ToList();
            if (wBookList == null || !wBookList.Any()) {
                Console.WriteLine("書籍が登録されていません。");
                return;
            }

            foreach (var wBook in wBookList) {
                Console.WriteLine(wBook);
            }
        }

        /// <summary>
        /// 誕生日の降順で著者を取得する（書籍も含む）
        /// </summary>
        /// <returns>誕生日の遅い順の著者のコレクション</returns>
        static IEnumerable<Author> GetAuthorsByBirthdayDesc() {
            using (var wDataBase = new BooksDbContext()) {
                return wDataBase.Authors.Include(x => x.Books).OrderByDescending(x => x.Birthday).ToList();
            }
        }

        /// <summary>
        /// 著者のコレクションを著者別書籍形式で表示する
        /// </summary>
        /// <param name="vAuthors">表示する著者のコレクション</param>
        /// <param name="vTitle">表示セクションのタイトル</param>
        static void ShowAuthorsByBooks(IEnumerable<Author> vAuthors) {
            Console.WriteLine($"\n--- 5. 著者別書籍表示（誕生日の遅い順） ---");
            if (vAuthors == null || !vAuthors.Any()) {
                Console.WriteLine("著者が登録されていません。");
                return;
            }

            foreach (var wAuthor in vAuthors) {
                Console.WriteLine($"\n{wAuthor}");
                foreach (var wBook in wAuthor.Books.OrderBy(x => x.PublishedYear)) {
                    Console.WriteLine($"  - {wBook.ToStringWithoutAuthor()}");
                }
            }
            Console.WriteLine();
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
