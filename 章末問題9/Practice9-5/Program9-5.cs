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
        private const long C_MegaByte = 1024 * 1024;
        static void Main(string[] args) {
            var wFilePath = @"..\..\9-5";
            ShowLargeFile(wFilePath, 1 * C_MegaByte);
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 指定のディレクトリおよびそのサブディレクトリの配下にあるファイルから基準のファイルサイズ以上のファイル名の一覧を表示する
        /// </summary>
        /// <param name="vFilePath">指定のディレクトリのパス</param>
        /// <param name="vFileSize">基準となるファイルサイズ</param>
        private static void ShowLargeFile(string vFilePath, long vFileSize) {
            if (!Directory.Exists(vFilePath)) throw new FileNotFoundException($"ディレクトリが存在しません: {vFilePath}");
            var wFiles = Directory.EnumerateFiles(vFilePath, "*.*", SearchOption.AllDirectories)
                                 .Where(x => GetFileSize(x) >= vFileSize);
            if (!wFiles.Any()) {
                Console.WriteLine($"{(int)vFileSize/C_MegaByte}MB以上のファイルは存在しません。");
                return;
            }
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
