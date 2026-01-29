namespace Practice17_2 {
    /// <summary>
    /// /// 距離の単位変換用のクラス
    /// </summary>
    public class DistanceConverter {

        /// <summary>
        /// 変換元の単位
        /// </summary>
        public ConverterBase From { get; }

        /// <summary>
        /// 変換先の単位
        /// </summary>
        public ConverterBase To { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vFrom">変換元の単位</param>
        /// <param name="vTo">変換先の単位</param>
        public DistanceConverter(ConverterBase vFrom, ConverterBase vTo) {
            this.From = vFrom;
            this.To = vTo;
        }

        /// <summary>
        /// 距離の単位変換を行う
        /// </summary>
        /// <param name="vValue">変換する値</param>
        /// <returns>変換後の値</returns>
        public double Convert(double vValue) {
            double wMeter = this.From.ToMeter(vValue);
            return this.To.FromMeter(wMeter);
        }
    }
}
