namespace Practice17_3 {
    /// <summary>
    /// テキストファイル処理サービスのインターフェース
    /// </summary>
    public interface ITextFileService {

        /// <summary>
        /// ファイルを読み込む前の初期化処理
        /// </summary>
        /// <param name="vFilePath">読み込むファイルパス</param>
        void Initialize(string vFilePath);

        /// <summary>
        /// ファイルの各行を処理する
        /// </summary>
        /// <param name="vLine">読み込んだ行</param>
        void Execute(string vLine);

        /// <summary>
        /// ファイルの読み込みと処理が完了した後の終了処理
        /// </summary>
        void Terminate();
    }
}
