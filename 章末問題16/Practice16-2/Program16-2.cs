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
    internal class Program {
        static void Main(string[] args) {
            string wDirectoryPath = @"..\..\16-2";

            if (!Directory.Exists(wDirectoryPath)) {
                Console.WriteLine("指定されたディレクトリが存在しません。");
                return;
            }

            string[] wKeyword = { "async", "await" };

            Console.WriteLine($"検索キーワード: '{wKeyword[0]}' と '{wKeyword[1]}'{Environment.NewLine}");

            Console.WriteLine("--- 逐次処理 ---");
            var wSequentialResult = SearchSequential(wDirectoryPath, wKeyword, out long wSequentialTime);
            DisplayResults(wSequentialResult, wSequentialTime);

            Console.WriteLine("--- 並列処理 ---");
            var wParallelResult = SearchWithPLINQ(wDirectoryPath, wKeyword, out long wParallelTime);
            DisplayResults(wParallelResult, wParallelTime);

            Console.WriteLine(
                $"--- 処理完了 ---{Environment.NewLine}" +
                $"逐次処理: {wSequentialTime}ms{Environment.NewLine}" +
                $"並列処理: {wParallelTime}ms{Environment.NewLine}" +
                $"高速化率: {(double)wParallelTime / wSequentialTime:F2}倍");
        }

        static List<string> SearchSequential(string vDirectoryPath, string[] vKeyword, out long vElapsedMilliseconds) {
            var wSw = Stopwatch.StartNew();
            var wResult = new List<string>();

            try {
                var wFiles = Directory.GetFiles(vDirectoryPath, "*.cs", SearchOption.AllDirectories);

                foreach (var wFile in wFiles) {
                    if (ContainsBothKeywords(wFile, vKeyword)) {
                        wResult.Add(wFile);
                    }
                }
            } catch (Exception wEx) {
                Console.WriteLine($"エラー: {wEx.Message}");
            }

            wSw.Stop();
            vElapsedMilliseconds = wSw.ElapsedMilliseconds;
            return wResult;
        }

        static List<string> SearchWithPLINQ(string vDirectoryPath, string[] vKeyword, out long vElapsedMilliseconds) {
            var wStopWatch = Stopwatch.StartNew();
            var wResult = new List<string>();

            try {
                var wFiles = Directory.GetFiles(vDirectoryPath, "*.cs", SearchOption.AllDirectories);

                wResult = wFiles
                    .AsParallel()
                    .Where(wFile => ContainsBothKeywords(wFile, vKeyword))
                    .ToList();
            } catch (Exception ex) {
                Console.WriteLine($"エラー: {ex.Message}");
            }

            wStopWatch.Stop();
            vElapsedMilliseconds = wStopWatch.ElapsedMilliseconds;
            return wResult;
        }

        static void DisplayResults(List<string> vFiles, long vElapsedMilliseconds) {
            foreach (var wFile in vFiles) {
                Console.WriteLine(wFile);
            }

            Console.WriteLine();
            Console.WriteLine($"検出ファイル数: {vFiles.Count}");
            Console.WriteLine($"実行時間: {vElapsedMilliseconds}ms ({vElapsedMilliseconds / 1000.0:F3}秒)");
        }

        static bool ContainsBothKeywords(string vFilePath, string[] vKeyword) {
            try {
                string wContent = File.ReadAllText(vFilePath, Encoding.UTF8);
                return wContent.Contains(vKeyword[0]) && wContent.Contains(vKeyword[1]);
            } catch {
                return false;
            }
        }
    }
}
