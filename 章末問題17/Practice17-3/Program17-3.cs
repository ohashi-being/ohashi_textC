using System;
using System.IO;

/* 問題17.3

17.1で作成したプログラムをインターフェースを実装する形に書き直してください。

*/

namespace Practice17_3 {
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
            var wService = new ToHankakuService();
            var wProcessor = new TextFileProcessor(wService);
            wProcessor.Run(args[0]);

            Console.WriteLine($"{Environment.NewLine}Enterキーを押して終了してください...");
            Console.ReadLine();
        }
    }
}
