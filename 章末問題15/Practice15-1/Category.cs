namespace Practice15_1 {
    public class Category {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// カテゴリー名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vId">ID</param>
        /// <param name="vName">カテゴリー名</param>
        public Category(int vId, string vName) {
            this.Id = vId;
            this.Name = vName;
        }
        public override string ToString() {
            return $"Id:{this.Id}, カテゴリ名:{this.Name}";
        }
    }
}
