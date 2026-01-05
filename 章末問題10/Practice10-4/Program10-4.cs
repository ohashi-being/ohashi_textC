using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
/* 問題10.4
テキストファイルを読み込み、version="v4.0"と書かれた箇所を、version="v5.0"に置き換え、同じファイルに保存してください。
なお、入力ファイルの=の前後には任意の数の空白文字が入っていることもあります。
出力時には、=の前後の空白は削除してください。
"version"は、"Version"である場合もあります。
*/
namespace Practice10_4 {
    internal class Program {
        static void Main(string[] args) {
            var wFilePath = @"..\..\sample.txt";
            if (!File.Exists(wFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            var wLines = File.ReadAllLines(wFilePath);
            var wPattern = @"\bversion\s*=\s*""v4\.0""";
            var wReplacedPattern = @"version=""v5.0""";
            File.WriteAllLines(wFilePath, wLines.Select(x => ReplaceVersionString(x,wPattern,wReplacedPattern)));
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 文字列内のversion="v4.0"をversion="v5.0"に置き換える
        /// </summary>
        /// <param name="vLine">処理対象の文字列</param>
        /// <param name="vPattern">検索パターン</param>
        /// <param name="vReplacedPattern">返還後のパターン</param>
        /// <returns>置換後の文字列</returns>
        static string ReplaceVersionString(string vLine, string vPattern, string vReplacedPattern) {
            var wReplaced = Regex.Replace(vLine, vPattern, vReplacedPattern, RegexOptions.IgnoreCase);
            if (vLine != wReplaced) {
                Console.WriteLine($"変換:{vLine} → {wReplaced}");
            } else {
                Console.WriteLine($"対象外: {vLine}");
            }
            return wReplaced;
        }
    }
}
