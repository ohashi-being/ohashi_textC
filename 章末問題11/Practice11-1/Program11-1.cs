using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
/* 問題11.1
Sample11-1.xmlファイルに対して以下の問題に答えてください。

1. XMLファイルを読み込み、競技名とチームメンバー数の一覧を表示するプログラムを作成してください。

2.最初にプレーされた年の若い順に漢字の競技名を表示するプログラムを作成してください。

3.メンバー数が最も多い競技名を表示するプログラムを作成してください。

4.サッカーの情報を追加して、新たなXMLファイルに出力してください。
  ファイル名は問いません。
  なお、サッカーの情報はご自身で調べて追加してください。
  手間を惜しまずに調べることもプログラマーには必要なことです。
*/
namespace Practice11_1 {
    class Program {
        static void Main(string[] args) {
            // 解答1
            var wFilePath = @"..\..\Sample11-1.xml";
            if (!File.Exists(wFilePath)) {
                Console.WriteLine("XMLファイルが存在しません。");
                return;
            }
            if (!TryLoadXmlDocument(wFilePath, out var wXDocument)) {
                Console.WriteLine("XMLファイルの形式が正しくありません。");
                return;
            }
            var wXDocment = XDocument.Load(wFilePath);
            var wBallSports = wXDocment.Root.Elements();
            Console.WriteLine("-----------解答1-----------");
            foreach (var wBallSport in wBallSports) {
                var wSportName = wBallSport.Element("name").Value;
                var wTeamMember = wBallSport.Element("teammembers").Value;
                Console.WriteLine($"競技名: {wSportName}, チームメンバー数: {wTeamMember}");
            }
            // 解答2
            Console.WriteLine("-----------解答2-----------");
            var wBallSportsSortedByYear = wBallSports.OrderBy(x => (int)x.Element("firstplayed"));
            foreach (var wBallSportSortedByYear in wBallSportsSortedByYear) {
                var wBallSportKanjiName = wBallSportSortedByYear.Element("name").Attribute("kanji").Value;
                Console.WriteLine($"競技名: {wBallSportKanjiName}");
            }
            // 解答3
            Console.WriteLine("-----------解答3-----------");
            var wSportWithMaxMembers = wBallSports.OrderByDescending(x => (int)x.Element("teammembers")).First();
            var wMaxTeamMembers = (int)wSportWithMaxMembers.Element("teammembers");
            var wBallSportMaxMembersName = wSportWithMaxMembers.Element("name").Value;
            Console.WriteLine($"メンバー数が最も多い競技名: {wBallSportMaxMembersName}");
            Console.WriteLine($"{wMaxTeamMembers}名");
            // 解答4
            var wSoccerInfo = new XElement("sport",
                                new XElement("name", new XAttribute("kanji", "蹴球"), "サッカー"),
                                new XElement("teammembers", 11),
                                new XElement("firstplayed", 1863)
            );
            wXDocment.Root.Add(wSoccerInfo);
            var wNewFilePath = @"..\..\Sample11-1.ver2.xml";
            wXDocment.Save(wNewFilePath);
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
