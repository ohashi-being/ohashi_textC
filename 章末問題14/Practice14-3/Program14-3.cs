using System;
using System.Configuration;

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
                var wCalendarOption = wMyAppSettings.CalenderOption;
                Console.WriteLine("=== Calendar Option ===");
                Console.WriteLine($"StringFormat     : {wCalendarOption.StringFormat}");
                Console.WriteLine($"Minimum          : {wCalendarOption.Minimum}");
                Console.WriteLine($"Maximum          : {wCalendarOption.Maximum}");
                Console.WriteLine($"MondayIsFirstDay : {wCalendarOption.MondayIsFirstDay}");
            } else {
                Console.WriteLine("myAppSettingsセクションが見つかりません。");
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
