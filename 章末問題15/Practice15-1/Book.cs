namespace Practice15_1 {
    /// <summary>
    /// 書籍情報を表すクラス
    /// </summary>
    public class Book {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// カテゴリID
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 価格
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 発行年
        /// </summary>
        public int PublishedYear { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vCategoryId">カテゴリID</param>
        /// <param name="vPrice">価格</param>
        /// <param name="vPublishedYear">発行年</param>
        public Book(string vTitle,int vCategoryId, int vPrice, int vPublishedYear) {
            this.Title = vTitle;
            this.CategoryId = vCategoryId;
            this.Price = vPrice;
            this.PublishedYear = vPublishedYear;
        }
        public override string ToString() {
            return $"発行年:{this.PublishedYear},カテゴリ:{this.CategoryId},価格:{this.Price},タイトル:{this.Title}";
        }
    }
}
