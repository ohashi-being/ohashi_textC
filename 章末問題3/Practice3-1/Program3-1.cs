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
using System.Xml.Linq;

namespace Practice3_1 {
    internal class Program {
        static void Main(string[] args) {
            var wNumbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };
            Console.WriteLine("--------解答1-------");
            CheckDivision(wNumbers, 8, 9);
            Console.WriteLine("--------解答2-------");
            ShowDivideNumber(wNumbers);
            Console.WriteLine("--------解答3-------");
            ShowNumbersAboveThreshold(wNumbers);
            Console.WriteLine("--------解答4-------");
            ShowDoubleList(wNumbers);
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        // 1の解答
        /// <summary>
        /// 入力した2つの数で割り切れる数があるかどうかを調べる
        /// </summary>
        /// <param name="vNumbers">数字のリスト</param>
        /// <param name="vDivisor1">1つ目の割る数</param>
        /// <param name="vDivisor2">2つ目の割る数</param>
        static void CheckDivision(List<int> vNumbers, int vDivisor1, int vDivisor2) {
            if (vNumbers.Exists(x => x % vDivisor1 == 0 || x % vDivisor2 == 0))
                Console.WriteLine($"{vDivisor1} か {vDivisor2}で割り切れる数がある ");
            else
                Console.WriteLine($"{vDivisor1} か {vDivisor2}で割り切れる数がない ");
        }

        // 2の解答
        /// <summary>
        /// 入力した数で各要素を割った値を表示する
        /// </summary>
        /// <param name="vNumbers">数字のリスト</param>
        static void ShowDivideNumber(List<int> vNumbers) {
            Console.Write("割る数を入力してください:");
            if (!double.TryParse(Console.ReadLine(), out double wInput)) {
                Console.WriteLine("数値を入力してください。");
                return;
            }
            if (wInput == 0) {
                Console.WriteLine("0で割ることはできません");
                return;
            }
            vNumbers.ForEach(x => Console.WriteLine((double)x / wInput));
        }

        // 3の解答
        /// <summary>
        /// 入力した数以上の要素を列挙する
        /// </summary>
        /// <param name="vNumbers">数字のリスト</param>
        static void ShowNumbersAboveThreshold(List<int> vNumbers) {
            Console.Write("基準となる数を入力してください:");
            if (!int.TryParse(Console.ReadLine(), out int wThreshold)) {
                Console.WriteLine("数値を入力してください。");
                return;
            }
            var wOverThresholds = vNumbers.Where(x => x >= wThreshold);
            if (!wOverThresholds.Any()) {
                Console.WriteLine("見つかりませんでした");
                return;
            }
            foreach (var wOverThreshold in wOverThresholds) {
                Console.WriteLine(wOverThreshold);
            }
        }
        // 4の解答
        /// <summary>
        /// リストの値を2倍にしてリストに格納し、表示する
        /// </summary>
        /// <param name="vNumbers">数字のリスト</param>
        static void ShowDoubleList(List<int> vNumbers) => vNumbers.Select(x => x * 2).ToList().ForEach(x => Console.WriteLine(x));
    }
}
