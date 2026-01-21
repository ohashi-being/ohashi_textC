using System.Collections.Generic;

namespace Practice15_1 {
    /// <summary>
    /// 書籍とカテゴリーのデータを保持するクラス
    /// </summary>
    public static class Library {
        /// <summary>
        /// カテゴリのコレクション
        /// </summary>
        public static IReadOnlyList<Category> Categories { get; }
        /// <summary>
        /// 書籍のコレクション
        /// </summary>
        public static IReadOnlyList<Book> Books { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        static Library() {
            Categories = new List<Category> {
                new Category (1, "Development"),
                new Category (2, "Server"),
                new Category (3, "Web Design"),
                new Category (4, "Windows"),
                new Category (5, "Application"),
            };
            Books = new List<Book> {
                new Book ("Writing C# Solid Code",1,2500, 2016 ),
                new Book ("C#開発指南", 1, 3800, 2014),
                new Book ("Visual C#再入門", 1, 2780, 2016),
                new Book ("フレーズで学ぶC# Book", 1, 2400, 2016),
                new Book ("TypeScript初級講座", 1, 2500, 2015),
                new Book ("PowerShell 実践レシピ", 2, 4200, 2013),
                new Book ("SQL Server 完全入門", 2, 3800, 2014),
                new Book ("IIS Webサーバー運用ガイド", 2, 3180, 2015),
                new Book ("Microsoft Azureサーバー構築", 2, 4800, 2016),
                new Book ("Webデザイン講座 HTML5＆CSS", 3, 2800, 2013),
                new Book ("HTML5 Web大百科", 3, 3800, 2015),
                new Book ("CSSデザイン 逆引き辞典", 3, 3550, 2015),
                new Book ("Windows10で楽しくお仕事", 4, 2280, 2016),
                new Book ("Windows10使いこなし術", 4, 1890, 2015),
                new Book ("続Windows10使いこなし術", 4, 2080, 2016),
                new Book ("Windows10 やさしい操作入門", 4, 2300, 2015),
                new Book ("まるわかりMicrosoft Office入門", 5, 1890, 2015),
                new Book ("Word・Excel実践テンプレート集", 5, 2600, 2016),
                new Book ("たのしく学ぶExcel初級編", 5, 2800, 2015),
            };
        }
    }
}
