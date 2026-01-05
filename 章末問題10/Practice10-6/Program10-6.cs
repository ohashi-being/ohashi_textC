using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/* 問題10.6
5文字の回文とマッチする正規表現を作成してください。
数字や記号だけからなる回文を除外するにはどうしたら良いかも考えてください。
*/
namespace Practice10_6 {
    internal class Program {
        static void Main(string[] args) {
            var wStrings = new List<string> {
                "level",
                "racecar",
                "12321",
                "ab@ba",
                "ohashi",
                " ",
                "",
                "しかるかし",
                "たけやぶやけた",
                "シカルカシ",
                "タケヤブヤケタ",
                "大橋陸",
                "大橋陸橋大",
            };
            var wPattern = @"^(?=.*[\p{IsHiragana}\p{IsKatakana}\p{IsCJKUnifiedIdeographs}A-Za-z])(.)(.)(.)\2\1$";
            foreach (var wString in wStrings) {
                var wMatches = Regex.Matches(wString, wPattern);
                if (wMatches.Count > 0) Console.WriteLine($"{wString}は5文字の回文です。");
                else Console.WriteLine($"{wString}は5文字の回文ではありません。");
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
