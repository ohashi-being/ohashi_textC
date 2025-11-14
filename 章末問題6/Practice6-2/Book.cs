namespace Practice6_2 {
    /// <summary>
    /// 書籍の情報を設定するクラス
    /// </summary>
    internal class Book {
        /// <summary>
        /// 書籍のタイトル
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// 書籍の価格
        /// </summary>
        public int Price { get; }
        /// <summary>
        /// 書籍のページ数
        /// </summary>
        public int Pages { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">書籍のタイトル</param>
        /// <param name="vPrice">書籍の価格</param>
        /// <param name="vPages">書籍のページ数</param>
        public Book(string vTitle, int vPrice, int vPages) {
            this.Title = vTitle;
            this.Price = vPrice;
            this.Pages = vPages;
        }
    }
}
