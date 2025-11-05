using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 問題5.4
 * "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886"という文字列から
 * 以下の出力を得るコンソールアプリケーションを作成してください。
 * 
 * 作家　：谷崎潤一郎
 * 代表作：春琴抄
 * 誕生年：1886
 */

namespace Practice5_4 {
    internal class Program {
        static void Main(string[] args) {
            var wTexts = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var wStrings = wTexts.Split(';').Select(x => x.Split('=')[1]).ToArray();
            var wLabels = new string[] { "作家　", "代表作", "誕生年" };
            for (int i = 0; i < wStrings.Length; i++) {
                Console.WriteLine($"{wLabels[i]}：{wStrings[i]}");
            }
        }
    }
}
