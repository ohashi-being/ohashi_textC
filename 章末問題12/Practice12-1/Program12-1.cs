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
        static void Main(string[] args) {
            var wEmployee = new Employee(2947, "相沢 悠真", new DateTime(2022, 7, 21));
            // 解答1
            Console.WriteLine("-------------解答1-------------");
            using (var wWriter = XmlWriter.Create(@"..\..\Sample12-1-1.xml")) {
                var wSerializer = new XmlSerializer(wEmployee.GetType());
                wSerializer.Serialize(wWriter, wEmployee);
                Console.WriteLine("XMLファイルにシリアル化が完了しました。\n");
            }
            using (var wReader = XmlReader.Create(@"..\..\Sample12-1-1.xml")) {
                var wSerializer = new XmlSerializer(typeof(Employee));
                var wLoadedEmployee = wSerializer.Deserialize(wReader) as Employee;
                if (wLoadedEmployee == null) {
                    Console.WriteLine("\n逆シリアル化に失敗しました。\n");
                    return;
                }
                Console.WriteLine($"{wLoadedEmployee}\n\nXMLファイルからの逆シリアル化が完了しました。\n");
            }
            // 解答2
            Console.WriteLine("-------------解答2-------------");
            var wEmployees = new Employee[] {
                wEmployee,
                new Employee(2947, "藤原 陽翔", new DateTime(2022, 7, 21)),
                new Employee(3021, "宮崎 陽菜", new DateTime(2021, 4, 15)),
                new Employee(3150, "三好 海斗", new DateTime(2020, 11, 30))
            };
            using (var wWriter = XmlWriter.Create(@"..\..\Sample12-1-2.xml")) {
                var wSerializer = new DataContractSerializer(wEmployees.GetType());
                wSerializer.WriteObject(wWriter, wEmployees);
                Console.WriteLine("XMLファイルにシリアル化が完了しました。\n");
            }
            // 解答3
            Console.WriteLine("-------------解答3-------------");
            using (var wReader = XmlReader.Create(@"..\..\Sample12-1-2.xml")) {
                var wSerializer = new DataContractSerializer(typeof(Employee[]));
                var wLoadedEmployees = wSerializer.ReadObject(wReader) as Employee[];
                if (wLoadedEmployees == null) {
                    Console.WriteLine("\n逆シリアル化に失敗しました。\n");
                    return;
                }
                foreach (var wLoadedEmployee in wLoadedEmployees) {
                    Console.WriteLine(wLoadedEmployee.ToString());
                }
                Console.WriteLine("\nXMLファイルからの逆シリアル化が完了しました。\n");
            }
            // 解答4
            Console.WriteLine("-------------解答4-------------");
            var wEmployeesForJson = wEmployees.Select(x => new EmployeeForJson(x)).ToArray();
            using (var wStream = new FileStream(@"..\..\Sample12-1-4.json", FileMode.Create, FileAccess.Write)) {
                var wSerializer = new DataContractJsonSerializer(wEmployeesForJson.GetType());
                wSerializer.WriteObject(wStream, wEmployeesForJson);
                Console.WriteLine("\nJSONファイルにシリアル化が完了しました。");
            }
        }
    }
}
