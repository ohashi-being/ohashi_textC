using System;
using System.Collections.Generic;
using System.Linq;
/* 問題6.2
次のようなリストが定義されています。
var wBooks = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
};
このwBooksリストに対して、以下のコードを書いてください。

1.wBooksの中で、タイトルが"ワンダフル・C#ライフ"である書籍の価格とページ数を表示するコードを書いてください。

2.wBooksの中で、タイトルに"C#"が含まれている書籍が何冊あるかカウントするコードを書いてください。

3.wBooksの中で、タイトルに"C#"が含まれている書籍の平均ページ数を求めるコードを書いてください。

4.wBooksの中で、価格が4000円以上の本で最初に見つかった書籍のタイトルを表示するコードを書いてください。

5.wBooksの中で、価格が4000円未満の本の中で最大のページ数を求めるコードを書いてください。

6.wBooksの中で、ページ数が400ページ以上の書籍を、価格の高い順に表示（タイトルと価格を表示）するコードを書いてください。

7.wBooksの中で、タイトルに"C#"が含まれていてかつ500ページ以下の本を見つけ、本のタイトルを表示するコードを書いてください。
  複数見つかった場合は、そのすべてを表示してください。
*/
namespace Practice6_2 {
    internal class Program {
        static void Main(string[] args) {
            var wBooks = new List<Book> {
               new Book ("C#プログラミングの新常識" , 3800 , 378 ),
               new Book ( "ラムダ式とLINQの極意" , 2500 , 312),
               new Book ("ワンダフル・C#ライフ" , 2900 , 385),
               new Book ("一人で学ぶ並列処理プログラミング" , 4800 , 464),
               new Book ("フレーズで覚えるC#入門" , 5300 , 604),
               new Book ("私でも分かったASP.NET MVC" , 3200 , 453),
               new Book ("楽しいC#プログラミング教室" , 2540 , 348),
            };
            // 1の解答
            Console.WriteLine("--------------問題1---------------");
            ShowBookInfo(wBooks, "ワンダフル・C#ライフ");
            Console.WriteLine();
            // 2の解答
            Console.WriteLine("--------------問題2---------------");
            CountBookContainString(wBooks, "C#");
            Console.WriteLine();
            // 3の解答
            Console.WriteLine("--------------問題3---------------");
            ShowAveragePagesContainString(wBooks, "C#");
            Console.WriteLine();
            // 4の解答
            Console.WriteLine("--------------問題4---------------");
            ShowFirstBookTitleAbovePrice(wBooks, 4000);
            Console.WriteLine();
            // 5の解答
            Console.WriteLine("--------------問題5---------------");
            ShowMaxBookPagesBelowPrice(wBooks, 4000);
            Console.WriteLine();
            // 6の解答
            Console.WriteLine("--------------問題6---------------");
            ShowBookInfoByPriceAscending(wBooks, 400);
            Console.WriteLine();
            // 7の解答
            Console.WriteLine("--------------問題7---------------");
            ShowBookContainStringAndBelowPages(wBooks, "C#", 400);

            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        // 1の解答
        /// <summary>
        /// 指定された書籍のタイトルの価格とページ数を表示する
        /// </summary>
        /// <param name="vBooks">書籍のリスト</param>
        /// <param name="vTitle">書籍のタイトル</param>
        static void ShowBookInfo(List<Book> vBooks, string vTitle) {
            var wSearchBook = vBooks.FirstOrDefault(x => x.Title == vTitle);
            if (wSearchBook != null) {
                Console.WriteLine($"{wSearchBook.Title}の価格は{wSearchBook.Price}円, ページ数は{wSearchBook.Pages}ページです");
            } else {
                Console.WriteLine($"タイトル「{vTitle}」の書籍は見つかりませんでした。");
            }
        }
        // 2の解答
        /// <summary>
        /// 指定された文字列を含む書籍の数をカウントする
        /// </summary>
        /// <param name="vBooks">書籍のリスト</param>
        /// <param name="vSearchString">調べたい文字列</param>
        static void CountBookContainString(List<Book> vBooks, string vSearchString) {
            var wBookContainString = vBooks.Where(x => x.Title.Contains(vSearchString));
            var wCountBookContainString = wBookContainString.Count();
            if (wCountBookContainString > 0) {
                Console.WriteLine($"タイトルに「{vSearchString}」を含む書籍は以下の{wCountBookContainString}冊です");
                Console.WriteLine();
                foreach (var wBook in wBookContainString) {
                    Console.WriteLine(wBook.Title);
                }
            } else {
                Console.WriteLine($"タイトルに「{vSearchString}」を含む書籍は見つかりませんでした。");
            }
        }
        // 3の解答
        /// <summary>
        /// 指定された文字列を含む書籍の平均ページ数を表示する※結果は四捨五入
        /// </summary>
        /// <param name="vBooks">書籍のリスト</param>
        /// <param name="vSearchString">調べたい文字列</param>
        static void ShowAveragePagesContainString(List<Book> vBooks, string vSearchString) {
            var wBookContainString = vBooks.Where(x => x.Title.Contains(vSearchString));
            if (wBookContainString.Any()) {
                Console.WriteLine($"タイトルに「{vSearchString}」が含まれている書籍の平均ページ数は{(int)Math.Round(wBookContainString.Average(x => x.Pages))}ページです");
            } else {
                Console.WriteLine($"タイトルに「{vSearchString}」を含む書籍は見つかりませんでした。");
            }
        }
        // 4の解答
        /// <summary>
        /// 指定された値段以上の本で最初に見つかった書籍のタイトルを表示する
        /// </summary>
        /// <param name="vBooks">書籍のリスト</</param>
        /// <param name="vPriceThreshold">価格のしきい値</param>
        static void ShowFirstBookTitleAbovePrice(List<Book> vBooks, int vPriceThreshold) {
            var wFirstBookTitleAbovePrice = vBooks.Where(x => x.Price >= vPriceThreshold).Select(x => x.Title).FirstOrDefault();
            if (wFirstBookTitleAbovePrice != null) {
                Console.WriteLine($"価格が{vPriceThreshold}以上の書籍で最初に見つかった書籍のタイトルは「" +
                    $"{wFirstBookTitleAbovePrice}」です");
            } else {
                Console.WriteLine($"価格が{vPriceThreshold}以上の書籍はありません");
            }
        }
        // 5の解答
        /// <summary>
        /// 指定された値段未満の書籍の中で最大のページ数を表示する
        /// </summary>
        /// <param name="vBooks">書籍のリスト</</param>
        /// <param name="vPriceThreshold">価格のしきい値</param>
        static void ShowMaxBookPagesBelowPrice(List<Book> vBooks, int vPriceThreshold) {
            var wBookPagesBelowPrice = vBooks.Where(x => x.Price < vPriceThreshold);
            if (wBookPagesBelowPrice.Any()) {
                var wMaxBookPagesBelowPrice = wBookPagesBelowPrice.Max(x => x.Pages);
                Console.WriteLine($"価格が{vPriceThreshold}未満の書籍の中で最大のページ数は{wMaxBookPagesBelowPrice}ページです");
            } else {
                Console.WriteLine($"価格が{vPriceThreshold}未満の書籍はありません");
            }
            
        }
        // 6の解答
        /// <summary>
        /// 指定されたページ数以上の書籍のリストを返す
        /// </summary>
        /// <param name="vBooks">書籍のリスト</param>
        /// <param name="vPageThreshold">ページのしきい値</param>
        /// <returns>指定されたページ数以上の書籍のリスト</returns>
        static List<Book> GetBookInfoAbovePages(List<Book> vBooks, int vPageThreshold) {
            return vBooks.Where(x => x.Pages >= vPageThreshold).ToList();
        }
        /// <summary>
        /// 価格の高い順にタイトルと価格を表示する
        /// </summary>
        /// <param name="vBooks">書籍のリスト</param>
        /// <param name="vPageThreshold">ページ数のしきい値</param>
        static void ShowBookInfoByPriceAscending(List<Book> vBooks, int vPageThreshold) {
            var wBookInfoAscending = GetBookInfoAbovePages(vBooks, vPageThreshold).OrderByDescending(x => x.Price);
            if (wBookInfoAscending.Any()) {
                Console.WriteLine($"ページ数が{vPageThreshold}以上の書籍は以下の{wBookInfoAscending.Count()}冊です");
                Console.WriteLine();
                foreach (var wBookInfo in wBookInfoAscending) {
                    Console.WriteLine($"{wBookInfo.Title}、値段：{wBookInfo.Price}円");
                }
            } else {
                Console.WriteLine($"ページ数が{vPageThreshold}以上の書籍は見つかりませんでした。");
            }
        }
        // 7の解答
        /// <summary>
        /// 指定された文字列を含み、指定のページ数以下の書籍のタイトルを表示する
        /// </summary>
        /// <param name="vBooks">書籍のリスト</param>
        /// <param name="vSearchString">調べたい文字列</param>
        /// <param name="vPageThreshold">ページ数のしきい値</param>
        static void ShowBookContainStringAndBelowPages(List<Book> vBooks, string vSearchString, int vPageThreshold) {
            var wBookContainString = vBooks.Where(x => x.Title.Contains(vSearchString));
            if (!wBookContainString.Any()) {
                Console.WriteLine($"タイトルに「{vSearchString}」を含む書籍は見つかりませんでした。");
                return;
            }
            var wBookBelowPages = vBooks.Where(x => x.Pages <= vPageThreshold);
            if (!wBookBelowPages.Any()) {
                Console.WriteLine($"ページ数が{vPageThreshold}以下の書籍は見つかりませんでした。");
                return ;
            }
            var wBookContainStringAndBelowPages = wBookContainString.Where(x => x.Pages <= vPageThreshold);
            Console.WriteLine($"タイトルに「{vSearchString}」を含み、ページ数が{vPageThreshold}以下の書籍は以下の{wBookContainStringAndBelowPages.Count()}冊です");
            Console.WriteLine();
            foreach (var wBook in wBookContainStringAndBelowPages) {
                Console.WriteLine(wBook.Title);
            }
        }
    }
}
