using System;
using System.Text.RegularExpressions;
/* 問題10.3
以下の文字列配列から、単語"time"が含まれる文字列を取り出し、timeの開始位置をすべて出力してください。
大文字・小文字は区別しないものとします。
var wTexts = {
    "This is money.",
    "Time is money.",
    "What time is it?",
    "It will take time.",
    "We reorganized the timetable."
};
*/
namespace Practice10_3 {
    internal class Program {
        static void Main(string[] args) {
            string[] wTexts = {
                "This is money.",
                "Time is money.",
                "What time time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            };
            foreach (var wText in wTexts) {
                ShowMatchIndexes(wText, "time", false);
            }
            Console.WriteLine();
            foreach (var wText in wTexts) {
                ShowMatchIndexes(wText, "time", true);
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// テキストから指定された文字列が含まれる位置をすべて表示する
        /// </summary>
        /// <param name="vText">検索するテキスト</param>
        /// <param name="vSearchString">検索文字列または正規表現パターン</param>
        /// <param name="vIsRegex">正規表現として扱うかどうか</param>
        static void ShowMatchIndexes(string vText, string vSearchString, bool vIsRegex) {
            string wRegexPattern = Regex.Escape(vSearchString);
            if (vIsRegex) wRegexPattern = $@"\b{wRegexPattern}\b";
            var wMatches = Regex.Matches(vText, wRegexPattern, RegexOptions.IgnoreCase);
            if (wMatches.Count == 0) {
                Console.WriteLine($"{vText}には{vSearchString}は含まれていません。");
                return;
            }
            Console.WriteLine($"{vText}には{vSearchString}が含まれています。");
            foreach (Match wMatch in wMatches) {
                Console.WriteLine($"開始位置: {wMatch.Index}");
            }
        }
    }
}