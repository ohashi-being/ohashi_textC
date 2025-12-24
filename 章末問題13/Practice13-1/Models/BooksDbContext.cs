    using System.Data.Entity;

namespace Practice13_1.Models {
    /// <summary>
    /// 書籍と著者の情報を管理する
    /// </summary>
    public class BooksDbContext : DbContext {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BooksDbContext()
            : base("name=BooksDbContext") {
        }
        /// <summary>
        /// 書籍の追加、更新、削除、検索操作を行う
        /// </summary>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// 著者の追加、更新、削除、検索操作を行う
        /// </summary>
        public DbSet<Author> Authors { get; set; }
    }
}