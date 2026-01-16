using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/* 問題16.1
 
.NET Farmework 4.5以降のStreamReaderクラスには、非同期処理を実現するReadLineAsyncメソッドが追加されています。
このメソッドを使い、テキストファイルを非同期で読み込むコードを書いてください。
アプリケーションの形態は、好きなものを選択してください。

*/

namespace Practice16_1 {
    class Program {
        static async Task Main(string[] args) {
            var wFilePath = @"..\..\16-1.txt";

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("指定されたファイルが存在しません。");
                return;
            }

            try {
                var wContent = await GetFileAsync(wFilePath);
                Console.WriteLine("=== ファイルの内容 ===");
                Console.WriteLine(wContent);
            } catch (Exception ex) {
                Console.WriteLine(
                    $"エラーが発生しました{Environment.NewLine}" +
                    $"内容：{ex.Message}");
            }

            Console.WriteLine("処理が完了しました。何かキーを押してください...");
            Console.ReadKey();
        }

        /// <summary>
        /// 指定のファイルの内容を取得する
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        /// <returns>ファイルの内容を含む文字列</returns>
        static async Task<string> GetFileAsync(string vFilePath) {
            var wStringBuilder = new StringBuilder();

            using (var wReader = new StreamReader(vFilePath, Encoding.UTF8)) {
                string wLine;
                while ((wLine = await wReader.ReadLineAsync()) != null) {
                    wStringBuilder.AppendLine(wLine);
                }
            }

            return wStringBuilder.ToString();
        }
    }
}
