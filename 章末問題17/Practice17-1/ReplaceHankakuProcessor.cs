using System;
using System.Text.RegularExpressions;
using TextFileProcessor;

namespace Practice17_1 {
    /// <summary>
    /// 全角数字を半角数字に置換するクラス
    /// </summary>
    class ReplaceHankakuProcessor : TextProcessor {
        /// <summary>
        ///  変換した全角数字の総数
        /// </summary>
        private int FTotalReplacedChar;

        /// <summary>
        /// 変換カウンターの初期化
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        protected override void Initialize(string vFilePath) {
            FTotalReplacedChar = 0;
        }

        /// <summary>
        ///  全角数字を半角数字に置換して出力する
        /// </summary>
        /// <param name="vLine">処理する行の文字列</param>
        protected override void Execute(string vLine) {
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
        protected override void Terminate() {
            string wMassage =
                FTotalReplacedChar == 0
                ? $"全角数字は見つかりませんでした。"
                : $"{FTotalReplacedChar}文字を変換しました。";
            Console.WriteLine($"{Environment.NewLine}{wMassage}");
        }
    }
}
