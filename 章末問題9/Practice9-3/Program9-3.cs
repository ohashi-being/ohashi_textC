using System;
using System.IO;
/* 問題9.3
あるテキストファイルの最後に別のテキストファイルの内容を追加するコンソールアプリケーションを書いてください。
コマンドラインで2つのテキストファイルのパス名を指定できるようにしてください。
*/
namespace Practice9_3 {
    class Program {
        static void Main(string[] args) {
            if (args.Length <= 1) {
                Console.WriteLine("エラー：引数が不足しています。");
                Console.WriteLine("入力方法 : Practice9-3.exe <元となるファイル> <追加先のファイル>");
                return;
            }
            if (string.IsNullOrWhiteSpace(args[0]) || string.IsNullOrWhiteSpace(args[1])) {
                Console.WriteLine("エラー: ファイルパスが空です。");
                return;
            }
            var wSourceFilePath = args[0];
            var wDestinationFilePath = args[1];
            if (!File.Exists(wSourceFilePath)) {
                Console.WriteLine($"エラー: 追記元ファイルが存在しません: {wSourceFilePath}");
                return;
            }
            if (!File.Exists(wDestinationFilePath)) {
                Console.WriteLine($"エラー: 追記先ファイルが存在しません: {wDestinationFilePath}");
                return;
            }
            File.AppendAllLines(wDestinationFilePath, File.ReadLines(wSourceFilePath));
            Console.WriteLine("追加完了！！");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
