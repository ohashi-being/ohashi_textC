using System;
using System.Runtime.Serialization;

namespace Practice12_1 {
    [DataContract]
    public class EmployeeForJson {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 雇用者名
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 雇用開始日
        /// </summary>
        [DataMember]
        public DateTime HireDate { get; set; }
        public EmployeeForJson(Employee vEmployee) {
            this.Id = vEmployee.Id;
            this.Name = vEmployee.Name;
            this.HireDate = vEmployee.HireDate;
        }
    }
}