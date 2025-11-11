/* 問題4.1
 * 
 * 以下の順にYearMonthクラスを定義してください。
 * 
 * 1.年(Year)と月(Month)の2つのプロパティを持つクラスYearMonthを定義してください。
 *   このとき、2つのプロパティは読み取り専用にし、値はコンストラクタで指定できるようにしてください。
 *   引数で渡される月の値は1から12の範囲にあるものと仮定してかまいません。
 * 
 * 2.YearMonthクラスに、Is21Centuryプロパティを追加してください。
 *   2001年から2100年までが21世紀です。この処理では加減乗除は行わないでください。
 * 
 * 3.YearMonthクラスに、1ヵ月後を求めるGetAfterOneMonthメソッドを追加してください。
 *   このとき、自分自身のプロパティは変更せずに、新たなYearMonthオブジェクトを生成し、その値を返してください。
 *   12月の時の処理に注意してください。
 * 
 * 4.ToStringメソッドをオーバーライドしてください。
 *   結果は、"yyyy年M月"といった形式にしてください。 */

using System;

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
        // 2の解答
        /// <summary>
        /// 21世紀かどうかを返す
        /// </summary>
        public bool Is21Century => 2001 <= this.Year && this.Year <= 2100;
        /// <summary>
        /// うるう年かどうかを返す
        /// </summary>
        public bool IsLeapYear => this.Year % 4 == 0 && (this.Year % 100 != 0 || this.Year % 400 == 0);
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vYear">年</param>
        /// <param name="vMonth">月</param>
        public YearMonth(int vYear, int vMonth) {
            if (vMonth < 1 || vMonth > 12) throw new ArgumentOutOfRangeException(nameof(vMonth), "月は1から12の範囲で指定してください。");
            if (vYear < 1 || vYear > 9999) throw new ArgumentOutOfRangeException(nameof(vYear), "年は1から9999の範囲で指定してください。");
            this.Year = vYear;
            this.Month = vMonth;
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
        /// <returns>yyyy年M月という形式に変換</returns>
        public override string ToString() => $"{this.Year:D4}年{this.Month}月";
    }
}
