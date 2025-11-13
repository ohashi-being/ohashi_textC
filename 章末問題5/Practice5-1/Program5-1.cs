using System;

/* 問題5.1
コンソールから入力した2つの文字列が等しいか調べるコードをかいてください。
このとき、大文字、小文字の違いは無視するようにしてください。
コンソールからの入力は、Console.ReadLineメソッドを利用してください。
*/

namespace Practice5_1 {
    class Program {
        static void Main(string[] args) {
            string[] wInputs = new string[2];
            for (int i = 0; i < wInputs.Length; i++) {
                wInputs[i] = GetInput($"{i + 1}つ目の文字列を入力してください ", x => string.IsNullOrWhiteSpace(x), $"{i + 1}つ目の文字列は入力必須です。文字列を入力してください。");
            }
            bool wIsEqual = string.Equals(wInputs[0], wInputs[1], StringComparison.OrdinalIgnoreCase);
            Console.WriteLine($"{wInputs[0]} と {wInputs[1]} は{(wIsEqual ? "等しい!" : "異なります。")}");
            Console.WriteLine($"{Environment.NewLine}終了するには何かキーを押してください...");
            Console.ReadKey();
        }
        /// <summary>
        /// ユーザーからの入力を受け取る
        /// </summary>
        /// <param name="vPrompt">ユーザーに入力を促すメッセージ</param>
        /// <param name="vCondition">入力が正しいかどうかを判定する関数</param>
        /// <param name="vErrorMessage">エラー発生時に表示するメッセージ</param>
        /// <returns>入力された文字列</returns>
        static string GetInput(string vPrompt, Func<string, bool> vCondition, string vErrorMessage) {
            while (true) {
                Console.Write($"{vPrompt}:");
                var wInput = Console.ReadLine();
                if (!vCondition.Invoke(wInput)) return wInput;
                Console.WriteLine(vErrorMessage);
            }
        }
    }
}