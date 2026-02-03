using System.Configuration;

namespace Practice14_3 {
    public class CalendarOption : ConfigurationElement {
        /// <summary>
        /// 日付の表示形式
        /// </summary>
        [ConfigurationProperty("StringFormat")]
        public string StringFormat {
            get { return (string)this["StringFormat"]; }
        }
        /// <summary>
        /// カレンダーで扱う日付の最小値
        /// </summary>
        [ConfigurationProperty("Minimum")]
        public string Minimum {
            get { return (string)this["Minimum"]; }
        }
        /// <summary>
        /// カレンダーで扱う日付の最大値
        /// </summary>
        [ConfigurationProperty("Maximum")]
        public string Maximum {
            get { return (string)this["Maximum"]; }
        }
        /// <summary>
        /// 週の開始日が月曜日かどうか
        /// </summary>
        [ConfigurationProperty("MondayIsFirstDay")]
        public bool MondayIsFirstDay {
            get { return (bool)this["MondayIsFirstDay"]; }
        }
    }
}
