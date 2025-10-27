/* 問題3-2
 * 以下のリストが定義してあります。
 * var names = new List<string> { "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong"};

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

namespace Practice3_2 {
    internal class Program {
        static void Main(string[] args) {
            var wNames = new List<string> { "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong" };
            Console.WriteLine("--------解答1-------");
            FindCity(wNames);
            Console.WriteLine("--------解答2-------");
            CountContainingCharacter(wNames, "o");
            Console.WriteLine("--------解答3-------");
            ShowContainingCharacter(wNames, "o");
            Console.WriteLine("--------解答4-------");
            ShowStartingCharacter(wNames, "B");
        }

        // 1の解答
        /// <summary>
        /// コンソールに入力された都市名がリストの何番目に格納されているかを調べる
        /// </summary>
        /// <param name="vNames">都市名のリスト</param>
        static void FindCity(List<string> vNames) {
            Console.Write("都市名を入力してください:");
            string wInput = Console.ReadLine();
            int wIndex = vNames.FindIndex(name => name == wInput);
            if (wIndex == -1)
                Console.WriteLine("見つかりませんでした");
            else
                Console.WriteLine($"{wIndex} 番目に格納されています");
        }

        // 2の解答
        /// <summary>
        /// 入力した文字が含まれる都市名の数を調べる
        /// </summary>
        /// <param name="vNames">都市名のリスト</param>
        /// <param name="vKomoji">調べたい文字</param>
        static void CountContainingCharacter(List<string> vNames, string vKomoji) {
            int wCount = vNames.Count(name => name.Contains(vKomoji));
            Console.WriteLine($"{vKomoji} が含まれる都市名の数は {wCount} つ");
        }

        // 3の解答
        /// <summary>
        /// 入力した文字が含まれる都市名を列挙する
        /// </summary>
        /// <param name="vNames">都市名のリスト</param>
        /// <param name="vKomoji">調べたい文字</param>
        static void ShowContainingCharacter(List<string> vNames, string vKomoji) {
            var wNames = vNames.Where(name => name.Contains(vKomoji));
            foreach (var wName in wNames) {
                Console.WriteLine(wName);
            }
        }

        // 4の解答
        /// <summary>
        /// 入力した文字で始まる都市名の文字数を列挙する
        /// </summary>
        /// <param name="vNames">都市名のリスト</param>
        /// <param name="vStart">一番目の文字</param>
        static void ShowStartingCharacter(List<string> vNames, string vStart) {
            var wLengths = vNames.Where(name => name.StartsWith(vStart))
                                .Select(name => name.Length);
            foreach (var wLength in wLengths) {
                Console.WriteLine(wLength);
            }
        }
    }
}
