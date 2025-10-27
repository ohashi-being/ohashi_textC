/* 問題2-3

   店舗名、商品カテゴリ、売上が記載されているcsvファイルを読み取り、
   商品カテゴリ別の売上高を求めるプログラムを作成してください。*/
using System;

namespace Practice2_3 {
    class Program {
        static void Main(string[] args) {
            var wSales = new SalesCounter(@"..\..\Sales.csv");
            var wAmountPerCategory = wSales.GetCategorySales();
            foreach (var wObj in wAmountPerCategory) {
                Console.WriteLine($"{wObj.Key} : {wObj.Value} 円");
            }
        }
    }
}
