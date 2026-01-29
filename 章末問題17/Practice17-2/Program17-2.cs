using System;

/* 問題17.2

「17.3:Strategyパターン」で示した距離換算プログラムに機能を追加し、
マイルとキロメートルも扱えるようにしてください。

*/

namespace Practice17_2 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine($"==================");
            Console.WriteLine("距離換算プログラム");
            Console.WriteLine($"=================={Environment.NewLine}");

            var wFromConverter = GetConverter("変換元");

            var wToConverter = GetConverter("変換先");

            double wValue = GetDistance(wFromConverter.UnitName);

            var wConverter = new DistanceConverter(wFromConverter, wToConverter);
            double wResult = wConverter.Convert(wValue);

            Console.WriteLine($"{wValue}{wFromConverter.UnitName}は{wResult:F4}{wToConverter.UnitName}です");
            Console.WriteLine($"{Environment.NewLine}Enterキーを押して終了してください...");
            Console.ReadLine();
        }

        /// <summary>
        /// ユーザー入力から対応する単位を取得する
        /// </summary>
        /// <param name="vPromptType">プロンプトの種類（変換元または変換先）</param>
        /// <returns>ConverterBaseのインスタンス</returns>
        private static ConverterBase GetConverter(string vPromptType) {
            while (true) {
                Console.WriteLine($"{vPromptType}の単位を入力して下さい (meter/km/kilometer/mile/inch/feet/yard):");
                string wUnit = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(wUnit)) {
                    Console.WriteLine("単位が入力されていません");
                    continue;
                }

                var wConverter = ConverterFactory.GetInstance(wUnit);
                if (wConverter == null) {
                    Console.WriteLine("対応していない単位です");
                    continue;
                }

                return wConverter;
            }
        }

        /// <summary>
        /// ユーザーから距離の値を取得する
        /// </summary>
        /// <param name="vUnitName">単位名</param>
        /// <returns>入力された距離の値</returns>
        private static double GetDistance(string vUnitName) {
            while (true) {
                Console.WriteLine($"変換する距離を{vUnitName}で入力して下さい");
                string wInputValue = Console.ReadLine();

                if (!double.TryParse(wInputValue, out double wValue)) {
                    Console.WriteLine("エラー: 数値を入力してください。");
                    continue;
                }

                if (wValue < 0) {
                    Console.WriteLine("エラー: 正の数値を入力してください。");
                    continue;
                }

                return wValue;
            }
        }
    }
}
