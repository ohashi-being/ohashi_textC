using System.Configuration;

namespace Practice14_3 {
    public class MyAppSettings : ConfigurationSection {
        /// <summary>
        /// トレースオプションの設定
        /// </summary>
        [ConfigurationProperty("traceOption")]
        public TraceOption TraceOption {
            get { return (TraceOption)this["traceOption"]; }
            set { this["traceOption"] = value; }
        }
        /// <summary>
        /// カレンダーオプションの設定
        /// </summary>
        [ConfigurationProperty("CalendarOption")]
        public CalendarOption CalenderOption {
            get { return (CalendarOption)this["CalendarOption"]; }
            set { this["CalendarOption"] = value; }
        }
    }
}
