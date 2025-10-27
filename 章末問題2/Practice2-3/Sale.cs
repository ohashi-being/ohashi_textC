namespace Practice2_3 {
    /// <summary>
    /// 売り上げのプロパティを持つクラス
    /// </summary>
    public class Sale {
        /// <summary>
        /// 店舗名
        /// </summary>
        public string ShopName { get; }
        /// <summary>
        /// 商品カテゴリ
        /// </summary>
        public string ProductCategory { get; }
        /// <summary>
        /// 売上高
        /// </summary>
        public int Amount { get; }
        /// <summary>
        /// 商品情報を入力するコンストラクタ
        /// </summary>
        /// <param name="vShopName">店舗名</param>
        /// <param name="vProdecutCategory">商品カテゴリ</param>
        /// <param name="vAmount">売上高</param>
        public Sale(string vShopName, string vProdecutCategory, int vAmount) {
            this.ShopName = vShopName;
            this.ProductCategory = vProdecutCategory;
            this.Amount = vAmount;
        }
    }
}