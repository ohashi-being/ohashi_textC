namespace Practice17_2 {
    /// <summary>
    /// ヤード変換用のクラス
    /// </summary>
    public class YardConverter : ConverterBase {
        /// <summary>
        /// 指定された単位名がヤードを表すかどうか調べる
        /// </summary>
        /// <param name="vName">判定する単位名</param>
        /// <returns>指定された単位名がヤードを表すかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "yard" || vName == this.UnitName;

        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio { get { return 0.9144; } }

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName { get { return "ヤード"; } }
    }
}