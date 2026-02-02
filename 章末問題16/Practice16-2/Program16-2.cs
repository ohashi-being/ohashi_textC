using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

/* 問題16.2
 
指定したディレクトリにあるC#のソースファイル（サブディレクトリを含む）の中をすべて検索し、
キーワードasyncとawaitの両方を利用しているファイルを列挙してください。
列挙する際は、ファイルのフルパスを表示してください。表示する順番は問いません。
並列処理をした場合としない場合の2つのバージョンを作成し、どれくらい速度に差があるかも確認してください。

*/

namespace Practice16_2 {
    class Program {
        static void Main(string[] args) {

            if (args.Length == 0) {
                Console.WriteLine("エラー: 検索対象のディレクトリパスを引数で指定してください。");
                return;
            }

            string wDirectoryPath = args[0];

            if (!Directory.Exists(wDirectoryPath)) {
                Console.WriteLine($"指定されたディレクトリが存在しません。{wDirectoryPath}");
                return;
            }

            string[] wKeywords = { "async", "await", "Task" };

            Console.WriteLine($"検索キーワード: '{string.Join("' と '", wKeywords)}'{Environment.NewLine}");

            Console.WriteLine("--- 逐次処理 ---");
            var wSequentialResult = SearchFileSequential(wDirectoryPath, wKeywords, out long wSequentialTime);
            DisplayResults(wSequentialResult, wSequentialTime);

            Console.WriteLine("--- 並列処理 ---");
            var wParallelResult = SearchFileParallel(wDirectoryPath, wKeywords, out long wParallelTime);
            DisplayResults(wParallelResult, wParallelTime);

            if (wParallelTime == 0) {
                Console.WriteLine("並列処理の実行時間が0msのため、スピードアップ率を計算できません。");
                return;
            }

            Console.WriteLine(
                $"--- 処理完了 ---{Environment.NewLine}{Environment.NewLine}" +
                $"逐次処理: {wSequentialTime}ms{Environment.NewLine}" +
                $"並列処理: {wParallelTime}ms{Environment.NewLine}" +
                $"スピードアップ率: {(double)wSequentialTime / wParallelTime:F2}倍");
        }

        /// <summary>
        /// 指定したディレクトリ内のC#ソースファイルを取得する
        /// </summary>
        /// <param name="vDirectoryPath">検索対象のディレクトリパス</param>
        /// <returns>C#ソースファイルのパス配列</returns>
        static string[] GetCSharpFiles(string vDirectoryPath) {
            return Directory.GetFiles(vDirectoryPath, "*.cs", SearchOption.AllDirectories);
        }

        /// <summary>
        /// 指定したディレクトリ内のC#のソースファイルからキーワードを利用しているファイルを取得する（逐次処理）
        /// </summary>
        /// <param name="vDirectoryPath">検索対象のディレクトリパス</param>
        /// <param name="vKeywords">検索するキーワードの配列</param>
        /// <param name="vElapsedMilliSeconds">処理にかかった時間</param>
        /// <returns>キーワードが含まれているファイルのパスのリスト</returns>
        static List<string> SearchFileSequential(string vDirectoryPath, string[] vKeywords, out long vElapsedMilliSeconds) {
            var wStopWatch = Stopwatch.StartNew();
            var wResult = new List<string>();

            try {
                var wFiles = GetCSharpFiles(vDirectoryPath);

                foreach (var wFile in wFiles) {
                    if (ContainsAllKeywords(wFile, vKeywords)) wResult.Add(Path.GetFullPath(wFile));
                }
            } catch (Exception ex) {
                Console.WriteLine(
                    $"{Environment.NewLine}エラーが発生しました。{Environment.NewLine}" +
                    $"例外: {ex.GetType().Name}{Environment.NewLine}" +
                    $"内容: {ex.Message}");
            }

            wStopWatch.Stop();
            vElapsedMilliSeconds = wStopWatch.ElapsedMilliseconds;
            return wResult;
        }

        /// <summary>
        /// 指定したディレクトリ内のC#のソースファイルからキーワードを利用しているファイルを取得する（並列処理）
        /// </summary>
        /// <param name="vDirectoryPath">検索対象のディレクトリパス</param>
        /// <param name="vKeywords">検索するキーワードの配列</param>
        /// <param name="vElapsedMilliSeconds">処理にかかった時間</param>
        /// <returns>キーワードが含まれているファイルのパスのリスト</returns>
        static List<string> SearchFileParallel(string vDirectoryPath, string[] vKeywords, out long vElapsedMilliSeconds) {
            var wStopWatch = Stopwatch.StartNew();
            var wResult = new List<string>();

            try {
                var wFiles = GetCSharpFiles(vDirectoryPath);

                wResult = wFiles
                    .AsParallel()
                    .Where(x => ContainsAllKeywords(x, vKeywords))
                    .Select(x => Path.GetFullPath(x))
                    .ToList();

            } catch (Exception ex) {
                Console.WriteLine(
                    $"{Environment.NewLine}エラーが発生しました。{Environment.NewLine}" +
                    $"例外: {ex.GetType().Name}{Environment.NewLine}" +
                    $"内容: {ex.Message}");
            }

            wStopWatch.Stop();
            vElapsedMilliSeconds = wStopWatch.ElapsedMilliseconds;
            return wResult;
        }

        /// <summary>
        /// 検索結果をコンソールに表示する
        /// </summary>
        /// <param name="vFiles">検出されたファイルパスのリスト</param>
        /// <param name="vElapsedMilliSeconds">処理にかかった時間</param>
        static void DisplayResults(List<string> vFiles, long vElapsedMilliSeconds) {
            if (vFiles.Count == 0) {
                Console.WriteLine($"{Environment.NewLine}該当するファイルはありません。{Environment.NewLine}");
                return;
            }
            Console.WriteLine($"{Environment.NewLine}ファイルパス:");
            foreach (var wFile in vFiles) {
                Console.WriteLine(wFile);
            }

            Console.WriteLine($"{Environment.NewLine}検出ファイル数: {vFiles.Count}");
            Console.WriteLine($"実行時間: {vElapsedMilliSeconds}ms ({vElapsedMilliSeconds / 1000.0:F3}秒){Environment.NewLine}");
        }

        /// <summary>
        /// ファイル内にすべてのキーワードが含まれているかどうかを確認する
        /// </summary>
        /// <param name="vFilePath">検索対象のファイルパス</param>
        /// <param name="vKeywords">検索するキーワードの配列</param>
        /// <returns>すべてのキーワードが含まれているかどうか</returns>
        static bool ContainsAllKeywords(string vFilePath, string[] vKeywords) {
            try {
                string wContent = File.ReadAllText(vFilePath, Encoding.UTF8);
                return vKeywords.All(x => wContent.Contains(x));
            } catch (Exception ex) {
                Console.WriteLine($"警告: ファイル読み込みエラー ({Path.GetFileName(vFilePath)}): {ex.Message}");
                return false;
            }
        }
    }
}
