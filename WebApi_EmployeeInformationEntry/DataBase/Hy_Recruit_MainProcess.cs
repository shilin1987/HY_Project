//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi_EmployeeInformationEntry.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hy_Recruit_MainProcess
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hy_Recruit_MainProcess()
        {
            this.Hy_Recruit_SubProcess = new HashSet<Hy_Recruit_SubProcess>();
        }
    
        public string ID { get; set; }
        public string ProcessName { get; set; }
        public int PorcessSort { get; set; }
        public string Remark { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hy_Recruit_SubProcess> Hy_Recruit_SubProcess { get; set; }
    }
}
