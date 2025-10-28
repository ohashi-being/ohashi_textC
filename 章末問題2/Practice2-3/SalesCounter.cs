using System.Collections.Generic;
using System.IO;

namespace Practice2_3 {
    /// <summary>
    /// 売り上げの集計を行うクラス
    /// </summary>
    public class SalesCounter {
        /// <summary>
        /// データを受け取るリスト
        /// </summary>
        private List<Sale> FSales;
        /// <summary>
        /// リストにデータを受け取るコンストラクタ
        /// </summary>
        /// <param name="vFilePath">ファイルパス</param>
        public SalesCounter(string vFilePath) {
            this.FSales = ReadSales(vFilePath);
        }
        /// <summary>
        /// 売り上げデータをファイルから読み取り、List<Sale>に格納する
        /// </summary>
        /// <param name="vFile">データファイル</param>
        /// <returns>売り上げのデータ</returns>
        private static List<Sale> ReadSales(string vFile) {
            var wSales = new List<Sale>();
            foreach (string wLine in File.ReadLines(vFile)) {
                string[] wItems = wLine.Split(',');
                int.TryParse(wItems[2], out int wAmounts);
                var wSale = new Sale(
                        wItems[0],
                        wItems[1],
                        wAmounts
                        );
                 wSales.Add(wSale);
            }
            return wSales;
        }
        /// <summary>
        /// カテゴリー別の売上を集計する
        /// </summary>
        /// <returns>カテゴリーごとの売り上げ</returns>
        public Dictionary<string, int> GetCategorySales() {
            var wCategorySales = new Dictionary<string, int>();
            foreach (var wSale in this.FSales) {
                wCategorySales.TryGetValue(wSale.ProductCategory, out int wCurrentAmount);
                wCategorySales[wSale.ProductCategory] = wCurrentAmount + wSale.Amount;
            }
            return wCategorySales;
        }
    }
}
