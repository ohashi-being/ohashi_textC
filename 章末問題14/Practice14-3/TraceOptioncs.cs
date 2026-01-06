using System.Configuration;

namespace Practice14_3 {
    public class TraceOption : ConfigurationElement {
        /// <summary>
        /// トレース機能が有効かどうか
        /// </summary>
        [ConfigurationProperty("enabled")]
        public bool Enabled {
            get { return (bool)this["enabled"]; }
        }
        /// <summary>
        /// トレースログのファイルパス
        /// </summary>
        [ConfigurationProperty("filePath")]
        public string FilePath {
            get { return (string)this["filePath"]; }
        }
        /// <summary>
        /// トレースログのバッファサイズ
        /// </summary>
        [ConfigurationProperty("bufferSize")]
        public int BufferSize {
            get { return (int)this["bufferSize"]; }
        }
    }
}
