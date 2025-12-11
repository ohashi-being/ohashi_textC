using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
/* 問題10.2
テキストファイルを読み込み、3文字以上の数字だけからなる部分文字列をすべて抜き出すコードを書いてください。
*/
namespace Practice10_2 {
    internal class Program {
        static void Main(string[] args) {
            var wFilePath = @"..\..\sample.txt";
            if (!File.Exists(wFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            var wPattern = @"\b\d{3,}\b";
            File.ReadAllLines(wFilePath)
                .SelectMany(x => Regex.Matches(x, wPattern).Cast<Match>())
                .ToList()
                .ForEach(x => Console.WriteLine(x.Value));
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
