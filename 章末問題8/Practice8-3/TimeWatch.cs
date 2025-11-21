using System;

namespace Practice8_3 {
    /// <summary>
    /// 経過時間の計測を行う
    /// </summary>
    public class TimeWatch {
        /// <summary>
        /// 計測開始時刻
        /// </summary>
        private DateTime FStartTime = default;
        /// <summary>
        /// 処理時間の計測を開始または再開する
        /// </summary>
        public void Start() => FStartTime = (FStartTime == default) ? DateTime.Now : FStartTime;
        /// <summary>
        /// 開始からの経過時間を返す
        /// </summary>
        /// <returns>処理時間</returns>
        public TimeSpan Stop() {
            if (FStartTime != default) {
                FStartTime = default;
                return DateTime.Now - FStartTime;
            }
            return TimeSpan.Zero;
        }
    }
}
