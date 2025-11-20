using System;
using System.Globalization;

/* 問題8.1
現在の日時を以下のような3種類の書式でコンソールに出力してください。
yyyy/M/dd HH:mm
yyyy年MM月dd日 HH時mm分ss秒
ggyy年 M月dd日(ddd)

*/

namespace Practice8_1 {
    internal class Program {
        static void Main(string[] args) {
            var wToday = DateTime.Now;
            Console.WriteLine(wToday.ToString("yyyy/M/dd HH:mm"));
            Console.WriteLine(wToday.ToString("yyyy年MM月dd日 HH時mm分ss秒"));
            var wJapanInfo = new CultureInfo("ja-JP");
            wJapanInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            Console.WriteLine($"{wToday.ToString("ggyy年", wJapanInfo)}{wToday.Month.ToString().PadLeft(2, ' ')}月{wToday.ToString("dd日(ddd)")}");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
