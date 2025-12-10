using System;
using System.IO;
using System.Linq;
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

            string wNewFilePath = GetOutputPath(wFilePath, wInputFilePath);

            File.WriteAllLines(wNewFilePath, wReadLines.Select((x, y) => $"{(y + 1).ToString().PadLeft(wLineNumberWidth)}: {x}"));
            Console.WriteLine("処理成功！！");
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
            if (!IsValidPath(vUserInputFilePath)) {
                Console.WriteLine("指定されたパスが不正です。読み込みファイルと同階層に出力します。");
                return GetDefaultOutputPath(vSourceFilePath);
            }
            string wOutputFilePath = Path.GetFullPath(vUserInputFilePath);
            string wOutputDirectory = Path.GetDirectoryName(wOutputFilePath);
            if (!Directory.Exists(wOutputDirectory))
                Directory.CreateDirectory(wOutputDirectory);
            return wOutputFilePath;
        }
        /// <summary>
        /// 入力ファイルと同じディレクトリに、デフォルトの出力ファイル名で出力パスを生成する。
        /// </summary>
        /// <param name="vInputFilePath">元の入力ファイルのパス</param>
        /// <returns>デフォルトの出力先ファイルパス</returns>
        static string GetDefaultOutputPath(string vInputFilePath) {
            string wDirectory = Path.GetDirectoryName(vInputFilePath);
            string wFileName = Path.GetFileName(vInputFilePath);
            return Path.Combine(wDirectory, wFileName);
        }
        /// <summary>
        /// 指定されたファイルパスが有効かどうか検証する。
        /// </summary>
        /// <param name="vFilePath">検証対象のファイルパス</param>
        /// <returns>パスが有効な場合はtrue、無効な場合はfalse</returns>
        static bool IsValidPath(string vFilePath) {
            if (string.IsNullOrWhiteSpace(vFilePath)) return false;
            var wInvalidPathChars = Path.GetInvalidPathChars();
            if (vFilePath.IndexOfAny(wInvalidPathChars) >= 0) return false;
            return true;
        }
    }
}