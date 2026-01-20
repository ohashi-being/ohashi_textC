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
            if (!IsModelCompatibleWithDatabase()) RecreateDatabase();
            ResetDatabaseWithIdReset();

            using (var wDataBase = new BooksDbContext()) {
                var wAuthorsToRegister = new[] {
                    new Author("夏目漱石", new DateTime(1867, 2, 9), GenderEnum.Male),
                    new Author("太宰治", new DateTime(1909, 6, 19), GenderEnum.Male),
                    new Author("与謝野晶子", new DateTime(1878, 12, 7), GenderEnum.Female),
                    new Author("宮沢賢治", new DateTime(1896, 8, 27), GenderEnum.Male),
                    new Author("川端康成", new DateTime(1899, 6, 14), GenderEnum.Male),
                    new Author("菊池寛", new DateTime(1888, 12, 26), GenderEnum.Male)};

                RegisterAuthors(wDataBase, wAuthorsToRegister);
                DisplayRegisteredAuthors(wAuthorsToRegister);

                var wBooksToRegister = new[] {
                    new Book("坊ちゃん", 2003, wAuthorsToRegister[0]),
                    new Book("人間失格", 1990, wAuthorsToRegister[1]),
                    new Book("みだれ髪", 1901, wAuthorsToRegister[2]),
                    new Book("銀河鉄道の夜", 1927, wAuthorsToRegister[3]),
                    new Book("こころ", 1991, wAuthorsToRegister[0]),
                    new Book("伊豆の踊子", 2003, wAuthorsToRegister[4]),
                    new Book("真珠夫人", 2002, wAuthorsToRegister[5]),
                    new Book("注文の多い料理店", 2000, wAuthorsToRegister[3])};

                RegisterBooks(wDataBase, wBooksToRegister);
                DisplayRegisteredBooks(wBooksToRegister);
            }

            ShowAllBooksInfo();
            DisplayBooks(GetLongestTitleBooks());
            DisplayBooks(GetOldestBooks(3));
            ShowAuthorsByBooks(GetAuthorsByBirthdayDesc());

            Console.WriteLine("\nEnterキーを押して終了してください...");
            Console.ReadKey();
        }

        #region データベース初期化
        /// <summary>
        /// データベースとモデルの互換性をチェックする
        /// </summary>
        /// <returns>互換性があるかどうか</returns>
        static bool IsModelCompatibleWithDatabase() {
            using (var wDataBase = new BooksDbContext()) {
                try {
                    if (!wDataBase.Database.Exists()) {
                        Console.WriteLine("データベースが存在しません。");
                        return false;
                    }

                    bool wIsCompatible = wDataBase.Database.CompatibleWithModel(throwIfNoMetadata: false);

                    if (wIsCompatible) {
                        Console.WriteLine("データベーススキーマは互換性があります。");
                    } else {
                        Console.WriteLine("データベーススキーマがモデルと互換性がありません。");
                    }

                    return wIsCompatible;
                } catch (Exception ex) {
                    Console.WriteLine($"互換性チェック中にエラーが発生しました: {ex.Message}");
                    return false;
                }
            }
        }

        /// <summary>
        /// データベースを再作成する
        /// </summary>
        static void RecreateDatabase() {
            using (var wDataBase = new BooksDbContext()) {
                try {
                    if (wDataBase.Database.Exists()) {
                        Console.WriteLine("既存のデータベースを削除しています...");
                        wDataBase.Database.Delete();
                    }

                    Console.WriteLine("データベースを作成しています...");
                    wDataBase.Database.Create();
                    Console.WriteLine("データベースの作成が完了しました。");
                } catch (Exception ex) {
                    Console.WriteLine($"データベースの再作成中にエラーが発生しました: {ex.Message}");
                    throw;
                }
            }
        }

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
        #endregion

        #region データ登録
        /// <summary>
        /// 著者をデータベースに登録する
        /// </summary>
        /// <param name="vDataBase">データベースコンテキスト</param>
        /// <param name="vAuthors">登録する著者のコレクション</param>
        static void RegisterAuthors(BooksDbContext vDataBase, IEnumerable<Author> vAuthors) {
            if (vAuthors == null) {
                Console.WriteLine("登録する著者データがありません。");
                return;
            }

            foreach (var wAuthor in vAuthors) {
                if (wAuthor == null || string.IsNullOrWhiteSpace(wAuthor.Name)) {
                    Console.WriteLine("無効な著者データがあります。");
                    continue;
                }
                if (IsAuthorExists(vDataBase, wAuthor)) {
                    Console.WriteLine($"著者「{wAuthor.Name}」は既に登録されています。");
                    continue;
                }

                vDataBase.Authors.Add(wAuthor);
            }

            vDataBase.SaveChanges();
        }

        /// <summary>
        /// 書籍をデータベースに登録する
        /// </summary>
        /// <param name="vDataBase">データベースコンテキスト</param>
        /// <param name="vBooks">登録する書籍のコレクション</param>
        static void RegisterBooks(BooksDbContext vDataBase, IEnumerable<Book> vBooks) {
            if (vBooks == null) {
                Console.WriteLine("登録する書籍データがありません。");
                return;
            }

            foreach (var wBook in vBooks) {
                if (wBook == null || string.IsNullOrWhiteSpace(wBook.Title)) {
                    Console.WriteLine("無効な書籍データがあります。");
                    continue;
                }

                if (wBook.Author == null) {
                    Console.WriteLine($"書籍「{wBook.Title}」の著者情報が無効です。");
                    continue;
                }
                if (IsBookExists(vDataBase, wBook)) {
                    Console.WriteLine($"書籍「{wBook.Title}」は既に登録されています。");
                    continue;
                }

                vDataBase.Books.Add(wBook);
            }

            vDataBase.SaveChanges();
        }
        #endregion

        #region データ取得
        /// <summary>
        /// タイトルが最も長い書籍を取得する
        /// </summary>
        /// <returns>タイトルが最も長い書籍のコレクション</returns>
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
        /// 誕生日の降順で著者を取得する（書籍も含む）
        /// </summary>
        /// <returns>誕生日の遅い順の著者のコレクション</returns>
        static IEnumerable<Author> GetAuthorsByBirthdayDesc() {
            using (var wDataBase = new BooksDbContext()) {
                return wDataBase.Authors.Include(x => x.Books).OrderByDescending(x => x.Birthday).ToList();
            }
        }
        #endregion

        #region データ表示
        /// <summary>
        /// 著者の登録結果を表示する
        /// </summary>
        /// <param name="vAuthors">登録した著者のコレクション</param>
        static void DisplayRegisteredAuthors(IEnumerable<Author> vAuthors) {
            Console.WriteLine($"{Environment.NewLine}---著者の登録 ---");

            var wAuthorList = vAuthors.ToList();

            if (!wAuthorList.Any()) {
                Console.WriteLine("表示するデータがありません。");
                return;
            }

            foreach (var wAuthor in wAuthorList) {
                Console.WriteLine($"著者「{wAuthor.Name}」を登録しました。");
            }

            Console.WriteLine($"登録完了: {wAuthorList.Count}件");
        }

        /// <summary>
        /// 書籍の登録結果を表示する
        /// </summary>
        /// <param name="vBooks">登録した書籍のコレクション</param>
        static void DisplayRegisteredBooks(IEnumerable<Book> vBooks) {
            Console.WriteLine($"{Environment.NewLine}--- 書籍の登録 ---");

            var wBookList = vBooks.ToList();

            if (!wBookList.Any()) {
                Console.WriteLine("表示するデータがありません。");
                return;
            }

            foreach (var wBook in wBookList) {
                Console.WriteLine($"書籍「{wBook.Title}」({wBook.Author.Name}著)を登録しました。");
            }

            Console.WriteLine($"登録完了: {wBookList.Count}件");
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
        /// 著者のコレクションを著者別書籍形式で表示する
        /// </summary>
        /// <param name="vAuthors">表示する著者のコレクション</param>
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
        #endregion

        #region 存在チェック
        /// <summary>
        /// 著者が既にデータベースに存在するかチェックする
        /// </summary>
        /// <param name="vDataBase">データベースコンテキスト</param>
        /// <param name="vAuthor">チェックする著者</param>
        /// <returns>存在する場合はtrue</returns>
        static bool IsAuthorExists(BooksDbContext vDataBase, Author vAuthor) {
            if (vAuthor == null || string.IsNullOrWhiteSpace(vAuthor.Name)) {
                return false;
            }
            return vDataBase.Authors.Any(x => x.Name == vAuthor.Name);
        }

        /// <summary>
        /// 書籍が既にデータベースに存在するかチェックする
        /// </summary>
        /// <param name="vDataBase">データベースコンテキスト</param>
        /// <param name="vBook">チェックする書籍</param>
        /// <returns>存在する場合はtrue</returns>
        static bool IsBookExists(BooksDbContext vDataBase, Book vBook) {
            if (vBook == null || string.IsNullOrWhiteSpace(vBook.Title)) {
                return false;
            }
            if (vBook.Author == null) {
                return false;
            }
            return vDataBase.Books.Any(x => x.Title == vBook.Title && x.Author.Id == vBook.Author.Id);
        }
        #endregion
    }
}