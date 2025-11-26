using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
/* 問題10.2
テキストファイルを読み込み、3文字以上の数字だけからなる部分文字列をすべて抜き出すコードを書いてください。
*/
namespace Practice10_2 {
    internal class Program {
        static void Main(string[] args) {
            string wFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.txt");
            if (!File.Exists(wFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            foreach (var wLine in File.ReadAllLines(wFilePath)) {
                var wMatches = Regex.Matches(wLine, @"\b\d{3,}\b");
                foreach (Match wMatch in wMatches) Console.WriteLine(wMatch.Value);
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
