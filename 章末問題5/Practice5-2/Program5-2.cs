using System;

/* 問題5.2
コンソールから入力した数字文字列をint型に変換した後、カンマ付きの数字文字列に変換してください。
入力した文字列は、int.TryParseメソッドで数値に変換してください。
 */

namespace Practice5_2 {
    internal class Program {
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("カンマ付きに変換するための整数を入力してください（例：12345）：");
                if (int.TryParse(Console.ReadLine(), out int wNumber)) {
                    Console.WriteLine($"入力された数字（カンマ付き）: {wNumber:N0}");
                    break;
                } else {
                    Console.WriteLine("10桁までの半角整数を入力してください");
                }
            }
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}