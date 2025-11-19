using System;
using System.Collections.Generic;
using System.Linq;
/* 問題7.1
"Cozy lummox gives smart squid who asks for job pen"という文字列があります。
この文字列に対して、以下のコードを書いてください。

1.各アルファベット文字（空白などアルファベット以外は除外）が何文字ずつ現れるかカウントするプログラムを書いてください。
この時に、必ずディクショナリクラスを使ってください。
大文字/小文字の区別はしないでください。
以下の形式で出力してください。

'A':2
'B':1
  ︙

2.上記プログラムを、SortedDictionary<Tkey,TValue>を使って書き換えてください。
*/
namespace Practice7_1 {
    internal class Program {
        static void Main(string[] args) {
            var wString = "Cozy lummox gives smart squid who asks for job pen";
            Console.WriteLine("----------解答1----------");
            var wDict = new Dictionary<char, int>();
            ShowDictionary(CountAlphabetFrequencyDict(wString, wDict).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
            Console.WriteLine("----------解答2----------");
            ShowDictionary(CountAlphabetFrequencyDict(wString, new SortedDictionary<char, int>()));
        }
        /// <summary>
        /// 各アルファベットが何文字含まれるかカウントする
        /// </summary>
        /// <param name="vString">出現頻度を数える対象の文字列</param>
        /// /// <returns>アルファベットとその出現回数のディクショナリ</returns>
        static IDictionary<char, int> CountAlphabetFrequencyDict(string vString, IDictionary<char, int> vDict) {
            foreach (var wWord in vString) {
                var wUpperWord = char.ToUpper(wWord);
                if ('A' <= wUpperWord && wUpperWord <= 'Z') {
                    if (vDict.TryGetValue(wUpperWord, out var wCount))
                        vDict[wUpperWord] = wCount + 1;
                    else
                        vDict[wUpperWord] = 1;
                }
            }
            return vDict;
        }
        /// <summary>
        /// ディクショナリのキーと値を表示する
        /// </summary>
        /// <param name="vFrequencyDict">アルファベットとその出現回数のディクショナリ</param>
        static void ShowDictionary(IEnumerable<KeyValuePair<char, int>> vFrequencyDict) {
            foreach (var wWord in vFrequencyDict) {
                Console.WriteLine($"'{wWord.Key}':{wWord.Value}");
            }
        }
    }
}
