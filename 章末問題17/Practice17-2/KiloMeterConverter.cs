namespace Practice17_2 {
    /// <summary>
    /// キロメートル変換用のクラス
    /// </summary>
    public class KiloMeterConverter : ConverterBase {
        /// <summary>
        /// 指定された単位名がキロメートルを表すかどうか調べる
        /// </summary>
        /// <param name="vName">判定する単位名</param>
        /// <returns>指定された単位名がキロメートルを表すかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "kilometer" || vName.ToLower() == "km" || vName == this.UnitName;

        /// <summary>
        /// メートルとの換算比率
        /// </summary>
        protected override double Ratio { get { return 1000; } }

        /// <summary>
        /// 単位の表示名
        /// </summary>
        public override string UnitName { get { return "キロメートル"; } }
    }
}