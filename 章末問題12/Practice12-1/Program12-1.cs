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
            var wEmployee = new Employee {
                Id = 2947,
                Name = "相沢 悠真",
                HireDate = new DateTime(2022, 7, 21)
            };
            // 解答1
            Console.WriteLine("-------------解答1-------------");
            using (var wWriter = XmlWriter.Create(@"..\..\Sample12-1-1.xml")) {
                var wSerializer = new XmlSerializer(wEmployee.GetType());
                wSerializer.Serialize(wWriter, wEmployee);
            }
            using (var wReader = XmlReader.Create(@"..\..\Sample12-1-1.xml")) {
                var wSerializer = new XmlSerializer(typeof(Employee));
                var wLoadedEmployee = (Employee)wSerializer.Deserialize(wReader);
                Console.WriteLine($"Id: {wLoadedEmployee.Id}, Name: {wLoadedEmployee.Name}, HireDate: {wLoadedEmployee.HireDate}");
            }
            Console.WriteLine();
            // 解答2
            Console.WriteLine("-------------解答2-------------");
            var wEmployees = new Employee[] {
                wEmployee,
                new Employee { Id = 2947, Name = "藤原 陽翔", HireDate = new DateTime(2022, 7, 21) },
                new Employee { Id = 3021, Name = "宮崎 陽菜", HireDate = new DateTime(2021, 4, 15) },
                new Employee { Id = 3150, Name = "三好 海斗", HireDate = new DateTime(2020, 11, 30) }
            };
            using (var wWriter = XmlWriter.Create(@"..\..\Sample12-1-2.xml")) {
                var wSerializer = new DataContractSerializer(wEmployees.GetType());
                wSerializer.WriteObject(wWriter, wEmployees);
            }
            // 解答3
            using (var wReader = XmlReader.Create(@"..\..\Sample12-1-2.xml")) {
                var wSerializer = new DataContractSerializer(typeof(Employee[]));
                var wLoadedEmployees = (Employee[])wSerializer.ReadObject(wReader);
                foreach (var wLoadedEmployee in wLoadedEmployees) {
                    Console.WriteLine($"Id: {wLoadedEmployee.Id}, Name: {wLoadedEmployee.Name}, HireDate: {wLoadedEmployee.HireDate}");
                }
            }
            // 解答4
            var wEmployeesForJson = wEmployees.Select(x => new EmployeeForJson(x)).ToArray();
            using (var wStream = new FileStream(@"..\..\Sample12-1-4.json", FileMode.Create, FileAccess.Write)) {
                var wSerializer = new DataContractJsonSerializer(wEmployeesForJson.GetType());
                wSerializer.WriteObject(wStream, wEmployeesForJson);
            }
        }
    }
}
