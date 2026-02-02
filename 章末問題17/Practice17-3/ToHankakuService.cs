using System;
using System.Text.RegularExpressions;

namespace Practice17_3 {
    /// <summary>
    /// 全角数字を半角数字に変換するクラス
    /// </summary>
    public class ToHankakuService : ITextFileService {
        /// <summary>
        ///  変換した全角数字の総数
        /// </summary>
        private int FTotalReplacedChar;

        /// <summary>
        /// 変換カウンターの初期化
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        public void Initialize(string vFilePath) {
            FTotalReplacedChar = 0;
        }

        /// <summary>
        ///  全角数字を半角数字に置換して出力する
        /// </summary>
        /// <param name="vLine">処理する行の文字列</param>
        public void Execute(string vLine) {
            string wResult = Regex.Replace(vLine, "[０-９]", x => {
                FTotalReplacedChar++;
                char wZenkaku = x.Value[0];
                char wHankaku = (char)('0' + (wZenkaku - '０'));
                return wHankaku.ToString();
            });

            Console.WriteLine(wResult);
        }

        /// <summary>
        /// 変換結果のまとめを表示する
        /// </summary>
        public void Terminate() {
            if (FTotalReplacedChar == 0) {
                Console.WriteLine($"{Environment.NewLine}全角数字は見つかりませんでした。");
                return;
            }
            Console.WriteLine();
            Console.WriteLine($"{FTotalReplacedChar}文字を変換しました。");
        }
    }
}
