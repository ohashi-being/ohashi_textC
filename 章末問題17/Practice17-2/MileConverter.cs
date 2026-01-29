namespace Practice17_2 {
    /// <summary>
    /// マイル変換用のクラス
    /// </summary>
    public class MileConverter : ConverterBase {
        /// <summary>
        /// 指定された単位名がマイルを表すかどうか調べる
        /// </summary>
        /// <param name="vName">判定する単位名</param>
        /// <returns>指定された単位名がマイルを表すかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "mile" || vName == this.UnitName;

        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio { get { return 1609.344; } }

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName { get { return "マイル"; } }
    }
}
