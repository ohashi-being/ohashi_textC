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
            var wPattern = @"\btime\b";
            foreach (var wText in wTexts) {
                ShowMatchIndexes(wText, @"time");

            }
            Console.WriteLine();
            foreach (var wText in wTexts) {
                ShowMatchIndexesByPattern(wText, wPattern);

            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        ///  テキストから指定された文字列が含まれる位置をすべて表示する
        /// </summary>
        /// <param name="vText">検索するテキスト</param>
        /// <param name="vContainsString">含んでいる文字</param>
        static void ShowMatchIndexes(string vText, string vContainsString) {
            var wMatches = Regex.Matches(vText, Regex.Escape(vContainsString), RegexOptions.IgnoreCase);
            if (wMatches.Count == 0) {
                Console.WriteLine($"{vText}には{vContainsString}は含まれていません。");
                return;
            }
            Console.WriteLine($"{vText}には{vContainsString}が含まれています。");
            foreach (Match wMatch in wMatches) {
                Console.WriteLine($"開始位置: {wMatch.Index}");
            }
        }
        /// <summary>
        /// テキストから指定された文字列が一致する位置をすべて表示する
        /// </summary>
        /// <param name="vText">検索するテキスト</param>
        /// <param name="vPattern">指定する文字列</param>
        static void ShowMatchIndexesByPattern(string vText, string vPattern) {
            var wMatches = Regex.Matches(vText, vPattern, RegexOptions.IgnoreCase);
            if (wMatches.Count == 0) {
                Console.WriteLine($"{vText}には{vPattern.Replace(@"\b", "")}は含まれていません。");
                return;
            }
            Console.WriteLine($"{vText}には{vPattern.Replace(@"\b", "")}が含まれています。");
            foreach (Match wMatch in wMatches) {
                Console.WriteLine($"開始位置: {wMatch.Index}");
            }
        }
    }
}