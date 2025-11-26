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
            string wExeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string wFilePath = Path.Combine(wExeDir, "Program9-1.cs");
            if (!File.Exists(wFilePath)) {
                throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            }
            CountClassWithStreamReader(wFilePath, " class ");
            CountClassWithReadAllLines(wFilePath, " class ");
            CountClassWithReadLines(wFilePath, " class ");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        ///StreamReaderクラスを使用し、ファイルを読み込み、指定した文字列が含まれる行数をカウントします。
        /// </summary>
        /// <param name="vFilePath">読み込み対象のファイルパス</param>
        /// <param name="vString">検索対象の文字列</param>
        private static void CountClassWithStreamReader(string vFilePath, string vString) {
            var wStringCount = 0;
            using (var wStreamReader = new StreamReader(vFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    var wLine = wStreamReader.ReadLine();
                    if (wLine.Contains($"{vString}"))
                        wStringCount++;
                }
            }
            Console.WriteLine($"{vString}は{wStringCount}つあります");
        }
        /// <summary>
        /// File.ReadAllLinesメソッドを使用し、ファイルを読み込み、指定した文字列が含まれる行数をカウントします。
        /// </summary>
        /// <param name="vFilePath">読み込み対象のファイルパス</param>
        /// <param name="vString">検索対象の文字列</param>
        private static void CountClassWithReadAllLines(string vFilePath, string vString) {
            var wStringCount = File.ReadAllLines(vFilePath).Count(x => x.Contains($"{vString}"));
            Console.WriteLine($"{vString}は{wStringCount}つあります");
        }
        /// <summary>
        /// File.ReadLinesメソッドを使用し、ファイルを読み込み、指定した文字列が含まれる行数をカウントします。
        /// </summary>
        /// <param name="vFilePath">読み込み対象のファイルパス</param>
        /// <param name="vString">検索対象の文字列</param>
        private static void CountClassWithReadLines(string vFilePath, string vString) {
            var wStringCount = File.ReadLines(vFilePath).Count(x => x.Contains($"{vString}"));
            Console.WriteLine($"{vString}は{wStringCount}つあります");
        }
    }
}