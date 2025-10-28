namespace Practice2_1 {
    //　1の解答
    /// <summary>
    /// 歌の情報を設定するクラス
    /// </summary>
    internal class Song {
        /// <summary>
        /// 歌のタイトル
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// アーティスト名
        /// </summary>
        public string ArtistName { get; }
        /// <summary>
        /// 演奏時間　（単位は秒）
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// 歌の情報を入力するコンストラクタ
        /// </summary>
        /// <param name="vTitle">歌のタイトル</param>
        /// <param name="vArtistName">アーティスト名</param>
        /// <param name="vLength">演奏時間（単位は秒）</param>
        // 2の解答
        public Song(string vTitle, string vArtistName, int vLength) {
            this.Title = vTitle;
            this.ArtistName = vArtistName;
            this.Length = vLength;
        }
    }
}