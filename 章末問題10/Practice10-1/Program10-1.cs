using System;
using System.Text.RegularExpressions;
/* 問題10.1
指定された文字列が携帯電話の電話番号かどうかを判定するメソッドを定義してください。
電話番号はハイフンで区切られていなければなりません。
また、先頭3文字は、"090"、"080"、"070"のいずれかとします。
*/

namespace Practice10_1 {
    internal class Program {
        /// <summary>
        /// 携帯電話番号の長さ（-含む）
        /// </summary>
        private const int C_MobilePhoneNumberLength = 13;
        static void Main(string[] args) {
            string[] wPhoneNumbers = { "090-1234-5678", "080-1234-5678", "070-1234-5678", "050-1234-5678", "09012345678" };
            var wPattern = @"^0[789]0-\d{4}-\d{4}$";
            foreach (var wPhoneNumber in wPhoneNumbers) {
                if (IsMobilePhoneNumber(wPhoneNumber, wPattern)) Console.WriteLine($"{wPhoneNumber}は携帯電話番号です");
                else Console.WriteLine($"{wPhoneNumber,C_MobilePhoneNumberLength}は携帯電話番号ではありません");
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// 携帯電話の電話番号かどうかを判定する
        /// </summary>
        /// <param name="vPhoneNumber">電話番号</param>
        /// <param name="vPattern">検索パターン</param>
        /// <returns>携帯電話の電話番号かどうか</returns>
        static bool IsMobilePhoneNumber(string vPhoneNumber, string vPattern) => Regex.IsMatch(vPhoneNumber, vPattern);
    }
}
