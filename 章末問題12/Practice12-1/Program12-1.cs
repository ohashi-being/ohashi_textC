using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
/* 問題12.1
1.Employeeクラスが定義されています。
  このオブジェクトをXMLにシリアル化するコードと逆シリアル化するコードをXmlSerializerクラスを使用して記述してください。
  この時、XMLの要素名はすべて小文字にしてください。

2.複数のEmployeeオブジェクトが配列に格納されているとします。
  この配列をDataContractSerializerクラスを使用してXMLファイルにシリアル化してください。

3.2.で作成したファイルを読み込み、逆シリアル化してください。

4.複数のEmployeeオブジェクトが配列に格納されているとします。
  この配列をDataContractJsonSerializerクラスを使用してJSONファイルに出力してください。
  この時、シリアル化対象にIdは含めないでください。
*/
namespace Practice12_1 {
    class Program {
        /// <summary>
        /// XML出力用の設定
        /// </summary>
        private static readonly XmlWriterSettings C_XmlSettings = new XmlWriterSettings {
            Indent = true,
        };
        static void Main(string[] args) {
            var wEmployee = new Employee(2947, "相沢 悠真", new DateTime(2022, 7, 21));
            // 解答1
            Console.WriteLine("-------------解答1-------------");
            try {
                ValidateFilePathForWrite(@"..\..\Sample12-1-1.xml", ".xml");
                using (var wWriter = XmlWriter.Create(@"..\..\Sample12-1-1.xml", C_XmlSettings)) {
                    var wSerializer = new XmlSerializer(wEmployee.GetType());
                    wSerializer.Serialize(wWriter, wEmployee);
                    Console.WriteLine("XMLファイルにシリアル化が完了しました。\n");
                }
                ValidateFilePath(@"..\..\Sample12-1-1.xml", ".xml");
                using (var wReader = XmlReader.Create(@"..\..\Sample12-1-1.xml")) {
                    var wSerializer = new XmlSerializer(typeof(Employee));
                    var wLoadedEmployee = (Employee)wSerializer.Deserialize(wReader);
                    Console.WriteLine($"{wLoadedEmployee}\n\nXMLファイルからの逆シリアル化が完了しました。\n");
                }
            }
            catch (InvalidOperationException ex) {
                Console.WriteLine($"シリアライゼーションエラー: {ex.Message}");
                return;
            }
            catch (IOException ex) {
                Console.WriteLine($"ファイルアクセスエラー: {ex.Message}");
                return;
            }
            catch (Exception ex) {
                Console.WriteLine($"エラー: {ex.Message}");
                return;
            }
            // 解答2
            Console.WriteLine("-------------解答2-------------");
            var wEmployees = new Employee[] {
                wEmployee,
                new Employee(2947, "藤原 陽翔", new DateTime(2022, 7, 21)),
                new Employee(3021, "宮崎 陽菜", new DateTime(2021, 4, 15)),
                new Employee(3150, "三好 海斗", new DateTime(2020, 11, 30))
            };
            try {
                ValidateFilePathForWrite(@"..\..\Sample12-1-2.xml", ".xml");
                using (var wWriter = XmlWriter.Create(@"..\..\Sample12-1-2.xml",C_XmlSettings)) {
                    var wSerializer = new DataContractSerializer(wEmployees.GetType());
                    wSerializer.WriteObject(wWriter, wEmployees);
                    Console.WriteLine("XMLファイルにシリアル化が完了しました。\n");
                }
            }
            catch (InvalidOperationException ex) {
                Console.WriteLine($"シリアライゼーションエラー: {ex.Message}");
                return;
            }
            catch (IOException ex) {
                Console.WriteLine($"ファイルアクセスエラー: {ex.Message}");
                return;
            }
            catch (Exception ex) {
                Console.WriteLine($"エラー: {ex.Message}");
                return;
            }
            // 解答3
            Console.WriteLine("-------------解答3-------------");
            try {
                ValidateFilePath(@"..\..\Sample12-1-2.xml", ".xml");
                using (var wReader = XmlReader.Create(@"..\..\Sample12-1-2.xml")) {
                    var wSerializer = new DataContractSerializer(typeof(Employee[]));
                    var wLoadedEmployees = (Employee[])wSerializer.ReadObject(wReader);
                    foreach (var wLoadedEmployee in wLoadedEmployees) {
                        Console.WriteLine(wLoadedEmployee.ToString());
                    }
                    Console.WriteLine("\nXMLファイルからの逆シリアル化が完了しました。\n");
                }
            }
            catch (InvalidOperationException ex) {
                Console.WriteLine($"シリアライゼーションエラー: {ex.Message}");
                return;
            }
            catch (IOException ex) {
                Console.WriteLine($"ファイルアクセスエラー: {ex.Message}");
                return;
            }
            catch (Exception ex) {
                Console.WriteLine($"エラー: {ex.Message}");
                return;
            }
            // 解答4
            Console.WriteLine("-------------解答4-------------");
            try {
                ValidateFilePathForWrite(@"..\..\Sample12-1-4.json", ".json");
                var wEmployeesForJson = wEmployees.Select(x => new EmployeeForJson(x)).ToArray();
                using (var wStream = new FileStream(@"..\..\Sample12-1-4.json", FileMode.Create, FileAccess.Write)) {
                    var wSerializer = new DataContractJsonSerializer(wEmployeesForJson.GetType());
                    wSerializer.WriteObject(wStream, wEmployeesForJson);
                    Console.WriteLine("\nJSONファイルにシリアル化が完了しました。");
                }
            }
            catch (InvalidOperationException ex) {
                Console.WriteLine($"シリアライゼーションエラー: {ex.Message}");
            }
            catch (IOException ex) {
                Console.WriteLine($"ファイルアクセスエラー: {ex.Message}");
            }
            catch (Exception ex) {
                Console.WriteLine($"エラー: {ex.Message}");
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
        /// <param name="vExpectedExtension">期待する拡張子（例：".xml"）</param>
        private static void ValidateFilePathForWrite(string vFilePath, string vExpectedExtension) {
            var wDirectory = Path.GetDirectoryName(Path.GetFullPath(vFilePath));
            if (!Directory.Exists(wDirectory)) throw new DirectoryNotFoundException($"ディレクトリが存在しません: {wDirectory}");
            if (Path.GetExtension(vFilePath) != vExpectedExtension) throw new ArgumentException($"{vExpectedExtension}ファイルではありません。");
        }
    }
}