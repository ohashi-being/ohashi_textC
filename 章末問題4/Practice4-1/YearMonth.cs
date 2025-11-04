/* 問題4.1
 * 
 * 以下の順にYearMonthクラスを定義してください。
 * 
 * 1.年(Year)と月(Month)の2つのプロパティを持つクラスYearMonthを定義してください。
 *   このとき、2つのプロパティは読み取り専用にし、値はコンストラクタで指定できるようにしてください。
 *   引数で渡される月の値は1から2の範囲にあるものと仮定してかまいません。
 * 
 * 2.YearMonthクラスに、Check21Centuryプロパティを追加してください。
 *   2001年から2100年までが21世紀です。この処理では加減乗除は行わないでください。
 * 
 * 3.YearMonthクラスに、1ヵ月後を求めるGetAfterOneMonthメソッドを追加してください。
 *   このとき、自分自身のプロパティは変更せずに、新たなYearMonthオブジェクトを生成し、その値を返してください。
 *   12月の時の処理に注意してください。
 * 
 * 4.ToStringメソッドをオーバーライドしてください。
 *   結果は、"2017年8月"といった形式にしてください。 */

namespace Practice4_1 {
    public class YearMonth {
        // 1の解答
        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; }
        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; }
        /// <summary>
        /// 年月を入力するコンストラクタ
        /// </summary>
        /// <param name="vYear">年</param>
        /// <param name="vMonth">月</param>
        public YearMonth(int vYear, int vMonth) {
            this.Year = vYear;
            this.Month = vMonth;
        }
        // 2の解答
        /// <summary>
        /// 年が21世紀かどうか判定する
        /// </summary>
        public bool Check21Century {
            get {
                return 2001 <= this.Year && this.Year <= 2100;
            }
        }
        // 3の解答
        /// <summary>
        /// １ヵ月後の年月を取得する
        /// </summary>
        /// <returns>1ヵ月後の年と月</returns>
        public YearMonth GetAfterOneMonth() {
            if (this.Month == 12) {
                return new YearMonth(this.Year + 1, 1);
            } else {
                return new YearMonth(this.Year, this.Month + 1);
            }
        }
        // 4の解答
        /// <summary>
        /// ToStringメソッドをオーバーライドし、形式を変換する
        /// </summary>
        /// <returns>2017年8月という形式に変換</returns>
        public override string ToString() {
            return $"{this.Year} 年 {this.Month} 月";
        }
    }
}
