/* 問題2-1 

 1.以下のプロパティを持つ、Songクラスを定義してください。
   Title：string型（歌のタイトル）
   ArtistName：string型（アーティスト名）
   Length：int型（演奏時間、単位は秒）

 2.このとき、3つの引数を持つコンストラクタも定義してください。

 3.作成したSongクラスのインスタンスを複数生成し、配列songsに格納してください。

 4.配列に格納されたすべてのSongオブジェクトの内容をコンソールに出力してください。
   演奏時間の表示は「4:16」の形式で表示してください。
   ただし、演奏時間は必ず60分未満と仮定してかまいません。  */
using System;

namespace Practice2_1 {
    internal class Program {
        static void Main(string[] args) {
            // 3の解答
            var wSongs = new Song[] {
                new Song("Shohei", "Ohashi", 183),
                new Song("Energico", "Lemaire", 354),
                new Song("EriKing", "kawada", 391)
            };
            foreach (var wSong in wSongs) {
                PrintSongLength(wSong);
            }
        }
        /// <summary>
        /// アーティスト名、曲名、演奏時間を表示する
        /// </summary>
        // 4の解答
        static void PrintSongLength(Song vSong) {
            var wTime = TimeSpan.FromSeconds(vSong.Length);
            Console.WriteLine($"{vSong.ArtistName} の {vSong.Title} は {wTime.Minutes}:{wTime.Seconds:D2} かかる");
        }
    }
}