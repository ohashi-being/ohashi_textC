using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/* 問題10.5
HTMLファイルを読み込み、<DIV>や<P>などのタグ名が大文字になっているものを小文字のタグに変換してください。
火の運荒場、<DIV class="myBoxid="myId">のように属性が記述されている場合にも対応してください。
属性の中には'<'や'>'が含まれないものとします。
*/
namespace Practice10_5 {
    internal class Program {
        static void Main(string[] args) {
            string wFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.html");
            if (!File.Exists(wFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            var wLines = File.ReadAllLines(wFilePath);
            File.WriteAllLines(wFilePath, wLines.Select(x => ConvertTagToLower(x)).ToArray());
            foreach (var wLine in wLines)
                Console.WriteLine(File.ReadAllLines(wFilePath));
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        static string ConvertTagToLower(string vLine) {
            var wMatches = Regex.Matches(vLine, @"<\s*(/?)([A-Z]+)(\s[^<>]*)?>");
            if (wMatches.Count == 1) {
            } else if (wMatches.Count == 0) {
            } else {
            //}return $"<{x.Groups[1].Value}{x.Groups[2].Value.ToLower()}{x.Groups[3].Value}>";
        }
    }
}
