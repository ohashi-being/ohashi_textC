using System.IO;

namespace Practice17_3 {
    /// <summary>
    /// テキストファイルを処理するクラス
    /// </summary>
    public class TextFileProcessor {

        /// <summary>
        /// テキストファイルを処理するインターフェース 
        /// </summary>
        private readonly ITextFileService Service;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vService">処理方法</param>
        public TextFileProcessor(ITextFileService vService) {
            Service = vService;
        }

        /// <summary>
        /// テキストファイルを読み込み、行単位で処理を実行する
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        public void Run(string vFilePath) {
            Service.Initialize(vFilePath);
            using (var wStreamReader = new StreamReader(vFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    var wLine = wStreamReader.ReadLine();
                    Service.Execute(wLine);
                }
            }
            Service.Terminate();
        }
    }
}
