using System;

namespace Practice13_1.Models {
    /// <summary>
    /// 書籍情報を表すクラス
    /// </summary>
    public class Book {
        /// <summary>
        /// 書籍ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 書籍のタイトル
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 出版年
        /// </summary>
        public int PublishedYear { get; set; }
        /// <summary>
        /// この書籍の著者
        /// </summary>
        public virtual Author Author { get; set; }
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Book() {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">書籍のタイトル</param>
        /// <param name="vPublishedYear">出版年</param>
        /// <param name="vAuthor">著者のAuthorオブジェクト</param>
        public Book(string vTitle, int vPublishedYear, Author vAuthor) {
            this.Title = vTitle;
            this.PublishedYear = vPublishedYear;
            this.Author = vAuthor;
        }
        /// <summary>
        /// 著者情報から新しいAuthorオブジェクトを作成するコンストラクタ
        /// </summary>
        /// <param name="vTitle">書籍のタイトル</param>
        /// <param name="vPublishedYear">出版年</param>
        /// <param name="vAuthorName">著者名</param>
        /// <param name="vAuthorBirthday">著者の誕生日</param>
        /// <param name="vAuthorGender">著者の性別</param>
        public Book(string vTitle, int vPublishedYear, string vAuthorName, DateTime vAuthorBirthday, string vAuthorGender) {
            this.Title = vTitle;
            this.PublishedYear = vPublishedYear;
            this.Author = new Author(vAuthorName, vAuthorBirthday, vAuthorGender);
        }
        /// <summary>
        /// 書籍情報を著者名付きで文字列として返す
        /// </summary>
        /// <returns>『タイトル』(出版年) - 著者名 の形式の文字列</returns>
        public override string ToString() {
            return $"『{this.Title}』({this.PublishedYear}年) - {this.Author?.Name ?? "著者不明"}";
        }
        /// <summary>
        /// 書籍情報を著者名なしで文字列として返す
        /// </summary>
        /// <returns>『タイトル』(出版年) の形式の文字列</returns>
        public string ToStringWithoutAuthor() {
            return $"『{this.Title}』({this.PublishedYear}年)";
        }
    }
}
