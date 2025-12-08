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
            var wBallSports = wXDocument.Root?.Elements();
            if (wBallSports == null || !wBallSports.Any()) {
                Console.WriteLine("データが存在しません。");
                return;
            }
            Console.WriteLine("-----------解答1-----------");
            foreach (var wBallSport in wBallSports) {
                var wSportName = GetElementValue(wBallSport, "name", "不明な競技");
                var wTeamMember = GetElementValue(wBallSport, "teammembers", "不明");
                Console.WriteLine($"競技名: {wSportName}, チームメンバー数: {wTeamMember}");
            }
            // 解答2
            Console.WriteLine("-----------解答2-----------");
            try {
                var wValidSportsForYear = wBallSports.Where(x => TryGetElementIntValue(x, "firstplayed", out _))
                                                     .OrderBy(x => GetElementIntValue(x, "firstplayed", 0));
                foreach (var wBallSport in wValidSportsForYear) {
                    var wBallSportKanjiName = GetAttributeValue(wBallSport?.Element("name"), "kanji", "漢字なし");
                    Console.WriteLine($"競技名: {wBallSportKanjiName}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
            }
            // 解答3
            Console.WriteLine("-----------解答3-----------");
            try {
                var wValidSportsForMembers = wBallSports.Where(x => TryGetElementIntValue(x, "teammembers", out _)).ToList();
                if (!wValidSportsForMembers.Any()) {
                    Console.WriteLine("有効なチームメンバー数のデータが見つかりません。");
                    return;
                }
                var wMostMembersSport = wValidSportsForMembers.Aggregate((wMaxMembersSport, wNextSport) => {
                    var maxMembers = GetElementIntValue(wMaxMembersSport, "teammembers", 0);
                    var nextMembers = GetElementIntValue(wNextSport, "teammembers", 0);
                    return nextMembers > maxMembers ? wNextSport : wMaxMembersSport;
                });
                Console.WriteLine($"メンバー数が最も多い競技名: {GetElementValue(wMostMembersSport, "name", "不明な競技")}");
                Console.WriteLine($"{GetElementValue(wMostMembersSport, "teammembers", "不明")}名");
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
            } catch (Exception) {
                vXDocument = null;
                return false;
            }
        }
        /// <summary>
        /// 要素の値を取得する
        /// </summary>
        /// <param name="vParent">親要素</param>
        /// <param name="vElementName">要素名</param>
        /// <param name="vDefaultValue">デフォルト値</param>
        /// <returns>要素の値またはデフォルト値</returns>
        static string GetElementValue(XElement vParent, string vElementName, string vDefaultValue = "") {
            return vParent?.Element(vElementName)?.Value ?? vDefaultValue;
        }
        /// <summary>
        /// 属性の値を取得する
        /// </summary>
        /// <param name="vElement">要素</param>
        /// <param name="vAttributeName">属性名</param>
        /// <param name="vDefaultValue">デフォルト値</param>
        /// <returns>属性の値またはデフォルト値</returns>
        static string GetAttributeValue(XElement vElement, string vAttributeName, string vDefaultValue = "") {
            return vElement?.Attribute(vAttributeName)?.Value ?? vDefaultValue;
        }
        /// <summary>
        /// 要素の値をintとして取得する
        /// </summary>
        /// <param name="vParent">親要素</param>
        /// <param name="vElementName">要素名</param>
        /// <param name="vDefaultValue">デフォルト値</param>
        /// <returns>int値またはデフォルト値</returns>
        static int GetElementIntValue(XElement vParent, string vElementName, int vDefaultValue = 0) {
            var wElementValue = GetElementValue(vParent, vElementName);
            return int.TryParse(wElementValue, out var wIntValue) ? wIntValue : vDefaultValue;
        }
        /// <summary>
        /// 要素の値がintに変換可能かチェックする
        /// </summary>
        /// <param name="vParent">親要素</param>
        /// <param name="vElementName">要素名</param>
        /// <param name="vIntValue">変換後の値</param>
        /// <returns>変換可能かどうか</returns>
        static bool TryGetElementIntValue(XElement vParent, string vElementName, out int vIntValue) {
            var wElementValue = GetElementValue(vParent, vElementName);
            return int.TryParse(wElementValue, out vIntValue);
        }
    }
}
