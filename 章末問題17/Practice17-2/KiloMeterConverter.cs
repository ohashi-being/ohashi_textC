namespace Practice17_2 {
    /// <summary>
    /// キロメートル変換用のクラス
    /// </summary>
    class KiloMeterConverter : ConverterBase {
        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio => 1000;

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName => "キロメートル";

        /// <summary>
        /// ユーザーが入力可能なキーワードの配列
        /// </summary>
        public override string[] UnitKeyWords => new string[] { "kilometer", "km" };
    }
}