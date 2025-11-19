using System;
/* 問題7.2
「7.3:ディクショナリを使ったサンプルプログラム」で作成したプログラムに、以下の機能を追加してください。

1.ディクショナリに登録されている用語の数を返すCountプロパティをAbbreviationsクラスに追加してください。

2.省略語を引数に受け取るRemoveメソッドをAbbreviationsクラスに追加してください。
  要素が見つからない場合はfalseを、削除できた場合はtrueを返してください。

3.CountプロパティとRemoveメソッドを利用するコードを書いてください。

4.3文字の小略語だけを取り出し、以下の形式でコンソールに出力するコードを書いてください。
  必要ならAbbreviationsクラスに新たなメソッドを追加してください。
ILO=国際労働期間
IMF=国際通貨基金
  ︙

*/
namespace Practice7_2 {
    internal class Program {
        static void Main(string[] args) {
            var wAbbreviations = new Abbreviations();
            Console.WriteLine("----------解答1----------");
            Console.WriteLine(wAbbreviations.Count);
            Console.WriteLine("----------解答2----------");
            Console.WriteLine(wAbbreviations.Remove("IMF"));
            Console.WriteLine("----------解答4----------");
            wAbbreviations.ShowAbbreviationsByLength(3);
        }
    }
}
