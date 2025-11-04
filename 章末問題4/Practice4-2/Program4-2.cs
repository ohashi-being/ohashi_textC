using System;
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
                new YearMonth(1019,4),
                new YearMonth(1011,8),
                new YearMonth(1030,7),
                new YearMonth(2101,1),
                new YearMonth(2000,12),
            };
            // 2の解答
            ShowArray(wYearMonthArray);
            Console.WriteLine("--------------------------");
            // 4の解答
            Show21Century(wYearMonthArray);
            Console.WriteLine("--------------------------");
            // 5の解答
            ShowArray(wYearMonthArray.Select(x => x.GetAfterOneMonth()).ToArray());
            Console.WriteLine("--------------------------");
            Show21Century(wYearMonthArray.Select(x => x.GetAfterOneMonth()).ToArray());
        }
        // 2の解答
        /// <summary>
        /// 配列の要素をコンソールに出力する
        /// </summary>
        /// <param name="vYearMonths">YearMonthオブジェクトを持つ配列</param>
        static void ShowArray(YearMonth[] vYearMonths) {
            foreach (var wYearMonth in vYearMonths) {
                Console.WriteLine(wYearMonth);
            }
        }
        // 3の解答
        /// <summary>
        ///  配列の中の最初に見つかった21世紀のYearMonthオブジェクトを返す
        /// </summary>
        /// <param name="vYearMonths">YearMonthオブジェクトを持つ配列</param>
        /// <returns>最初に見つかった21世紀のYearMonthオブジェクト ※見つからなかった場合は、nullを返す</returns>
        static YearMonth Search21Century(YearMonth[] vYearMonths) {
            foreach (var wYearMonth in vYearMonths) {
                if (wYearMonth.Check21Century) {
                    return wYearMonth;
                }
            }
            return null;
        }
        // 4の解答
        /// <summary>
        /// 最初に見つかった21世紀のデータの年を表示する
        /// </summary>
        /// <param name="vYearMonths">YearMonthオブジェクトを持つ配列</param>
        static void Show21Century(YearMonth[] vYearMonths) {
            var wFirst21Century = Search21Century(vYearMonths);
            if (wFirst21Century != null) {
                Console.WriteLine(wFirst21Century.Year);
            } else { Console.WriteLine("21世紀のデータはありません"); }
        }
    }
}
