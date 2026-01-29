namespace Practice17_2 {
    /// <summary>
    /// フィート変換用のクラス
    /// </summary>
    public class FeetConverter : ConverterBase {
        /// <summary>
        /// 指定された単位名がフィートを表すかどうか調べる
        /// </summary>
        /// <param name="vName">判定する単位名</param>
        /// <returns>指定された単位名がフィートを表すかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "feet" || vName == this.UnitName;

        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio { get { return 0.3048; } }

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName { get { return "フィート"; } }
    }
}