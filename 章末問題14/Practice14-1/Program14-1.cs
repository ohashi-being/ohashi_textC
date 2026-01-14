using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

/* 問題14.1
ファイルにプログラムのパスとパラメータが複数行書かれています。
このファイルを読み込み、プログラムを順に起動するプログラムを書いて下さい。
1つのプログラムが終わるのを待って次のプログラムを起動するようにして下さい。
通常のテキストファイルでもXMLファイルでも好みの形式で構いません。

2つのテキストファイルが順に開くプログラム
*/

namespace Practice14_1 {
    class Program {
        static void Main(string[] args) {
            var wFilePath = @"..\..\commands.txt";
            if (!File.Exists(wFilePath)) {
                Console.WriteLine($"ファイルが見つかりません: {wFilePath}");
                return;
            }
            var wLines = File.ReadAllLines(wFilePath);
            if (!wLines.Any()) {
                Console.WriteLine("コマンドファイルにデータがありません。");
                return;
            }
            if (!wLines.Any(x => !string.IsNullOrWhiteSpace(x.Split('|')[0].Trim()))) {
                Console.WriteLine("有効なコマンドが見つかりませんでした。");
                return;
            }
            ExecuteCommands(wLines);
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// コマンドライン文字列からProcessStartInfoオブジェクトを作成する
        /// </summary>
        /// <param name="vLine">プログラムパス|引数の形式の文字列</param>
        /// <returns>プロセス起動用の設定オブジェクト</returns>
        static ProcessStartInfo CreateStartInfo(string vLine) {
            var wCommandParts = vLine.Split(new[] { '|' }, 2);
            return new ProcessStartInfo {
                FileName = wCommandParts[0].Trim(),
                Arguments = wCommandParts.Length == 2 ? wCommandParts[1].Trim() : null
            };
        }
        /// <summary>
        /// コマンドリストを順次実行する
        /// </summary>
        /// <param name="vLines">実行するコマンドライン配列</param>
        static void ExecuteCommands(string[] vLines) {
            foreach (var wLine in vLines) {
                if (string.IsNullOrWhiteSpace(wLine)) continue;
                var wInfo = CreateStartInfo(wLine);
                if (string.IsNullOrWhiteSpace(wInfo.FileName)) continue;
                Console.WriteLine($"実行中: {wInfo.FileName} {wInfo.Arguments}");
                try {
                    using (var wProcess = Process.Start(wInfo)) wProcess.WaitForExit();
                } catch (Exception ex) {
                    Console.WriteLine(
                        $"プロセスの起動に失敗しました: {wInfo.FileName}{Environment.NewLine}" +
                        $"例外: {ex.GetType().Name}{Environment.NewLine}" +
                        $"理由: {ex.Message}");
                }
            }
        }
    }
}
