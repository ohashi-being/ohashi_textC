using System;
using System.IO;
/* 問題9.4
指定したディレクトリ直下にあるファイルを別のディレクトリにコピーするプログラムを作成してください。
その際、コピーするファイル名は、拡張子を含まないファイル名の後ろに、_bakを追加してください。
コピー先に同名のファイルがある場合は置き換えてください。
*/
namespace Practice9_4 {
    class Program {
        static void Main(string[] args) {
            if (args.Length <= 1) {
                Console.WriteLine("エラー：引数が不足しています。");
                Console.WriteLine("入力方法 : Practice9_4.exe <元となるディレクトリ> <コピーするディレクトリ>");
                return;
            }
            var wSourceDir = args[0];
            var wDestDir = args[1];
            CopyFiles(wSourceDir, wDestDir);
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 元となるディレクトリ直下のファイルをコピー先ディレクトリにコピーする
        /// </summary>
        /// <param name="vSourceDir">元となるディレクトリ</param>
        /// <param name="vDestDir">コピー先のディレクトリ</param>
        private static void CopyFiles(string vSourceDir, string vDestDir) {
            var wFilePaths = Directory.EnumerateFiles(vSourceDir, "*.*");
            if (!Directory.Exists(vDestDir))
                Directory.CreateDirectory(vDestDir);
            foreach (var wFilePath in wFilePaths) {
                var wDestPath = GetBakFilePath(vDestDir, wFilePath);
                Console.WriteLine(wDestPath);
                File.Copy(wFilePath, wDestPath, overwrite: true);
            }
        }
        /// <summary>
        /// ファイル名に_bakを追加したパスを取得する
        /// </summary>
        /// <param name="vDestDir">コピー先のディレクトリ</param>
        /// <param name="vFile">元のファイルのパス/param>
        /// <returns>ファイル名に_bakを追加したパス</returns>
        private static string GetBakFilePath(string vDestDir, string vFile) {
            var wFilename = Path.GetFileNameWithoutExtension(vFile) + "_bak";
            var wExtension = Path.GetExtension(vFile);
            return Path.Combine(vDestDir, wFilename + wExtension);
        }
    }
}
