using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
/* 問題12.2
1.XmlSerializerクラスを使って、以下のXMLファイルを逆シリアル化し、Novelistオブジェクトを作成してください。
  Novelistクラスには必要ならば適切な属性を付与してください。

<novelist>
<name>アーサー・C・クラーク</name>
<birth>1917-12-16</birth>
<masterpieces>
<title>2001年宇宙の旅</title>
<title>幼年期の終り</title>
</masterpieces>
</novelist>

2.上記Novelistオブジェクトの内容を以下のようなJSONファイルにシリアル化するコードを記述してください。

{"birth":"1917-12-16T00:00:00Z",
"masterpieces":["2001年宇宙の旅","幼年期の終り"],
"name":"アーサー・C・クラーク"}

*/
namespace Practice12_2 {
    internal class Program {
        static void Main(string[] args) {
            Novelist wNoveList;
            try {
                ValidateFilePath(@"..\..\Sample12-2.xml", ".xml");
                using (var wReader = XmlReader.Create(@"..\..\Sample12-2.xml")) {
                    var wSerializer = new XmlSerializer(typeof(Novelist));
                    wNoveList = (Novelist)wSerializer.Deserialize(wReader);
                    Console.WriteLine(wNoveList);
                    Console.WriteLine("XMLファイルからの逆シリアル化が完了しました。\n");
                }
                ValidateFilePathForWrite(@"..\..\Sample12-2.json", ".json");
                var wSettings = new DataContractJsonSerializerSettings {
                    UseSimpleDictionaryFormat = true,
                    DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ"),
                };
                using (var wStream = new FileStream(@"..\..\Sample12-2.json", FileMode.Create, FileAccess.Write)) {
                    var wSerializer = new DataContractJsonSerializer(wNoveList.GetType(), wSettings);
                    wSerializer.WriteObject(wStream, wNoveList);
                    Console.WriteLine("JSONファイルにシリアル化が完了しました。");
                }
            } catch (InvalidOperationException ex) {
                Console.WriteLine($"シリアライゼーションエラー: {ex.Message}");
                if (ex.InnerException != null) {
                    Console.WriteLine($"詳細: {ex.InnerException.Message}");
                }
            } catch (NullReferenceException ex) {
                Console.WriteLine($"Null参照エラー (データ不完全): {ex.Message}");
                Console.WriteLine("XMLファイルに必要なデータが不足している可能性があります。");
            } catch (ArgumentNullException ex) {
                Console.WriteLine($"引数Nullエラー: {ex.Message}");
            } catch (FileNotFoundException ex) {
                Console.WriteLine($"ファイルエラー: {ex.Message}");
            } catch (DirectoryNotFoundException ex) {
                Console.WriteLine($"ディレクトリエラー: {ex.Message}");
            } catch (ArgumentException ex) {
                Console.WriteLine($"引数エラー: {ex.Message}");
                Console.WriteLine($"例外タイプ: {ex.GetType().Name}");
            } catch (IOException ex) {
                Console.WriteLine($"ファイルアクセスエラー: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($"予期しないエラー ({ex.GetType().Name}): {ex.Message}");
                Console.WriteLine($"スタックトレース: {ex.StackTrace}");
            }
        }
        /// <summary>
        /// 読み込み用ファイルパスの妥当性を検証する。
        /// </summary>
        /// <param name="vFilePath">読み込み対象のファイルパス</param>
        /// <param name="vExpectedExtension">期待する拡張子（例：".xml"）</param>
        private static void ValidateFilePath(string vFilePath, string vExpectedExtension) {
            if (!File.Exists(vFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {vFilePath}");
            if (Path.GetExtension(vFilePath) != vExpectedExtension) throw new ArgumentException($"{vExpectedExtension}ファイルではありません。");
        }
        /// <summary>
        /// 書き込み用ファイルパスの妥当性を検証する。
        /// </summary>
        /// <param name="vFilePath">書き込み対象のファイルパス</param>
        /// <param name="vExpectedExtension">期待する拡張子（例：".json"）</param>
        private static void ValidateFilePathForWrite(string vFilePath, string vExpectedExtension) {
            var wDirectory = Path.GetDirectoryName(Path.GetFullPath(vFilePath));
            if (!Directory.Exists(wDirectory)) throw new DirectoryNotFoundException($"ディレクトリが存在しません: {wDirectory}");
            if (Path.GetExtension(vFilePath) != vExpectedExtension) throw new ArgumentException($"{vExpectedExtension}ファイルではありません。");
        }
    }
}
