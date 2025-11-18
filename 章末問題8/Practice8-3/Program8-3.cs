using System;
using System.Threading;

/* 問題8.3
ある処理時間を計測するTimeWatchクラスを定義してください。
TimeWatchの使い方は以下の通りです。

var tw = new TimeWatch();
tw.Start();
  ︙（処理）
TimeSpan duration = tw.Stop();
Console.WriteLine($"処理時間は{duration.TotalMilliseconds}ミリ秒でした");

*/

namespace Practice8_3 {
    internal class Program {
        static void Main(string[] args) {
            var wTimeWatch = new TimeWatch();
            wTimeWatch.Start();
            Console.WriteLine("処理中...");
            Thread.Sleep(3000);
            TimeSpan wProcessingTime = wTimeWatch.Stop();
            Console.WriteLine($"処理時間は{wProcessingTime.TotalMilliseconds}ミリ秒でした");
        }
    }
}
