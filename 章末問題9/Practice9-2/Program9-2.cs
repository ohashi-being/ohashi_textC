using System;
using System.IO;
using System.Linq;
using System.Reflection;
/* 問題9.2
テキストファイルを読み込み、行の先頭に行番号を振り、その結果を別のテキストファイルに出力するプログラムを書いてください。
書式と出力先のファイル名は自由に決めてかまいません。
出力するファイル名と同名のファイルがあった場合は、上書きしてください。
*/
namespace Practice9_2 {
    class Program {
        static void Main(string[] args) {
            string wFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Abbreviations.txt");
            if (!File.Exists(wFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            var wReadLines = File.ReadAllLines(wFilePath);
            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Abbreviations_Numbered.txt"),
                wReadLines.Select((x, y) => $"{y + 1,2}: {x}"));
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}