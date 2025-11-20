using System;

namespace Practice8_3 {
    /// <summary>
    /// 経過時間の計測を行う
    /// </summary>
    public class TimeWatch {
        /// <summary>
        /// 計測開始時刻
        /// </summary>
        private DateTime FStartTime;
        /// <summary>
        /// 経過時間
        /// </summary>
        private TimeSpan FElapsedTime = TimeSpan.Zero;
        /// <summary>
        /// 計測中かどうか
        /// </summary>
        private bool FIsRunning = false;
        /// <summary>
        /// 処理時間の計測を開始または再開する
        /// </summary>
        public void Start() {
            if (!FIsRunning) {
                FStartTime = DateTime.Now;
                FIsRunning = true;
            }
        }
        /// <summary>
        /// 開始からの経過時間を返す
        /// </summary>
        /// <returns>処理時間</returns>
        public TimeSpan Stop() {
            if (FIsRunning) {
                FElapsedTime = DateTime.Now - FStartTime;
                FIsRunning = false;
            }
            return FElapsedTime;
        }
    }
}
