using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/* 問題16.1
 
.NET Farmework 4.5以降のStreamReaderクラスには、非同期処理を実現するReadLineAsyncメソッドが追加されています。
このメソッドを使い、テキストファイルを非同期で読み込むコードを書いてください。
アプリケーションの形態は、好きなものを選択してください。

*/

namespace Practice16_1 {
    internal class Program {
        static void Main(string[] args) {
            var program = new Program();
            program.RunAsync().Wait();

            Console.WriteLine("処理が完了しました。何かキーを押してください...");
            Console.ReadKey();
        }

        private async Task RunAsync() {
            var filePath = @"..\..\16-1.txt";

            try {
                var content = await ReadFileAsync(filePath);
                Console.WriteLine("=== ファイルの内容 ===");
                Console.WriteLine(content);
            } catch (FileNotFoundException) {
                Console.WriteLine($"ファイルが見つかりません: {filePath}");
            } catch (Exception ex) {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
        }

        private async Task<string> ReadFileAsync(string filePath) {
            var sb = new StringBuilder();

            using (var reader = new StreamReader(filePath, Encoding.UTF8)) {
                string line;
                while ((line = await reader.ReadLineAsync()) != null) {
                    sb.AppendLine(line);
                }
            }

            return sb.ToString();
        }
    }
}
