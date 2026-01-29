namespace Practice17_2 {
    /// <summary>
    /// 距離変換用の基底クラス
    /// </summary>
    public abstract class ConverterBase {

        /// <summary>
        /// 指定された単位名が自分の単位を表すかどうか調べる
        /// </summary>
        /// <param name="vUnitName">単位名</param>
        /// <returns>対象単位かどうか</returns>
        public abstract bool IsMyUnit(string vUnitName);

        /// <summary>
        /// メートルとの比率
        /// </summary>
        protected abstract double Ratio { get; }

        /// <summary>
        /// 距離の単位名
        /// </summary>
        public abstract string UnitName { get; }

        /// <summary>
        /// メートルからの変換
        /// </summary>
        /// <param name="vMeter">メートル単位の値</param>
        /// <returns>指定の単位に変換した値</returns>
        public double FromMeter(double vMeter) {
            return vMeter / this.Ratio;
        }

        /// <summary>
        /// メートルへの変換
        /// </summary>
        /// <param name="vValue">指定した単位での値</param>
        /// <returns>メートルに変換した値</returns>
        public double ToMeter(double vValue) {
            return vValue * this.Ratio;
        }
    }
}
