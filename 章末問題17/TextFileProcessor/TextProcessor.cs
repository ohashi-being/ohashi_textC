using System.IO;

namespace TextFileProcessor {
    /// <summary>
    /// テキストを読み込み、行単位で処理を行う基底クラス
    /// </summary>
    public abstract class TextProcessor {
        /// <summary>
        /// TextProcessorを継承したクラスを指定し、ファイルを読み込んで処理を実行する
        /// </summary>
        /// <typeparam name="T">継承したクラス</typeparam>
        /// <param name="vFilePath">読み込むファイルのパス</param>
        public static void Run<T>(string vFilePath) where T : TextProcessor, new() {
            var wModel = new T();
            wModel.Process(vFilePath);
        }

        /// <summary>
        /// テキストファイルを読み込み、行単位で処理を実行する
        /// </summary>
        /// <param name="vFilePath">処理対象のファイルパス</param>
        private void Process(string vFilePath) {
            Initialize(vFilePath);
            using (var wStreamReader = new StreamReader(vFilePath)) {
                while (!wStreamReader.EndOfStream) {
                    string wLine = wStreamReader.ReadLine();
                    Execute(wLine);
                }
            }
            Terminate();
        }

        /// <summary>
        /// ファイルを読み込む前の初期化処理
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        protected virtual void Initialize(string vFilePath) { }

        /// <summary>
        /// ファイルの各行を処理する
        /// </summary>
        /// <param name="vLine">ファイルの各行</param>
        protected virtual void Execute(string vLine) { }

        /// <summary>
        /// ファイルの読み込みと処理が完了した後の終了処理
        /// </summary>
        protected virtual void Terminate() { }
    }
}
