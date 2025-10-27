/* 問題2-2

   インチからメートルへの変換表を1インチ刻みでコンソールに表示するプログラムを作成してください。
   この時のインチの範囲は、1インチから10インチまでとします。
   1インチは0.0254メートルとします。*/
using System;

namespace Practice2_2 {
    internal class Program {
        static void Main(string[] args) {
            PrintInchToMeter(1, 10);
        }

        /// <summary>
        /// インチからメートルへの変換結果を表示する
        /// </summary>
        /// <param name="vStart">始まりの数</param>
        /// <param name="vEnd">終わりの数</param>
        static void PrintInchToMeter(int vStart, int vEnd) {
            for (int wInch = vStart; wInch <= vEnd; wInch++) {
                Console.WriteLine($"{wInch} インチは {Converter.ConvertInchToMeter(wInch)} メートルです");
            }
        }
    }
}