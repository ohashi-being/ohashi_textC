namespace Practice17_2 {
    /// <summary>
    /// マイル変換用のクラス
    /// </summary>
    public class MileConverter : ConverterBase {
        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio => 1609.344;

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName => "マイル";

        /// <summary>
        /// ユーザーが入力可能なキーワードの配列
        /// </summary>
        public override string[] UnitKeyWords => new string[] { "mile" };
    }
}
