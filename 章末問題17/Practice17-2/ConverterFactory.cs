using System.Linq;

namespace Practice17_2 {
    /// <summary>
    /// ConverterBaseのインスタンスを生成する
    /// </summary>
    static class ConverterFactory {

        /// <summary>
        /// 利用可能なConverterBaseのインスタンス一覧
        /// </summary>
        private static ConverterBase[] FConverters = new ConverterBase[] {
            new MeterConverter(),
            new InchConverter(),
            new YardConverter(),
            new FeetConverter(),
            new MileConverter(),
            new KiloMeterConverter(),
        };

        /// <summary>
        /// 指定された単位名に対応するConverterBaseのインスタンスを取得する
        /// </summary>
        /// <param name="vUnitName">指定した単位名</param>
        /// <returns>対応するConverterBaseのインスタンス</returns>
        public static ConverterBase GetInstance(string vUnitName) {
            return FConverters.FirstOrDefault(x => x.IsMyUnit(vUnitName));
        }

        /// <summary>
        /// 利用可能な単位の入力キーワードを取得する
        /// </summary>
        /// <returns>すべての利用可能な単位識別子を/で連結した文字列</returns>
        public static string GetAvailableUnits() {
            var wAvailableUnitKeys = FConverters
                .SelectMany(x => x.UnitKeyWords)
                .OrderBy(x => x);

            return string.Join("/", wAvailableUnitKeys);
        }

    }
}
