using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
/* 問題9.2
テキストファイルを読み込み、行の先頭に行番号を振り、その結果を別のテキストファイルに出力するプログラムを書いてください。
書式と出力先のファイル名は自由に決めてかまいません。
出力するファイル名と同名のファイルがあった場合は、上書きしてください。
*/
namespace Practice9_2 {
    class Program {
        static void Main(string[] args) {
            var wFilePath = @"..\..\Abbreviations.txt";
            if (!File.Exists(wFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            var wReadLines = File.ReadAllLines(wFilePath);
            var wLineNumberWidth = wReadLines.Length.ToString().Length;
            Console.WriteLine("出力先ファイルパスを入力してください:");
            var wInputFilePath = Console.ReadLine();
            var wNewFilePath = GetOutputPath(wFilePath, wInputFilePath);
            if (wReadLines.Any(x => Regex.IsMatch(x, @"^\s*\d+:\s*"))) {
                Console.WriteLine("既存の行番号が検出されました。そのまま出力します。");
                File.WriteAllLines(wNewFilePath, wReadLines);
                Console.WriteLine($"ファイル{wNewFilePath}を出力しました。");
                Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
                Console.ReadKey();
                return;
            }
            File.WriteAllLines(wNewFilePath, wReadLines.Select((x, y) => $"{(y + 1).ToString().PadLeft(wLineNumberWidth)}: {x}"));
            Console.WriteLine($"行番号を付与したファイル{wNewFilePath}を出力しました。");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 出力先ファイルのパスを取得する。
        /// ユーザー入力が有効な場合はそのパスを使用し、
        /// 無効な場合はデフォルトのパス（入力ファイルと同じディレクトリ）を返す。
        /// </summary>
        /// <param name="vSourceFilePath">元の入力ファイルのパス</param>
        /// <param name="vUserInputFilePath">ユーザーが指定した出力先ファイルパス</param>
        static string GetOutputPath(string vSourceFilePath, string vUserInputFilePath) {
            if (string.IsNullOrWhiteSpace(vUserInputFilePath)) {
                Console.WriteLine("出力先が指定されませんでした。読み込みファイルと同階層に出力します。");
                return GetDefaultOutputPath(vSourceFilePath);
            }
            if (vUserInputFilePath.Trim().Trim('"').IndexOfAny(Path.GetInvalidPathChars()) >= 0) {
                Console.WriteLine("指定されたパスが不正です。読み込みファイルと同階層に出力します。");
                return GetDefaultOutputPath(vSourceFilePath);
            }
            if (!Path.IsPathRooted(vUserInputFilePath)) {
                var sourceDirectory = Path.GetDirectoryName(Path.GetFullPath(vSourceFilePath));
                return Path.GetFullPath(Path.Combine(sourceDirectory, vUserInputFilePath));
            }
            var wOutputFilePath = Path.GetFullPath(vUserInputFilePath);
            var wOutputDirectory = Path.GetDirectoryName(wOutputFilePath);
            if (!Directory.Exists(wOutputDirectory))
                Directory.CreateDirectory(wOutputDirectory);
            Console.WriteLine("処理成功！！");
            return wOutputFilePath;
        }
        /// <summary>
        /// 入力ファイルと同じディレクトリに、デフォルトの出力ファイル名で出力パスを生成する。
        /// </summary>
        /// <param name="vInputFilePath">元の入力ファイルのパス</param>
        /// <returns>デフォルトの出力先ファイルパス</returns>
        static string GetDefaultOutputPath(string vInputFilePath) {
            var wDirectory = Path.GetDirectoryName(vInputFilePath);
            var wNewFileName = $"{Path.GetFileNameWithoutExtension(vInputFilePath)}_Numbered{Path.GetExtension(vInputFilePath)}";
            return Path.Combine(wDirectory, wNewFileName);
        }
    }
}