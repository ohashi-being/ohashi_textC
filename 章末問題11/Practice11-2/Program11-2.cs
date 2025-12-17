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
            XDocument wXDocument;
            try {
                wXDocument = XDocument.Load(wFilePath);
            } catch (FileNotFoundException) {
                Console.WriteLine("XMLファイルが存在しません。");
                return;
            } catch (Exception) {
                Console.WriteLine("XMLファイルの形式が正しくありません。");
                return;
            }
            var wSaveFilePath = GetOutputPath("Sample11-2.ver2.xml");
            var wWordElements = wXDocument.Root.Elements().Select(x => new XElement("word",
                new XAttribute("kanji", x.Element("kanji").Value),
                new XAttribute("yomi", x.Element("yomi").Value)));
            var wRoot = new XElement("difficultkanji", wWordElements);
            wRoot.Save(wSaveFilePath);
            Console.WriteLine($"XMLファイルを保存しました: {Path.GetFullPath(wSaveFilePath)}");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        static string GetOutputPath(string vDefaultFile) {
            while (true) {
                Console.WriteLine("保存先ファイルのパスを入力してください: ");
                var wOutputPath = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(wOutputPath)) {
                    wOutputPath = vDefaultFile;
                    Console.WriteLine("現在のディレクトリに保存します");
                }
                if (wOutputPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0) {
                    Console.WriteLine("パスに使用できない文字が含まれています。再入力してください。");
                    continue;
                }
                if (Path.GetFileName(wOutputPath).IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) {
                    Console.WriteLine("ファイル名に使用できない文字が含まれています。再入力してください。");
                    continue;
                }
                return wOutputPath;
            }
        }
    }
}
