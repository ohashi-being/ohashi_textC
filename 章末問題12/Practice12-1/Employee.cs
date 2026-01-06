using System;
using System.Xml.Serialization;

namespace Practice12_1 {
    [XmlRoot("employee")]
    public class Employee {
        /// <summary>
        /// ID
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }
        /// <summary>
        /// 雇用者名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// 雇用開始日
        /// </summary>
        [XmlElement("hiredate")]
        public DateTime HireDate { get; set; }
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Employee() {
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vID">ID</param>
        /// <param name="vName">雇用者名</param>
        /// <param name="vHireDate">雇用開始日</param>
        public Employee(int vID, string vName, DateTime vHireDate) {
            this.Id = vID;
            this.Name = vName;
            this.HireDate = vHireDate;
        }
        public override string ToString() {
            return $"Id: {this.Id}, Name: {this.Name}, HireDate: {this.HireDate}";
        }
    }
}
