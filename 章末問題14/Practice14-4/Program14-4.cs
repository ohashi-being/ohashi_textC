using System;
using System.IO;
using System.Net.Http;

/* 問題14.4
あなたがよく訪れるWebページのHTMLを取得し、ファイルに保存するプログラムを書いてください。
*/

namespace Practice14_4 {
    class Program {
        static void Main(string[] args) {
            var wUrl = @"https://tabelog.com/";
            var wHtmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "14-4.html");
            using (var wHttpClient = new HttpClient()) {
                Console.WriteLine($"HTMLを取得中: {wUrl}");
                try {
                    var wResponse = wHttpClient.GetAsync(wUrl).Result;
                    wResponse.EnsureSuccessStatusCode();
                    var wHtmlContent = wResponse.Content.ReadAsStringAsync().Result;
                    File.WriteAllText(wHtmlFilePath, wHtmlContent);
                    Console.WriteLine($"HTMLを正常に保存しました: {wHtmlFilePath}");
                } catch (Exception ex) {
                    Console.WriteLine(
                        $"Webページの取得に失敗しました。{Environment.NewLine}" +
                        $"エラー詳細: {ex.InnerException?.Message ?? ex.Message}{Environment.NewLine}" +
                        $"URLやネットワーク接続を確認してください。");
                }
                Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
                Console.ReadKey();
            }
        }
    }
}
