using System;
using System.IO;
using TextFileProcessor;

/* 問題17.1

「17.2:Template Methodパターン」で示したTextProcessorクラスを利用して、
テキストファイルの中の全角数字をすべて半角数字に置き換えて、
置き換えた結果をコンソールに出力するプログラムを作成してください。

*/

namespace Practice17_1 {
    class Program {
        static void Main(string[] args) {
            if (args.Length != 1) {
                Console.WriteLine("コマンドライン引数を入力してください");
                return;
            }

            if (!File.Exists(args[0])) {
                Console.WriteLine("指定されたファイルが存在しません");
                return;
            }

            TextProcessor.Run<ReplaceHankakuProcessor>(args[0]);

            Console.WriteLine($"{Environment.NewLine}Enterキーを押して終了してください...");
            Console.ReadLine();
        }
    }
}
