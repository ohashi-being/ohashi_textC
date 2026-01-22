namespace Practice15_1 {
    /// <summary>
    /// 書籍情報を表すクラス
    /// </summary>
    public class Book {
        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// カテゴリID
        /// </summary>
        public int CategoryId { get; }
        /// <summary>
        /// 価格
        /// </summary>
        public int Price { get; }
        /// <summary>
        /// 発行年
        /// </summary>
        public int PublishedYear { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">タイトル</param>
        /// <param name="vCategoryId">カテゴリID</param>
        /// <param name="vPrice">価格</param>
        /// <param name="vPublishedYear">発行年</param>
        public Book(string vTitle, int vCategoryId, int vPrice, int vPublishedYear) {
            this.Title = vTitle;
            this.CategoryId = vCategoryId;
            this.Price = vPrice;
            this.PublishedYear = vPublishedYear;
        }
    }
}
