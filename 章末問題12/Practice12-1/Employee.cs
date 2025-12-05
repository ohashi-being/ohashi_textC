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
    }
}
