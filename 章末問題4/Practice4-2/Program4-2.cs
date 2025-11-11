using System;
using System.Collections.Generic;
using System.Linq;
using Practice4_1;

/* 問題4.2
* 
* 問題4.1で定義したYearMonthクラスを使って、次のコードを書いてください。
* 
* 1.YearMonthを要素に持つ配列を定義し、初期値として5つのYearMonthオブジェクトをセットしてください。
* 
* 2.この配列の要素(YearMonthオブジェクト)をすべて列挙し、その値をコンソールに出力してください。
* 
* 3.配列の中の最初に見つかった21世紀のYearMonthオブジェクトを返すメソッドを書いてください。
*   見つからなかった場合は、nullを返してください。
*   foreach文を使って実装してください。
* 
* 4.3で作成したメソッドを呼び出し、最初に見つかった21世紀のデータの年を表示してください。
*   見つからなければ、"21世紀のデータはありません"を表示してください。
*   
* 5.配列に格納されているすべてのYearMonthの1ヵ月後を求め、その結果を新たな配列にいれてください。
*   その後、その配列の要素の内容(年月)を順に表示してください。
*   LINQを使えるところはLINQを使って実装してみてください。*/

namespace Practice4_2 {
    public class Program {
        static void Main(string[] args) {
            // 1の解答
            var wYearMonthArray = new YearMonth[] {
                new YearMonth(1000,4),
                new YearMonth(9999,8),
                new YearMonth(1030,7),
                new YearMonth(2101,1),
                new YearMonth(2000,12),
            };
            // 2の解答
            ShowCollection(wYearMonthArray);
            Console.WriteLine("--------------------------");
            // 4の解答
            ShowFirst21Century(wYearMonthArray);
            Console.WriteLine("--------------------------");
            // 5の解答
            ShowCollection(wYearMonthArray.Select(x => x.GetAfterOneMonth()));
            Console.WriteLine("--------------------------");
            ShowFirst21Century(wYearMonthArray.Select(x => x.GetAfterOneMonth()));
            // 追加問題
            ShowFirstLeapYear(wYearMonthArray);
            Console.WriteLine("\n終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        // 2の解答
        /// <summary>
        /// コレクションの要素をコンソールに出力する
        /// </summary>
        /// <typeparam name="T">任意の型</typeparam>
        /// <param name="vCollection">コレクション</param>
        static void ShowCollection<T>(IEnumerable<T> vCollection) {
            foreach (var wCollection in vCollection) {
                Console.WriteLine(wCollection);
            }
        }
        // 3の解答
        /// <summary>
        ///  最初に見つかった21世紀のYearMonthオブジェクトを返す
        /// </summary>
        /// <param name="vYearMonths">YearMonthオブジェクト</param>
        /// <returns>最初に見つかった21世紀のYearMonthオブジェクト ※見つからなかった場合は、nullを返す</returns>
        static YearMonth SearchFirst21Century(IEnumerable<YearMonth> vYearMonths) => vYearMonths.FirstOrDefault(x => x.Is21Century);
        // 4の解答
        /// <summary>
        /// 最初に見つかった21世紀のデータの年を表示する
        /// </summary>
        /// <param name="vYearMonths">YearMonthオブジェクト</param>
        static void ShowFirst21Century(IEnumerable<YearMonth> vYearMonths) {
            var wFirst21Century = SearchFirst21Century(vYearMonths);
            Console.WriteLine(wFirst21Century?.Year.ToString() ?? "21世紀のデータはありません。");
        }
        /// <summary>
        /// 最初に見つかったうるう年のデータの年を表示する
        /// </summary>
        /// <param name="vYearMonths">YearMonthオブジェクト</param>
        static void ShowFirstLeapYear(IEnumerable<YearMonth> vYearMonths) {
            var wFirstLeapYear = vYearMonths.FirstOrDefault(x => x.IsLeapYear);
            Console.WriteLine(wFirstLeapYear != null? $"{wFirstLeapYear.Year}年はうるう年です。":"うるう年のデータはありません");
        }
    }
}
