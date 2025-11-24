using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Practice7_2 {
    /// <summary>
    /// 省略語と日本語訳を管理するクラス
    /// </summary>
    class Abbreviations {
        /// <summary>
        /// 省略語（キー）と日本語訳（値）を保持するディクショナリ
        /// </summary>
        private Dictionary<string, string> FAbbreviationToJapanese = new Dictionary<string, string>();
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Abbreviations() {
            string wFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Abbreviations.txt");
            if (!File.Exists(wFilePath)) throw new FileNotFoundException($"ファイルが存在しません: {wFilePath}");
            var wReadLines = File.ReadAllLines(wFilePath);
            this.FAbbreviationToJapanese = wReadLines.Select(x => x.Split('='))
                         .ToDictionary(x => x[0], x => x[1]);
        }
        // 以下自身で作成しました
        // 1の解答
        /// <summary>
        /// ディクショナリに格納されている省略語の総数
        /// </summary>
        public int Count => FAbbreviationToJapanese.Count;
        // 2の解答
        /// <summary>
        /// 指定した省略語のデータを削除する
        /// </summary>
        /// <param name="vRemoveAbbreviation">削除したい省略語</param>
        /// <returns>削除が成功した場合は true、見つからなかった場合は false</returns>
        public bool Remove(string vRemoveAbbreviation) {
            if (string.IsNullOrEmpty(vRemoveAbbreviation)) return false;
            return FAbbreviationToJapanese.Remove(vRemoveAbbreviation);
        }
        // 4の解答
        /// <summary>
        /// 指定した文字数の省略語のみ表示する
        /// </summary>
        /// <param name="vAbbreviationLength">調べたい文字数</param>
        public void ShowAbbreviationsByLength(int vAbbreviationLength) {
            foreach (var wAbbreviation in FAbbreviationToJapanese.Where(x => x.Key.Length == vAbbreviationLength)) {
                Console.WriteLine($"{wAbbreviation.Key}={wAbbreviation.Value}");
            }
        }
    }
}