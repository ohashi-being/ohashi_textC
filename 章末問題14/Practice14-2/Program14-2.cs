using System;
using System.Diagnostics;
using System.Reflection;

/* 問題14.2
自分自身のファイルバージョンとアセンブリバージョンを表示するプログラムを書いて下さい。
*/

namespace Practice14_2 {
    class Program {
        static void Main(string[] args) {
            var wAssembly = Assembly.GetExecutingAssembly();
            var wAssemblyVersion = wAssembly.GetName().Version;
            Console.WriteLine("=== バージョン情報 ===");
            Console.WriteLine($"Assembly Version : {wAssemblyVersion?.ToString() ?? "不明"}");
            if (!string.IsNullOrEmpty(wAssembly.Location)) {
                var wFileVersionInfo = FileVersionInfo.GetVersionInfo(wAssembly.Location);
                Console.WriteLine($"File Version     : {wFileVersionInfo?.FileVersion ?? "不明"}");
            } else {
                Console.WriteLine("File Version     : 取得不可");
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
