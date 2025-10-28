/* 問題3-1
 * 以下のリストが定義してあります。
 * var wNumbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

 * このリストに対して、ラムダ式を使用して、次のコードを書いてください。
 * 
 * 1.List<T>のExistsメソッドを使用して、8か9で割り切れる数があるかどうかを調べ、
 *   結果を表示してください。
 *   
 * 2.List<T>のForEachメソッドを使用して、各要素を2.0で割った値を表示してください。
 * 
 * 3.LINQのWhereメソッドを使用して、50以上の要素を列挙し、結果を表示してください。
 * 
 * 4.LINQのSelectメソッドを使用して、各要素を2倍し、その結果をList<int>に格納してください。
 *   その後、List<int>の要素をすべて表示してください。*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice3_1 {
    internal class Program {
        static void Main(string[] args) {
            var wNumbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };
            Console.WriteLine("--------解答1-------");
            CheckDivision(wNumbers, 8, 9);
            Console.WriteLine("--------解答2-------");
            DivideNumber(wNumbers, 2.0);
            Console.WriteLine("--------解答3-------");
            ShowOver(wNumbers, 50);
            Console.WriteLine("--------解答4-------");
            ShowList(wNumbers);
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }

        // 1の解答
        /// <summary>
        /// 入力した2つの数で割り切れる数があるかどうかを調べる
        /// </summary>
        /// <param name="vNumbers">数字のリスト</param>
        /// <param name="vFirst">割れてほしい1つ目の数字</param>
        /// <param name="vSecond">割れてほしい2つ目の数字</param>
        static void CheckDivision(List<int> vNumbers, int vFirst, int vSecond) {
            bool wExist = vNumbers.Exists(n => n % vFirst == 0 || n % vSecond == 0);
            if (wExist)
                Console.WriteLine($"{vFirst} か {vSecond}で割り切れる数がある ");
            else
                Console.WriteLine($"{vFirst} か {vSecond}で割り切れる数がない ");
        }

        // 2の解答
        /// <summary>
        /// 入力した数で各要素を割った値を表示する
        /// </summary>
        /// <param name="vNumbers">数字のリスト</param>
        /// <param name="vDivisor">割りたい数</param>
        static void DivideNumber(List<int> vNumbers, double vDivisor) {
            if (vDivisor == 0) {
                Console.WriteLine("0で割ることはできません");
                return;
            }
            vNumbers.ForEach(n => Console.WriteLine(n / vDivisor));
        }

        // 3の解答
        /// <summary>
        /// 入力した数以上の要素を列挙する
        /// </summary>
        /// <param name="vNumbers">数字のリスト</param>
        /// <param name="vOver">基準となる数</param>
        static void ShowOver(List<int> vNumbers, int vOver) {
            var wOver = vNumbers.Where(n => n >= vOver);
            foreach (var wNumber in wOver) {
                Console.WriteLine(wNumber);
            }
        }

        // 4の解答
        /// <summary>
        /// 値を2倍にして 表示する
        /// </summary>
        /// <param name="vNumbers">数字のリスト</param>
        /// <returns></returns>
        static List<int> DoubleNumbers(List<int> vNumbers) => vNumbers.Select(n => n * 2).ToList();
        /// <summary>
        /// 入力したリストの要素2倍して表示する
        /// </summary>
        /// <param name="vNumbers"></param>
        static void ShowList(List<int> vNumbers) {
            List<int> wNumbers = DoubleNumbers(vNumbers);
            wNumbers.ForEach(n => Console.WriteLine(n));
        }
    }
}
