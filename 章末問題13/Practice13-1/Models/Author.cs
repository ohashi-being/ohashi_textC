using System;
using System.Collections.Generic;

namespace Practice13_1.Models {
    /// <summary>
    /// 著者情報を表すクラス
    /// </summary>
    public class Author {
        /// <summary>
        /// 著者ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 著者名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 著者の誕生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 著者の性別
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// この著者が執筆した書籍のコレクション
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
        /// <summary>
        /// デフォルトコンストラクタ
        /// Booksコレクションを初期化する
        /// </summary>
        public Author() {
            this.Books = new List<Book>();
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vName">著者名</param>
        /// <param name="vBirthday">著者の誕生日</param>
        /// <param name="vGender">著者の性別</param>
        public Author(string vName, DateTime vBirthday, string vGender) : this() {
            this.Name = vName;
            this.Birthday = vBirthday;
            this.Gender = vGender;
        }
        /// <summary>
        /// 著者情報を文字列として返す
        /// </summary>
        /// <returns>著者名(誕生日, 性別)の形式の文字列</returns>
        public override string ToString() {
            return $"{this.Name} ({this.Birthday:yyyy/MM/dd}, {this.Gender})";
        }
    }
}