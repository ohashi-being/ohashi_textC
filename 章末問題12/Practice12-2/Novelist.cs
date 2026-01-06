using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Practice12_2 {
    [XmlRoot("novelist")]
    [DataContract]
    public class Novelist {
        /// <summary>
        /// 著者名
        /// </summary>
        [XmlElement(ElementName = "name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 生年月日
        /// </summary>
        [XmlElement(ElementName = "birth")]
        [DataMember(Name = "birth")]
        public DateTime Birth { get; set; }
        /// <summary>
        /// 代表作
        /// </summary>
        [XmlArray("masterpieces")]
        [XmlArrayItem("title", typeof(string))]
        [DataMember(Name = "masterpieces")]
        public string[] Masterpieces { get; set; }
        public override string ToString() {
            var wMasterpieces = this.Masterpieces?.Length > 0 ? string.Join(", ", this.Masterpieces) : "代表作なし";
            return $"Name: {this.Name}, Birth: {this.Birth:yyyy-MM-dd}, Masterpieces: {wMasterpieces}";
        }
    }
}
