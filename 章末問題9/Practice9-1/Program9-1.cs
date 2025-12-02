using System;
using System.IO;
using System.Linq;
using System.Reflection;
/* 問題9.1
以下の問題を解いてください。

1.指定したC#のソースファイルを読み込み、キーワード"class"が含まれている行数をカウントするコンソールアプリケーションCountClassを作成してください。
  この時、StreamReaderクラスを使い、１行ずつ読み込む処理にしてください。
  なお、以下の2点を前提としてかまいません。
  ・classキーワードの前後には、必ず空白文字がある
  ・リテラル文字列やコメントの中には、"class"という単語は含まれていない

2.このプログラムを、File.ReadAllLinesメソッドを利用して書き換えてください。    

3.このプログラムを、File.ReadLinesメソッドを利用して書き換えてください。    
*/
namespace Practice9_1 {
    class Program {
        static void Main(string[] args) {
            var wFilePath = @"..\..\9-1.cs";
            var wTargetString = " class ";
            ShowCount(wTargetString, CountClassWithStreamReader(wFilePath, wTargetString));
            ShowCount(wTargetString, CountClassWithReadAllLines(wFilePath, wTargetString));
            ShowCount(wTargetString, CountClassWithReadLines(wFilePath, wTargetString));
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        ///StreamReaderクラスを使用し、ファイルを読み込み、指定した文字列が含まれる行数をカウントします。
        /// </summary>
        /// <param name="vFilePath">読み込み対象のファイルパス</param>
        /// <param name="vTargetString">検索対象の文字列</param>
        private static int CountClassWithStreamReader(string vFilePath, string vTargetString) {
            if (!File.Exists(vFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {vFilePath}");
            var wStringCount = 0;
            using (var wStreamReader = new StreamReader(vFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    var wLine = wStreamReader.ReadLine();
                    if (wLine.Contains($"{vTargetString}")) wStringCount++;
                }
            }
            return wStringCount;
        }
        /// <summary>
        /// File.ReadAllLinesメソッドを使用し、ファイルを読み込み、指定した文字列が含まれる行数をカウントします。
        /// </summary>
        /// <param name="vFilePath">読み込み対象のファイルパス</param>
        /// <param name="vTargetString">検索対象の文字列</param>
        private static int CountClassWithReadAllLines(string vFilePath, string vTargetString) {
            if (!File.Exists(vFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {vFilePath}");
            return File.ReadAllLines(vFilePath).Count(x => x.Contains($"{vTargetString}"));
        }
        /// <summary>
        /// File.ReadLinesメソッドを使用し、ファイルを読み込み、指定した文字列が含まれる行数をカウントします。
        /// </summary>
        /// <param name="vFilePath">読み込み対象のファイルパス</param>
        /// <param name="vTargetString">検索対象の文字列</param>
        private static int CountClassWithReadLines(string vFilePath, string vTargetString) {
            if (!File.Exists(vFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {vFilePath}");
            return File.ReadLines(vFilePath).Count(x => x.Contains($"{vTargetString}"));
        }
        /// <summary>
        /// 対象となる文字列が何回カウントされたかを表示する。
        /// </summary>
        /// <param name="vTargetString">検索対象の文字列</param>
        /// <param name="vCount">対象となる文字列が何回カウントされたか</param>
        private static void ShowCount(string vTargetString, int vCount) => Console.WriteLine($"{vTargetString}は{vCount}つあります");
    }
}