namespace Practice17_2 {
    /// <summary>
    /// メートル変換用のクラス
    /// </summary>
    class MeterConverter : ConverterBase {
        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio => 1;

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName => "メートル";

        /// <summary>
        /// ユーザーが入力可能なキーワードの配列
        /// </summary>
        public override string[] UnitKeyWords => new string[] { "meter" };
    }
}
