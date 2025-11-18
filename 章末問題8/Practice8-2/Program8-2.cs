using System;
using System.Collections.Generic;
using System.Globalization;
/* 問題8.2
次の週の指定曜日を求めるメソッドを定義してください。

*/

namespace Practice8_2 {
    internal class Program {
        static void Main(string[] args) {
            var wToday = DateTime.Today;
            ShowNextWeekDay(wToday,"土");
        }
        /// <summary>
        /// 基準日から見て、次の週の指定曜日の日付を表示する
        /// </summary>
        /// <param name="vBaseDate">基準となる日</param>
        /// <param name="vDayOfWeekJp">求めたい曜日(漢字一字)</param>
        static void ShowNextWeekDay(DateTime vBaseDate , string vDayOfWeekJp) {
            var wJpWeek = new Dictionary<string, DayOfWeek>
        {
            {"日", DayOfWeek.Sunday},
            {"月", DayOfWeek.Monday},
            {"火", DayOfWeek.Tuesday},
            {"水", DayOfWeek.Wednesday},
            {"木", DayOfWeek.Thursday},
            {"金", DayOfWeek.Friday},
            {"土", DayOfWeek.Saturday}
        };
            if (!wJpWeek.TryGetValue(vDayOfWeekJp, out DayOfWeek vDayOfWeek)) {
                Console.WriteLine("漢字一字で入力してください。（例：月,火,水）");
                return;
            }
            var wDayDif = vDayOfWeek - vBaseDate.DayOfWeek;
            var wNextweekDate = vBaseDate.AddDays(wDayDif + 7);
            var wJapanInfo = new CultureInfo("ja-JP");
            wJapanInfo.DateTimeFormat.Calendar = new JapaneseCalendar();
            Console.WriteLine($"次の週の{wJapanInfo.DateTimeFormat.GetShortestDayName(vDayOfWeek)}曜日は{wNextweekDate.Month}月{wNextweekDate.Day}日");
        }
    }
}
