namespace Practice17_2 {
    /// <summary>
    /// フィート変換用のクラス
    /// </summary>
    class FeetConverter : ConverterBase {
        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio => 0.3048;

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName => "フィート";

        /// <summary>
        /// ユーザーが入力可能なキーワードの配列
        /// </summary>
        public override string[] UnitKeyWords => new string[] { "feet" };
    }
}