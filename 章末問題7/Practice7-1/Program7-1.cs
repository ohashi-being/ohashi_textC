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
            ShowAlphabetFreq1(wString);
            Console.WriteLine("----------解答2----------");
            ShowAlphabetFreq2(wString);
        }
        /// <summary>
        /// 各アルファベットが何文字含まれるか表示する
        /// </summary>
        /// <param name="vString">出現頻度を数える対象の文字列</param>
        static void ShowAlphabetFreq1(string vString) {
            var wDict = new Dictionary<char, int>();
            foreach (var wWord in vString) {
                var wUpperWord = char.ToUpper(wWord);
                if ('A' <= wUpperWord && wUpperWord <= 'Z') {
                    if (wDict.ContainsKey(wUpperWord))
                        wDict[wUpperWord]++;
                    else
                        wDict[wUpperWord] = 1;
                }
            }
            foreach (var wWord in wDict.OrderBy(x => x.Key)) {
                Console.WriteLine($"'{wWord.Key}':{wWord.Value}");
            } 
        }
        /// <summary>
        /// 各アルファベットが何文字含まれるか表示する
        /// </summary>
        /// <param name="vString">出現頻度を数える対象の文字列</param>
        static void ShowAlphabetFreq2(string vString) {
            var wDict = new SortedDictionary<char, int>();
            foreach (var wWord in vString) {
                var wUpperWord = char.ToUpper(wWord);
                if ('A' <= wUpperWord && wUpperWord <= 'Z') {
                    if (wDict.ContainsKey(wUpperWord))
                        wDict[wUpperWord]++;
                    else
                        wDict[wUpperWord] = 1;
                }
            }
            foreach (var wWord in wDict) {
                Console.WriteLine($"'{wWord.Key}':{wWord.Value}");
            }
        }
    }
}
