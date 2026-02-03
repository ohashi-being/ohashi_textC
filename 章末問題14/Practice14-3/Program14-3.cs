using System;
using System.Configuration;
using System.Linq;

/* 問題14.3
本文で示したmyAppSettings要素に以下のセクションを追加し、プログラムから参照できるようにしてください。
<CalendarOption StringFormat="yyyy年MM月dd日(ddd)"
                Minimum="1900/1/1"
                Maximum="2100/12/31"
                MondayIsFirstDay="True" />  
*/

namespace Practice14_3 {
    internal class Program {
        static void Main(string[] args) {
            var wMyAppSettings = ConfigurationManager.GetSection("myAppSettings") as MyAppSettings;
            if (wMyAppSettings != null) {
                var wCalendarOption = wMyAppSettings.CalendarOption;

                var wLabels = new[] { "StringFormat", "Minimum", "Maximum", "MondayIsFirstDay" };
                int wWidth = wLabels.Max(x => x.Length);

                Console.WriteLine(
                    $"=== Calendar Option ==={Environment.NewLine}" +
                    $"{"StringFormat".PadRight(wWidth)} : {wCalendarOption.StringFormat}{Environment.NewLine}" +
                    $"{"Minimum".PadRight(wWidth)} : {wCalendarOption.Minimum}{Environment.NewLine}" +
                    $"{"Maximum".PadRight(wWidth)} : {wCalendarOption.Maximum}{Environment.NewLine}" +
                    $"{"MondayIsFirstDay".PadRight(wWidth)} : {wCalendarOption.MondayIsFirstDay}");
            } else {
                Console.WriteLine("myAppSettingsセクションが見つかりません。");
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
