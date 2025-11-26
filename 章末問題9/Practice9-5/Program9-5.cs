using System;
using System.IO;
using System.Linq;
/* 問題9.5
指定したディレクトリおよびそのサブディレクトリの配下にあるファイルからファイルサイズが1Mバイト以上のファイル名の一覧を表示するプログラムを書いてください。
*/
namespace Practice9_5 {
    class Program {
        /// <summary>
        /// 1メガバイトのバイト数
        /// </summary>
        private const long C_MegaBite = 1024 * 1024;
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("エラー：引数が不足しています。");
                Console.WriteLine("入力方法 : Practice9_5.exe <ディレクトリ>");
                return;
            }
            var wDirectry = args[0];
            if (!Directory.Exists(wDirectry)) {
                Console.WriteLine($"エラー：ディレクトリが存在しません: {wDirectry}");
                return;
            }
            ShowLargeFile(wDirectry, 1 * C_MegaBite);
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 指定のディレクトリおよびそのサブディレクトリの配下にあるファイルから基準のファイルサイズ以上のファイル名の一覧を表示する
        /// </summary>
        /// <param name="vDirectry">指定のディレクトリ</param>
        /// <param name="vFileSize">基準となるファイルサイズ</param>
        private static void ShowLargeFile(string vDirectry, long vFileSize) {
            var wFiles = Directory.EnumerateFiles(vDirectry, "*.*", SearchOption.AllDirectories)
                                 .Where(x => GetFileSize(x) >= vFileSize);
            foreach (var wFile in wFiles) Console.WriteLine(wFile);
        }
        /// <summary>
        /// ファイルのサイズを取得する
        /// </summary>
        /// <param name="vFile">任意のファイル</param>
        /// <returns>入力されたファイルのサイズ</returns>
        private static long GetFileSize(string vFile) {
            var wFileInfo = new FileInfo(vFile);
            return wFileInfo.Length;
        }
    }
}
