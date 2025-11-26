using System;
using System.Collections.Generic;
using System.Globalization;
/* 問題8.2
次の週の指定曜日を求めるメソッドを定義してください。

*/

namespace Practice8_2 {
    internal class Program {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("次の週の日付を知りたい曜日を漢字一字で入力してください（例：月、火、水）:");
                var wInputDay = Console.ReadLine();
                var wResult = TryGetNextWeekDay(DateTime.Today, wInputDay);
                if (wResult.Success) {
                    Console.WriteLine($"次の週の{wInputDay}曜日は{wResult.NextDate.Month}月{wResult.NextDate.Day}日");
                    break;
                } else {
                    Console.WriteLine("入力が正しくありません。漢字一字で入力してください。");
                }
            }
        }
        /// <summary>
        /// 日本語の曜日表記をDayOfWeek列挙型に変換するためのディクショナリ
        /// </summary>
        static readonly Dictionary<string, DayOfWeek> FJapaneseWeekToDayOfWeek = new Dictionary<string, DayOfWeek>{
            {"日", DayOfWeek.Sunday},
            {"月", DayOfWeek.Monday},
            {"火", DayOfWeek.Tuesday},
            {"水", DayOfWeek.Wednesday},
            {"木", DayOfWeek.Thursday},
            {"金", DayOfWeek.Friday},
            {"土", DayOfWeek.Saturday}
        };
        /// <summary>
        /// 基準日から見て、次の週の指定曜日の日付を取得する
        /// </summary>
        /// <param name="vBaseDate">基準となる日</param>
        /// <param name="vInput">入力された日本語の曜日表記</param>
        /// <returns>変換可能か、次の週の指定曜日の日付</returns>
        static (bool Success, DateTime NextDate) TryGetNextWeekDay(DateTime vBaseDate, string vInput) {
            if (!FJapaneseWeekToDayOfWeek.TryGetValue(vInput, out var wDayOfWeek))
                return (false, default);
            var wNextweekDate = vBaseDate.AddDays(wDayOfWeek - vBaseDate.DayOfWeek + 7);
            return (true, wNextweekDate);
        }
    }
}
