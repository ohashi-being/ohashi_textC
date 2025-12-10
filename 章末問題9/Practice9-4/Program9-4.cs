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
            var wSourceDir = @"..\..\9-4_Source";
            var wDestDir = @"..\..\9-4_Dest";
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
            if (string.IsNullOrEmpty(vSourceDir) || string.IsNullOrEmpty(vDestDir)) {
                Console.WriteLine("エラー：コピー元またはコピー先のディレクトリが指定されていません。");
                return;
            }
            if (!Directory.Exists(vSourceDir)) {
                Console.WriteLine($"エラー：コピー元のディレクトリが存在しません。{vSourceDir}");
                return;
            }
            if (!Directory.Exists(vDestDir)) Directory.CreateDirectory(vDestDir);
            Console.WriteLine("処理成功！！");
            Console.WriteLine();
            Console.WriteLine($"コピー元ディレクトリ: {vSourceDir}");
            Console.WriteLine($"コピー先ディレクトリ: {vDestDir}");
            Console.WriteLine();
            Console.WriteLine("コピー内容");
            foreach (var wFilePath in Directory.EnumerateFiles(vSourceDir, "*")) {
                var wDestPath = GetBakFilePath(vDestDir, wFilePath);
                File.Copy(wFilePath, wDestPath, overwrite: true);
                Console.WriteLine(Path.GetFileName(wDestPath));
            } 
        }
        /// <summary>
        /// ファイル名に_bakを追加したパスを取得する
        /// </summary>
        /// <param name="vDestDir">コピー先のディレクトリ</param>
        /// <param name="vFilePath">元のファイルのパス</param>
        /// <returns>ファイル名に_bakを追加したパス</returns>
        private static string GetBakFilePath(string vDestDir, string vFilePath) => Path.Combine(vDestDir, $"{Path.GetFileNameWithoutExtension(vFilePath)}_bak{Path.GetExtension(vFilePath)}");
    }
}
