namespace Practice15_1 {
    /// <summary>
    /// 書籍のカテゴリーを表すクラス
    /// </summary>
    public class Category {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// カテゴリー名
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vId">ID</param>
        /// <param name="vName">カテゴリー名</param>
        public Category(int vId, string vName) {
            this.Id = vId;
            this.Name = vName;
        }
        /// <summary>
        /// カテゴリ情報を文字列形式で返す
        /// </summary>
        /// <returns>IDとカテゴリ名を含む文字列</returns>
        public override string ToString() {
            return $"Id:{this.Id}, カテゴリ名:{this.Name}";
        }
    }
}
