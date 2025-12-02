練習用

/* 問題9.1
以下の問題を解いてください。

1.指定したC#のソースファイルを読み込み、キーワード"class"が含まれている行数をカウントするコンソールアプリケーションCountClassを作成してください。
  この時、StreamReaderクラスを使い、１行ずつ読み込む処理にしてください。
  なお、以下の2点を前提としてかまいません。
  ・classキーワードの前後には、必ず空白文字がある
  ・リテラル文字列やコメントの中には、"class"という単語は含まれていない
 
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