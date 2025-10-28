/* 問題3-2
 * 以下のリストが定義してあります。
 * var wNames = new List<string> { "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong"};

 * このリストに対して、ラムダ式を使用して、次のコードを書いてください。
 * 
 * 1.コンソールから入力した都市名が何番目に格納されているかList<T>のFindIndexメソッドを使用して調べ、結果を表示してください。
 *   見つからなかったら-1を表示してください。
 *   また、コンソールからの入力にはConsole.ReadLineメソッドを使用してください。
 *   
 * 2.LINQのCountメソッドを使い、小文字の'o'が含まれる都市名の数を調べ、結果を表示してください。
 * 
 * 3.LINQのWhereメソッドを使用して、小文字の"o"が含まれる都市名を列挙し、結果を表示してください。
 * 
 * 4.LINQのWhereメソッドとSelectメソッドを使い、"B"で始まる都市名の文字数を列挙し、結果を表示してください。
 *   都市名を表示する必要はありません*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Practice3_2 {
    internal class Program {
        static void Main(string[] args) {
            var wNames = new List<string> { "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong" };
            Console.WriteLine("--------解答1-------");
            FindCity(wNames);
            Console.WriteLine("--------解答2-------");
            CountContainingString(wNames, "o");
            Console.WriteLine("--------解答3-------");
            ShowContainingString(wNames, "o");
            Console.WriteLine("--------解答4-------");
            ShowStartingString(wNames, "B");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }

        // 1の解答
        /// <summary>
        /// コンソールに入力された都市名がリストの何番目に格納されているかを出力する
        /// </summary>
        /// <param name="vNames">都市名のリスト</param>
        static void FindCity(List<string> vNames) {
            Console.Write("都市名を入力してください:");
            string wInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(wInput)) {
                Console.WriteLine("都市名が入力されていません。");
                return;
            }
            int wIndex = vNames.FindIndex(name => name.Equals(wInput, StringComparison.OrdinalIgnoreCase));
            if (wIndex == -1)
                Console.WriteLine("見つかりませんでした");
            else
                Console.WriteLine($"{wIndex} 番目に格納されています");
        }
        // 2の解答
        /// <summary>
        /// 指定の文字が含まれる都市名の数を出力する
        /// </summary>
        /// <param name="vNames">都市名のリスト</param>
        /// <param name="wSearchText">調べたい文字</param>
        static void CountContainingString(List<string> vNames, string wSearchText) {
            if (vNames == null || wSearchText == null) {
                Console.WriteLine("無効な引数です。");
                return;
            }
            int wCount = vNames.Count(name => name.Contains(wSearchText));
            Console.WriteLine($"{wSearchText} が含まれる都市名の数は {wCount} つ");
        }
        // 3の解答
        /// <summary>
        /// 指定の文字が含まれる都市名を列挙する
        /// </summary>
        /// <param name="vNames">都市名のリスト</param>
        /// <param name="wSearchText">調べたい文字</param>
        static void ShowContainingString(List<string> vNames, string wSearchText) {
            if (vNames == null || wSearchText == null) {
                Console.WriteLine("無効な引数です。");
                return;
            }
            var wNames = vNames.Where(name => name.Contains(wSearchText));
            if (!wNames.Any()) {
                Console.WriteLine("見つかりませんでした");
                return ;
            }
            foreach (var wName in wNames) {
               Console.WriteLine(wName);
            }
        }
        // 4の解答
        /// <summary>
        /// 指定の文字で始まる都市名の文字数を列挙する
        /// </summary>
        /// <param name="vNames">都市名のリスト</param>
        /// <param name="vStart">一番目の文字</param>
        static void ShowStartingString(List<string> vNames, string vStart) {
            if (vNames == null || vStart == null) {
                Console.WriteLine("無効な引数です。");
                return;
            }
            var wLengths = vNames.Where(name => name.StartsWith(vStart)).Select(name => name.Length);
            if (!wLengths.Any()) {
                Console.WriteLine("見つかりませんでした");
                return;
            }
            foreach (var wLength in wLengths) {
                Console.WriteLine(wLength);
            }
        }
    }
}
