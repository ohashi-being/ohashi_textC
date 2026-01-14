using System;
using System.IO;
using System.Net;

/* 問題14.4
あなたがよく訪れるWebページのHTMLを取得し、ファイルに保存するプログラムを書いてください。
*/

namespace Practice14_4 {
    class Program {
        static void Main(string[] args) {
            var wUrl = @"https://tabelog.com/";
            var wHtmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "14-4.html");
            using (var wWebClient = new WebClient()) {
                Console.WriteLine($"HTMLを取得中: {wUrl}");
                try {
                    wWebClient.DownloadFile(wUrl, wHtmlFilePath);
                    Console.WriteLine($"HTMLを正常に保存しました: {wHtmlFilePath}");
                } catch (WebException wWebException) {
                    ShowWebErrorMessage(wWebException);
                } catch (Exception wException) {
                    Console.WriteLine($"予期しないエラー: {wException.Message}");
                }
                Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// WebException発生時のエラーメッセージ表示
        /// </summary>
        /// <param name="vWebException">WebExceptionの例外オブジェクト</param>
        static void ShowWebErrorMessage(WebException vWebException) {
            if (vWebException.Response is HttpWebResponse wResponse && wResponse.StatusCode == HttpStatusCode.NotFound) {
                Console.WriteLine("指定したページが見つかりませんでした。");
                Console.WriteLine("URLを確認してください。");
                return;
            }
            Console.WriteLine("Webページの取得に失敗しました。");
            Console.WriteLine("URLを確認してください。");
        }
    }
}
