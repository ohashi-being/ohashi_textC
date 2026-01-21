using System;
using System.Collections.Generic;
using System.Linq;

/* 問題15.1
 
本文で利用したBook、Category、Libraryクラスを利用して、以下の処理を実装してください。

1.Libraryクラスにコンストラクタを追加し、本章の最初に示した書籍のカテゴリデータと書籍データの値を
  CategoryプロパティとBooksプロパティにセットするコードを書いてください。

2.最も価格の高い書籍を抽出し、その書籍の情報を表示してください。

3.発行年ごとに書籍の数をカウントして、その結果をコンソールに表示してください。

4.発行年、価格の順（それぞれ値の大きい順）に書籍を並べ替えて、その結果をコンソールに表示してください。
  例：2016年 4800円 Microsoft Azureサーバー構築(Server)

5.2016年に発行された書籍のカテゴリ一覧を取得し、コンソールに表示してください。

6.GroupByメソッドを使い、カテゴリごとに書籍を分類し、カテゴリ名をアルファベット順に並べ替え、
  その結果をコンソールに表示してください。

7.カテゴリ"Development"の書籍に対して、発行年ごとに分類しその結果をコンソールに表示してください。

8.GroupJoinメソッドを使って4冊以上発行されているカテゴリ名を求め、その結果をコンソールに表示してください。

*/

namespace Practice15_1 {
    class Program {
        static void Main(string[] args) {
            var wBooks = Library.Books;
            if (wBooks == null || !wBooks.Any()) {
                Console.WriteLine("書籍データが存在しません。");
                return;
            }

            var wCategories = Library.Categories;
            if (wCategories == null || !wCategories.Any()) {
                Console.WriteLine("カテゴリデータが存在しません。");
                return;
            }

            // 解答2
            Console.WriteLine("----------- 解答2 -----------");
            var wMaxPrice = wBooks.Max(x => x.Price);
            var wMostExpensiveBooks = wBooks
                .Join(wCategories,
                      x => x.CategoryId,
                      x => x.Id,
                      (x, y) => new {
                          Title = x.Title,
                          CategoryID = x.CategoryId,
                          CategoryName = y.Name,
                          Price = x.Price,
                          PublishedYear = x.PublishedYear
                      })
                .Where(x => x.Price == wMaxPrice)
                .OrderBy(x => x.Title);
            foreach (var wBook in wMostExpensiveBooks)
                Console.WriteLine($"発行年:{wBook.PublishedYear}, カテゴリ:{wBook.CategoryName}, 価格:{wBook.Price}, タイトル:{wBook.Title}");
            // 解答3
            Console.WriteLine($"{Environment.NewLine}----------- 解答3 -----------");
            var wBookCountByYear = wBooks.GroupBy(x => x.PublishedYear)
                                         .OrderBy(x => x.Key)
                                         .Select(x => new { Year = x.Key, Count = x.Count() });
            foreach (var wYear in wBookCountByYear) {
                Console.WriteLine($"発行年:{wYear.Year}, 冊数:{wYear.Count}");
            }
            // 解答4
            Console.WriteLine($"{Environment.NewLine}----------- 解答4 -----------");
            var wSortedBooks = wBooks.Join(wCategories,
                                       x => x.CategoryId,
                                       x => x.Id,
                                       (x, y) => new {
                                           PublishedYear = x.PublishedYear,
                                           Price = x.Price,
                                           Title = x.Title,
                                           CategoryName = y.Name,
                                       })
                                 .OrderByDescending(x => x.PublishedYear)
                                 .ThenByDescending(x => x.Price);
            foreach (var wSortedBook in wSortedBooks) {
                Console.WriteLine($"{wSortedBook.PublishedYear}年 {wSortedBook.Price}円 {wSortedBook.Title}({wSortedBook.CategoryName})");
            }
            // 解答5
            Console.WriteLine($"{Environment.NewLine}----------- 解答5 -----------");
            int wTargetYear = 2016;
            var wCategoriesByYear = GetCategoriesByYear(wTargetYear);
            if (wCategoriesByYear.Any()) {
                foreach (var wCategoryByYear in wCategoriesByYear) {
                    Console.WriteLine(wCategoryByYear);
                }
            } else {
                Console.WriteLine($"{wTargetYear}年に発行された書籍のカテゴリは存在しません。");
            }
            // 解答6
            Console.WriteLine($"{Environment.NewLine}----------- 解答6 -----------");
            var wGroupedBooksByCategory = wBooks.GroupBy(x => x.CategoryId)
                        .Join(wCategories,
                              x => x.Key,
                              x => x.Id,
                              (x, y) => new {
                                  CategoryName = y.Name,
                                  Books = x.OrderBy(z => z.Title)
                                           .Select(z => new { Name = z.Title })
                              })
                        .OrderBy(x => x.CategoryName);
            foreach (var wCategory in wGroupedBooksByCategory) {
                Console.WriteLine($"#{wCategory.CategoryName}");
                foreach (var wBook in wCategory.Books) {
                    Console.WriteLine($" {wBook.Name}");
                }
            }
            // 解答7
            Console.WriteLine($"{Environment.NewLine}----------- 解答7 -----------");
            var wTargetCategoryName = "Development";
            var wTargetCategory = wCategories.FirstOrDefault(y => y.Name == wTargetCategoryName);
            if (wTargetCategory != null) {
                var wGroupedBooksByYear = wBooks
                        .Where(x => x.CategoryId == wTargetCategory.Id)
                        .GroupBy(x => x.PublishedYear)
                        .OrderBy(x => x.Key);
                foreach (var wYear in wGroupedBooksByYear) {
                    Console.WriteLine($"#{wYear.Key}年");
                    foreach (var wBook in wYear.OrderBy(x => x.Title)) {
                        Console.WriteLine($" {wBook.Title}");
                    }
                }
            } else {
                Console.WriteLine($"カテゴリ'{wTargetCategoryName}'は存在しません。");
            }
            // 解答8
            Console.WriteLine($"{Environment.NewLine}----------- 解答8 -----------");
            var wMinBookCount = 4;
            var wCategoriesWithBooks = wCategories.GroupJoin(wBooks,
                                    x => x.Id,
                                    x => x.CategoryId,
                                    (x, y) => new {
                                        CategoryName = x.Name,
                                        BookCount = y.Count()
                                    })
                            .Where(x => x.BookCount >= wMinBookCount)
                            .OrderBy(x => x.CategoryName)
                            .ToList();
            if (wCategoriesWithBooks.Any()) {
                foreach (var wCategory in wCategoriesWithBooks) {
                    Console.WriteLine($"カテゴリ名:{wCategory.CategoryName}, 冊数:{wCategory.BookCount}");
                }
            } else {
                Console.WriteLine($"{wMinBookCount}冊以上発行されているカテゴリは見つかりませんでした。");
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        // 解答5
        /// <summary>
        /// 対象年に発行された書籍のカテゴリ一覧を取得する
        /// </summary>
        /// <param name="vYear">対象年</param>
        /// <returns>対象年に発行された書籍のカテゴリ一覧</returns>
        static List<string> GetCategoriesByYear(int vYear) {
            var wCategories = Library.Books.Where(x => x.PublishedYear == vYear)
                         .Join(Library.Categories,
                               x => x.CategoryId,
                               x => x.Id,
                               (x, y) => y.Name)
                         .Distinct()
                         .OrderBy(x => x)
                         .ToList();
            return wCategories;
        }
    }
}
