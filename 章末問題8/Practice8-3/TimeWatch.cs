using System;

namespace Practice8_3 {
    /// <summary>
    /// 
    /// </summary>
    public class TimeWatch {
        /// <summary>
        /// 計測開始時刻
        /// </summary>
        private DateTime FStartTime;
        /// <summary>
        /// 処理時間の計測を開始する
        /// </summary>
        public void Start() {
            FStartTime = DateTime.Now;
        }
        /// <summary>
        /// 開始からの経過時間を返す
        /// </summary>
        /// <returns>処理時間</returns>
        public TimeSpan Stop() {
            return DateTime.Now - FStartTime;
        }
    }
}
