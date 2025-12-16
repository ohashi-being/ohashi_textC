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
            XDocument wXDocument;
            try {
                wXDocument = XDocument.Load(wFilePath);
            } catch (Exception) {
                Console.WriteLine("XMLファイルの形式が正しくありません。");
                return;
            }
            var wBallSports = wXDocument.Root?.Elements().ToList();
            if (wBallSports == null || !wBallSports.Any()) {
                Console.WriteLine("データが存在しません。");
                return;
            }
            Console.WriteLine("-----------解答1-----------");
            foreach (var wBallSport in wBallSports) {
                var wSportName = wBallSport.Element("name")?.Value ?? "不明な競技";
                string wTeamMemberString = wBallSport.Element("teammembers")?.Value ?? "不明";
                if (int.TryParse(wTeamMemberString, out int wTeamMember)) {
                    Console.WriteLine($"競技名: {wSportName},チームメンバー数: {wTeamMember}");
                } else {
                    Console.WriteLine($"[エラー]競技名: {wSportName}のチームメンバー数が整数ではありません: {wTeamMemberString}");
                    Console.WriteLine($"競技名: {wSportName}, チームメンバー数: {wTeamMemberString}");
                }
            }
            // 解答2
            Console.WriteLine("-----------解答2-----------");
            try {
                var wValidSportsForYear = wBallSports
                    .Select(x => new { Sport = x, Year = (int?)x.Element("firstplayed") })
                    .Where(x => x.Year != null)
                    .OrderBy(x => x.Year);
                foreach (var wValidSport in wValidSportsForYear) {
                    var wBallSportKanjiName = wValidSport.Sport.Element("name")?.Attribute("kanji")?.Value ?? "漢字なし";
                    Console.WriteLine($"競技名: {wBallSportKanjiName}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
            // 解答3
            Console.WriteLine("-----------解答3-----------");
            try {
                var wValidSports = wBallSports
                    .Select(x => new { Sport = x, Members = (int?)x.Element("teammembers") })
                    .Where(x => x.Members != null)
                    .ToList();
                if (!wValidSports.Any()) {
                    Console.WriteLine("有効なチームメンバー数のデータが見つかりません。");
                    return;
                }
                var wMostMembersSport = wValidSports.OrderByDescending(x => x.Members).First();
                Console.WriteLine($"メンバー数が最も多い競技名: {wMostMembersSport.Sport.Element("name")?.Value ?? "不明な競技"}");
                Console.WriteLine($"{wMostMembersSport.Members}名");
            } catch (Exception ex) {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
            // 解答4
            Console.WriteLine("-----------解答4-----------");
            try {
                var wSoccerInfo = new XElement("sport",
                                    new XElement("name", new XAttribute("kanji", "蹴球"), "サッカー"),
                                    new XElement("teammembers", 11),
                                    new XElement("firstplayed", 1863)
                                  );
                wXDocument.Root.Add(wSoccerInfo);
                var wNewFilePath = @"..\..\Sample11-1.ver2.xml";
                wXDocument.Save(wNewFilePath);
                Console.WriteLine("サッカーの情報を追加し、XMLファイルを保存しました。");
            } catch (Exception ex) {
                Console.WriteLine($"XMLファイル保存でエラーが発生しました: {ex.Message}");
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}