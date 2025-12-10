using System;
using System.IO;
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
            var wDirectoryPath = @"..\..\9-5";
            ShowLargeFile(wDirectoryPath, 1234567891 * C_MegaByte);
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 指定のディレクトリおよびそのサブディレクトリの配下にあるファイルから基準のファイルサイズ以上のファイル名の一覧を表示する
        /// </summary>
        /// <param name="vDirectoryPath">指定のディレクトリのパス</param>
        /// <param name="vFileSize">基準となるファイルサイズ</param>
        private static void ShowLargeFile(string vDirectoryPath, long vFileSize) {
            if (!Directory.Exists(vDirectoryPath)) throw new DirectoryNotFoundException($"ディレクトリが存在しません: {vDirectoryPath}");
            bool wIsFileExist = false;
            foreach (var wFile in Directory.EnumerateFiles(vDirectoryPath, "*.*", SearchOption.AllDirectories)) {
                if(GetFileSize(wFile) >= vFileSize) {
                    Console.WriteLine(wFile);
                    wIsFileExist = true;
                }
            }
            if (!wIsFileExist) {
                Console.WriteLine($"{vFileSize/C_MegaByte}MB以上のファイルは存在しません。");
                return;
            }
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
