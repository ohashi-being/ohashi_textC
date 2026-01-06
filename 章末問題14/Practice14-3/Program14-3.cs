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
            var myAppSettings = ConfigurationManager.GetSection("myAppSettings") as MyAppSettings;
            if (myAppSettings != null) {
                var calendarOption = myAppSettings.CalenderOption;
                Console.WriteLine("=== Calendar Option ===");
                Console.WriteLine($"StringFormat     : {calendarOption.StringFormat}");
                Console.WriteLine($"Minimum          : {calendarOption.Minimum}");
                Console.WriteLine($"Maximum          : {calendarOption.Maximum}");
                Console.WriteLine($"MondayIsFirstDay : {calendarOption.MondayIsFirstDay}");
            } else {
                Console.WriteLine("myAppSettingsセクションが見つかりません。");
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
