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
            using (var wReader = XmlReader.Create(@"..\..\Sample12-2.xml")) {
                var wSerializer = new XmlSerializer(typeof(Novelist));
                wNoveList = wSerializer.Deserialize(wReader) as Novelist;
                Console.WriteLine(wNoveList);
            }
            var wSettings = new DataContractJsonSerializerSettings {
                UseSimpleDictionaryFormat = true,
                DateTimeFormat = new System.Runtime.Serialization.DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ"),
            };
            using (var wStream = new FileStream(@"..\..\Sample12-2.json", FileMode.Create, FileAccess.Write)) {
                var wSerializer = new DataContractJsonSerializer(wNoveList.GetType(), wSettings);
                wSerializer.WriteObject(wStream, wNoveList);
            }
        }
    }
}
