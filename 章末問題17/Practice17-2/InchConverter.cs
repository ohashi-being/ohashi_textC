namespace Practice17_2 {
    /// <summary>
    /// インチ変換用のクラス
    /// </summary>
    class InchConverter : ConverterBase {
        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio => 0.0254;

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName => "インチ";

        /// <summary>
        /// ユーザーが入力可能なキーワードの配列
        /// </summary>
        public override string[] UnitKeyWords => new string[] { "inch" };
    }
}