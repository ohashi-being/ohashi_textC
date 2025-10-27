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
            string[] wLines = File.ReadAllLines(vFile);
            foreach (string wLine in wLines) {
                string[] wItems = wLine.Split(',');
                var wSale = new Sale(
                    wItems[0],
                    wItems[1],
                    int.Parse(wItems[2])
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
                if (wCategorySales.ContainsKey(wSale.ProductCategory)) {
                    wCategorySales[wSale.ProductCategory] += wSale.Amount;
                } else {
                    wCategorySales[wSale.ProductCategory] = wSale.Amount;
                }
            }
            return wCategorySales;
        }
    }
}
