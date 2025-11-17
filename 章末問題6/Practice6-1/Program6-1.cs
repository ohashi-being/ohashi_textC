using System;
using System.Collections.Generic;
using System.Linq;
/* 問題6.1
次のような配列が定義されています。
var wNumbers = new int[] { 5 , 10 , 17 , 9 , 3 , 21 , 10 , 40 , 21 , 3 ,35 };
この配列に対して、以下のコードを書いてください。

1.最大値を求め、結果を表示してください。

2.最後から2つの要素を取り出して表示してください。

3.それぞれの数値を文字列に変換し、結果を表示してください。

4.数の小さい順に並べ、先頭から3つを取り出し、結果を表示してください。

5.重複を排除した後、10より大きい値がいくつあるのかカウントし、結果を表示してください。
*/
namespace Practice6_1 {
    internal class Program {
        static void Main(string[] args) {
            var wNumbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };
            Console.WriteLine("--------------問題1---------------");
            Console.WriteLine($"{GetMaxNumbers(wNumbers)}");
            Console.WriteLine("--------------問題2---------------");
            Console.WriteLine($"{string.Join(",", wNumbers.Skip(wNumbers.Length - 2))}");
            Console.WriteLine("--------------問題3---------------");
            Console.WriteLine($"{string.Join(",", wNumbers.Select(x => x.ToString()))}");
            Console.WriteLine("--------------問題4---------------");
            Console.WriteLine($"{string.Join(",", wNumbers.OrderBy(x => x).Take(3))}");
            Console.WriteLine("--------------問題5---------------");
            Console.WriteLine($"{string.Join(",", wNumbers.Distinct().Where(x => x > 10))}の{wNumbers.Distinct().Count(x => x > 10)}つです");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 指定された値から最大値を取得する
        /// </summary>
        /// <param name="vNumbers">数字の配列</param>
        /// <returns>配列に要素がある場合は「最大値は○○です」という文字列、
        /// 配列が空の場合は「要素が見つかりません」という文字列</returns>
        static string GetMaxNumbers(int[] vNumbers) {
            if (vNumbers == null || !vNumbers.Any()) {
                return $"要素が見つかりません";
            }
            return $"最大値は{vNumbers.Max()}です";
        }
    }
}
