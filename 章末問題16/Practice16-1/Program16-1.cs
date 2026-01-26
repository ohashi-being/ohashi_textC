using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/* 問題16.1
 
.NET Framework 4.5以降のStreamReaderクラスには、非同期処理を実現するReadLineAsyncメソッドが追加されています。
このメソッドを使い、テキストファイルを非同期で読み込むコードを書いてください。
アプリケーションの形態は、好きなものを選択してください。

*/

namespace Practice16_1 {
    class Program {
        static async Task Main(string[] args) {

            if (args.Length == 0) {
                Console.WriteLine("エラー: 検索対象のファイルパスを引数で指定してください。");
                return;
            }

            string wFilePath = args[0];

            if (!File.Exists(wFilePath)) {
                Console.WriteLine("指定されたファイルが存在しません。");
                return;
            }

            if (!Path.GetExtension(wFilePath).Equals(".txt", StringComparison.OrdinalIgnoreCase)) {
                Console.WriteLine("指定されたファイルはテキストファイルではありません。");
                return;
            }

            try {
                var wContent = await GetFileAsync(wFilePath);
                Console.WriteLine("=== ファイルの内容 ===");
                Console.WriteLine(wContent);
            } catch (Exception ex) {
                Console.WriteLine(
                    $"エラーが発生しました{Environment.NewLine}" +
                    $"例外：{ex.GetType().Name}{Environment.NewLine}" +
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
