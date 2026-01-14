using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

/* 問題14.2
自分自身のファイルバージョンとアセンブリバージョンを表示するプログラムを書いて下さい。
*/

namespace Practice14_2 {
    class Program {
        static void Main(string[] args) {
            var wAssembly = Assembly.GetExecutingAssembly();
            var wAssemblyVersion = wAssembly.GetName().Version;
            
            var wLabels = new[] { "Assembly Version", "File Version" };
            int wLabelWidth = wLabels.Max(x => x.Length);
            
            Console.WriteLine("=== バージョン情報 ===");
            Console.WriteLine($"{"Assembly Version".PadRight(wLabelWidth)} : {wAssemblyVersion?.ToString() ?? "不明"}");
            
            if (!string.IsNullOrEmpty(wAssembly.Location)) {
                var wFileVersionInfo = FileVersionInfo.GetVersionInfo(wAssembly.Location);
                Console.WriteLine($"{"File Version".PadRight(wLabelWidth)} : {wFileVersionInfo?.FileVersion ?? "不明"}");
            } else {
                Console.WriteLine($"{"File Version".PadRight(wLabelWidth)} : 取得不可");
            }
            
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
