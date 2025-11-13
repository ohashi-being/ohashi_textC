using System;
using Microsoft.VisualBasic;

/* 問題5.2
コンソールから入力した数字文字列をint型に変換した後、カンマ付きの数字文字列に変換してください。
入力した文字列は、int.TryParseメソッドで数値に変換してください。
 */

namespace Practice5_2 {
    class Program {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("カンマ付きに変換します、9桁までの整数を入力してください（例：12345）：");
                var wInput = Strings.StrConv(Console.ReadLine(), VbStrConv.Narrow, 0);
                if (wInput.Length > 9) {
                    Console.WriteLine("9桁までの整数を入力してください。");
                    continue;
                }
                if (int.TryParse(wInput, out int wNumber)) {
                    Console.WriteLine($"入力された数字（カンマ付き）: {wNumber:N0}");
                    break;
                }
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}