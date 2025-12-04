using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
/* 問題11.2
Sample11-2.xmlファイルを以下の形式に変換し、別のXMLファイルに保存するプログラムを作成してください。
<difficultkanji>
  <word kanji="鬼灯" yomi="ほおずき"/>
  <word kanji="暖簾" yomi="のれん"/>
  <word kanji="杜撰" yomi="ずさん"/>
  <word kanji="坩堝" yomi="るつぼ"/>
</difficultkanji>
*/
namespace Practice11_2 {
    class Program {
        static void Main(string[] args) {
            var wFilePath = @"..\..\Sample11-2.xml";
            if (!File.Exists(wFilePath)) {
                Console.WriteLine("XMLファイルが存在しません。");
                return;
            }
            if (!TryLoadXmlDocument(wFilePath, out var wXDocument)) {
                Console.WriteLine("XMLファイルの形式が正しくありません。");
                return;
            }
            var wXDocment = XDocument.Load(wFilePath);
            var wWord = wXDocment.Root.Elements();
            var wKanjiToYomi = wWord.ToDictionary(x => x.Element("kanji").Value, x => x.Element("yomi").Value);
            var wWordElements = wKanjiToYomi.Select(x => new XElement("word", new XAttribute("kanji", x.Key), new XAttribute("yomi", x.Value)));
            var wRoot = new XElement("difficultkanji", wWordElements);
            wRoot.Save(@"..\..\Sample11-2.ver2.xml");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// XMLファイルの読み込みを試行し、成功した場合はXDocumentを返す
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        /// <param name="vXDocument">読み込み成功時のXDocument</param>
        /// <returns>読み込みできるかどうか</returns>
        static bool TryLoadXmlDocument(string vFilePath, out XDocument vXDocument) {
            try {
                vXDocument = XDocument.Load(vFilePath);
                return true;
            } catch (System.Xml.XmlException) {
                vXDocument = null;
                return false;
            }
        }
    }
}
