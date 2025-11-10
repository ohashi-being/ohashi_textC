using System;
using System.Collections.Generic;
using System.Linq;

/* 問題5.4
"Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886"という文字列から
以下の出力を得るコンソールアプリケーションを作成してください。

作家　：谷崎潤一郎
代表作：春琴抄
誕生年：1886
 */

namespace Practice5_4 {
    internal class Program {
        static void Main(string[] args) {
            var wAuthorInfo = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var wStrings = wAuthorInfo.Split(';').Select(x => x.Split('=')[1]);
            var wAuthorDict = new Dictionary<string, string> {
                { "谷崎潤一郎" , "作家　" },
                { "春琴抄" , "代表作" },
                { "1886" , "誕生年" }
            };
            foreach (var wString in wStrings) {
                Console.WriteLine($"{wAuthorDict[wString]}:{wString}");
            }
        }
    }
}