using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
/* 問題10.5
HTMLファイルを読み込み、<DIV>や<P>などのタグ名が大文字になっているものを小文字のタグに変換してください。
可能ならば、<DIV class="myBoxid="myId">のように属性が記述されている場合にも対応してください。
属性の中には'<'や'>'が含まれないものとします。
*/
namespace Practice10_5 {
    internal class Program {
        static void Main(string[] args) {
            string wFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.html");
            if (!File.Exists(wFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            var wLines = File.ReadAllLines(wFilePath);
            var wConvertedLines = wLines.Select(x => ConvertTagToLower(x)).ToArray();
            File.WriteAllLines(wFilePath, wConvertedLines);
            foreach (var wLine in wConvertedLines)
                Console.WriteLine(wLine);
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 受け取った文字列内の大文字タグを小文字タグに変換する
        /// </summary>
        /// <param name="vLine">HTMLファイル内の文字列</param>
        /// <returns>小文字タグに変換された文字列</returns>
        static string ConvertTagToLower(string vLine) {
            return Regex.Replace(vLine, @"<\s*(/?)([A-Z]+)(\s[^<>]*)?>", x => {
                var wPrefix = x.Groups[1].Value;
                var wTagName = x.Groups[2].Value.ToLower();
                var wAttributes = x.Groups[3].Value;
                return $"<{wPrefix}{wTagName}{wAttributes}>";
            });
        }
    }
}
