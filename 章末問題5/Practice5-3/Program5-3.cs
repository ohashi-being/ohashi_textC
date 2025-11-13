using System;
using System.Linq;
using System.Text;

/* 問題5.3
"Jackdaws love my big sphinx of quartz"という文字列があります。
この文字に対して、以下の問題を解いてください。

1.空白が何文字あるかカウントしてください。

2.文字列の中の"big"を"small"に置き換えてください。

3.単語がいくつあるかカウントしてください。

4.4文字以下の単語を列挙してください。

5.空白で区切り、配列に格納した後、StringBuilderクラスを使い文字列を連結させ、
  元の文字列と同じものを作り出してください。
  元の文字列の中には連続した空白は存在しないものとします。
 */

namespace Practice5_3 {
    class Program {
        static void Main(string[] args) {
            var wString = "Jackdaws love my big sphinx of quartz";
            // 1の解答
            Console.WriteLine("-----------------解答1-----------------");
            Console.WriteLine($"空白は{wString.Count(char.IsWhiteSpace)}つあります");
            Console.WriteLine();
            // 2の解答
            Console.WriteLine("-----------------解答2-----------------");
            Console.WriteLine($"変換前：{wString}");
            Console.WriteLine($"変換後：{wString.Replace("big", "small")}");
            Console.WriteLine();
            // 3の解答
            var wWords = wString.Split(' ');
            Console.WriteLine("-----------------解答3-----------------");
            Console.WriteLine($"単語は{wWords.Length}つあります");
            Console.WriteLine();
            // 4の解答
            Console.WriteLine("-----------------解答4-----------------");
            Console.WriteLine($"4文字以下の単語：{string.Join(",", wWords.Where(x => x.Length <= 4))}");
            Console.WriteLine();
            // 5の解答
            Console.WriteLine("-----------------解答5-----------------");
            RebuildString(wWords);

            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        // 5の解答
        /// <summary>
        /// 空白で区切り、配列に格納した後、StringBuilderクラスを使い文字列を連結させる
        /// </summary>
        /// <param name="vStringsArray">元の文章を空白で分割した文字列の配列</param>
        static void RebuildString(string[] vStringsArray) {
            var wNewString = new StringBuilder();
            for (int i = 0; i < vStringsArray.Length; i++) {
                wNewString.Append(vStringsArray[i]);
                if (i < vStringsArray.Length - 1) wNewString.Append(' ');
            }
            Console.WriteLine(wNewString);
        }
    }
}
