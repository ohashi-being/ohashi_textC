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
    class Program {
        static void Main(string[] args) {
            var wAuthorInfo = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var wEnglishLabelToJapanese = new Dictionary<string, string> {
                { "Novelist" , "作家　" },
                { "BestWork" , "代表作" },
                { "Born" , "誕生年" }
            };
            foreach (var wInfo in wAuthorInfo.Split(';').Select(x => x.Split('='))) {
                if (wEnglishLabelToJapanese.TryGetValue(wInfo[0], out var wJapaneseLabel)) Console.WriteLine($"{wJapaneseLabel}：{wInfo[1]}");
            }
        }
    }
}