namespace Practice17_2 {
    /// <summary>
    /// ヤード変換用のクラス
    /// </summary>
    class YardConverter : ConverterBase {
        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio => 0.9144;

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName => "ヤード";

        /// <summary>
        /// ユーザーが入力可能なキーワードの配列
        /// </summary>
        public override string[] UnitKeyWords => new string[] { "yard" };
    }
}