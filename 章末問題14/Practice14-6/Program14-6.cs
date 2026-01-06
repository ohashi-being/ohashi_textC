using System;

/* 問題14.6
日本の現地時間(2020/8/10 16:32:20)から、対応する協定世界時とシンガポールの現地時間を表示するプログラムを書いてください。
*/

namespace Practice14_6 {
    class Program {
        static void Main(string[] args) {
            var wJapanTime = new DateTime(2020, 8, 10, 16, 32, 20);
            try {
                var wJapanTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
                var wSingaporeTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
                var wUtcTime = TimeZoneInfo.ConvertTimeToUtc(wJapanTime, wJapanTimeZone);
                var wSingaporeTime = TimeZoneInfo.ConvertTimeFromUtc(wUtcTime, wSingaporeTimeZone);
                DisplayTimeResults(wJapanTime, wUtcTime, wSingaporeTime, wJapanTimeZone, wSingaporeTimeZone);
            } catch (TimeZoneNotFoundException ex) {
                Console.WriteLine($"タイムゾーンエラー: {ex.Message}");
            } catch (Exception ex) {
                Console.WriteLine($"予期しないエラー: {ex.Message}");
            }
            Console.WriteLine("Enterキーを押して終了...");
            Console.ReadLine();
        }
        /// <summary>
        /// 時刻変換結果を表示する
        /// </summary>
        /// <param name="vJapanTime">日本時間</param>
        /// <param name="vUtcTime">UTC時間</param>
        /// <param name="vSingaporeTime">シンガポール時間</param>
        /// <param name="vJapanTimeZone">日本のタイムゾーン</param>
        /// <param name="vSingaporeTimeZone">シンガポールのタイムゾーン</param>
        static void DisplayTimeResults(DateTime vJapanTime, DateTime vUtcTime, DateTime vSingaporeTime,
            TimeZoneInfo vJapanTimeZone, TimeZoneInfo vSingaporeTimeZone) {
            Console.WriteLine($"基準時刻（日本時間）: {vJapanTime:yyyy/MM/dd HH:mm:ss}");
            Console.WriteLine($@"
--- 変換結果 ---
日本時間（JST）    : {vJapanTime:yyyy/MM/dd HH:mm:ss}
協定世界時（UTC）  : {vUtcTime:yyyy/MM/dd HH:mm:ss}
シンガポール時間   : {vSingaporeTime:yyyy/MM/dd HH:mm:ss}

--- タイムゾーン情報 ---
日本        : UTC{GetUtcOffsetString(vJapanTimeZone.GetUtcOffset(vJapanTime))}
シンガポール : UTC{GetUtcOffsetString(vSingaporeTimeZone.GetUtcOffset(vUtcTime))}
");
        }
        /// <summary>
        /// UTCオフセットを文字列形式で取得する
        /// </summary>
        /// <param name="vOffset">タイムゾーンオフセット</param>
        /// <returns>+09:00 形式の文字列</returns>
        static string GetUtcOffsetString(TimeSpan vOffset) {
            string wSign = vOffset >= TimeSpan.Zero ? "+" : "-";
            TimeSpan wAbsOffset = vOffset.Duration();
            return $"{wSign}{wAbsOffset.Hours:D2}:{wAbsOffset.Minutes:D2}";
        }
    }
}
