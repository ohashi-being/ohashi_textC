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
    class Program {
        static void Main(string[] args) {
            var wString = "Cozy lummox gives smart squid who asks for job pen";
            Console.WriteLine("----------解答1----------");
            ShowDictionary(CountAlphabetFrequency(wString).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value));
            Console.WriteLine("----------解答2----------");
            ShowDictionary(CountAlphabetFrequency(wString, new SortedDictionary<char, int>()));
        }
        /// <summary>
        /// 各アルファベットが何文字含まれるかカウントする
        /// </summary>
        /// <param name="vString">出現頻度を数える対象の文字列</param>
        /// <param name="vDict">出現頻度の書き込み先となる辞書</param>
        /// <returns>アルファベットとその出現回数の辞書</returns>
        static IDictionary<char, int> CountAlphabetFrequency(string vString, IDictionary<char, int> vDict) {
            foreach (var wChar in vString) {
                var wUpperChar = char.ToUpper(wChar);
                if ('A' <= wUpperChar && wUpperChar <= 'Z') {
                    if (vDict.TryGetValue(wUpperChar, out var wCount))
                        vDict[wUpperChar] = wCount + 1;
                    else
                        vDict[wUpperChar] = 1;
                }
            }
            return vDict;
        }
        /// <summary>
        /// 各アルファベットが何文字含まれるかカウントする（辞書を自動生成）
        /// </summary>
        /// <param name="vString">出現頻度を数える対象の文字列</param>
        /// <returns>アルファベットとその出現回数の辞書</returns>
        static IDictionary<char, int> CountAlphabetFrequency(string vString) {
            return CountAlphabetFrequency(vString, new Dictionary<char, int>());
        }
        /// <summary>
        /// ディクショナリのキーと値を表示する
        /// </summary>
        /// <param name="vFrequencyDict">アルファベットとその出現回数のディクショナリ</param>
        static void ShowDictionary(IEnumerable<KeyValuePair<char, int>> vFrequencyDict) {
            foreach (var wChar in vFrequencyDict) {
                Console.WriteLine($"'{wChar.Key}':{wChar.Value}");
            }
        }
    }
}
