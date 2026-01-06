using System;
using System.IO;
using System.IO.Compression;

/* 問題14.5
指定されたZIPファイルから、拡張子が.txtのファイルのみを抽出するコンソールアプリケーションを作成してください。
ZIPファイルと出力先フォルダは以下に示すようにパラメータで指定します。
第1パラメータがZIPファイルのパス、第2パラメータが出力先フォルダのパスです。
出力先フォルダが存在しない場合は作成してください。
unziptxt.exe d:\temp\sample.zip d:\work
*/

namespace Practice14_5 {
    internal class Program {
        static void Main(string[] args) {
            if (args.Length < 2) {
                Console.WriteLine("使用方法: unziptxt.exe <ZIPファイルパス> <出力先フォルダパス> [拡張子]");
                Console.WriteLine("例: unziptxt.exe d:\\temp\\sample.zip d:\\work .txt");
                Console.WriteLine("拡張子を省略した場合は .txt ファイルを抽出します。");
                return;
            }
            string wZipFilePath = args[0];
            string wOutputFolder = args[1];
            string wTargetExtension = args.Length > 2 ? args[2] : ".txt";
            if (!wTargetExtension.StartsWith(".")) {
                wTargetExtension = "." + wTargetExtension;
            }
            try {
                int wExtractedCount = ExtractFilesByExtension(wZipFilePath, wOutputFolder, wTargetExtension);
                if (wExtractedCount > 0) {
                    Console.WriteLine($"\n抽出が完了しました。合計 {wExtractedCount} 個のファイルを抽出しました。");
                } else {
                    Console.WriteLine($"\n拡張子 '{wTargetExtension}' のファイルがZIP内に見つかりませんでした。");
                }
                Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
                Console.ReadKey();
            } catch (FileNotFoundException ex) {
                Console.WriteLine(ex.Message);
            } catch (InvalidDataException) {
                Console.WriteLine("ZIPファイルが壊れている可能性があります。");
            } catch (UnauthorizedAccessException) {
                Console.WriteLine("出力先フォルダへの書き込み権限がありません。");
            } catch (Exception ex) {
                Console.WriteLine("予期しないエラーが発生しました。");
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// ZIPファイルから指定された拡張子のファイルを抽出する
        /// </summary>
        /// <param name="vZipFilePath">ZIPファイルのパス</param>
        /// <param name="vOutputFolder">出力先フォルダのパス</param>
        /// <param name="vTargetExtension">抽出対象の拡張子</param>
        /// <returns>抽出したファイルの数</returns>
        static int ExtractFilesByExtension(string vZipFilePath, string vOutputFolder, string vTargetExtension) {
            if (!File.Exists(vZipFilePath)) {
                throw new FileNotFoundException($"ZIPファイルが見つかりません: {vZipFilePath}");
            }
            if (!Directory.Exists(vOutputFolder)) {
                Directory.CreateDirectory(vOutputFolder);
                Console.WriteLine($"出力先フォルダを作成しました: {vOutputFolder}");
            }
            int wExtractedCount = 0;
            using (var wZipArchive = ZipFile.OpenRead(vZipFilePath)) {
                foreach (var wEntry in wZipArchive.Entries) {
                    if (IsTargetFile(wEntry, vTargetExtension)) {
                        ExtractFile(wEntry, vOutputFolder);
                        Console.WriteLine($"抽出しました: {wEntry.Name}");
                        wExtractedCount++;
                    }
                }
            }
            return wExtractedCount;
        }
        /// <summary>
        /// エントリが対象ファイルかどうかを判定する
        /// </summary>
        /// <param name="vEntry">ZIPエントリ</param>
        /// <param name="vTargetExtension">対象拡張子</param>
        /// <returns>対象ファイルの場合true</returns>
        static bool IsTargetFile(ZipArchiveEntry vEntry, string vTargetExtension) {
            return !string.IsNullOrEmpty(vEntry.Name) &&
                   Path.GetExtension(vEntry.Name).Equals(vTargetExtension, StringComparison.OrdinalIgnoreCase);
        }
        /// <summary>
        /// ファイルを抽出する
        /// </summary>
        /// <param name="vEntry">ZIPエントリ</param>
        /// <param name="vOutputFolder">出力先フォルダ</param>
        static void ExtractFile(ZipArchiveEntry vEntry, string vOutputFolder) {
            string wOutputPath = Path.Combine(vOutputFolder, vEntry.Name);
            string wDirectoryPath = Path.GetDirectoryName(wOutputPath);
            if (!Directory.Exists(wDirectoryPath)) {
                Directory.CreateDirectory(wDirectoryPath);
            }
            vEntry.ExtractToFile(wOutputPath, overwrite: true);
        }
    }
}
