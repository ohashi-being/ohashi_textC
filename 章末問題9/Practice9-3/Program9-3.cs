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
                Console.WriteLine("入力方法　: Practice9-3.exe <追記先ファイル> <追記元ファイル>");
                return;
            }
            var wBaseFilePath = args[0];
            var wAppendFilePath = args[1];
            if (string.IsNullOrWhiteSpace(args[0]) || string.IsNullOrWhiteSpace(args[1])) {
                Console.WriteLine("エラー: ファイルパスが空です。");
                return;
            }
            File.AppendAllLines(wBaseFilePath, File.ReadLines(wAppendFilePath));
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
