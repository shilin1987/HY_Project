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
    
    public partial class lr_base_log
    {
        public string F_LogId { get; set; }
        public Nullable<int> F_CategoryId { get; set; }
        public string F_SourceObjectId { get; set; }
        public string F_SourceContentJson { get; set; }
        public Nullable<System.DateTime> F_OperateTime { get; set; }
        public string F_OperateUserId { get; set; }
        public string F_OperateAccount { get; set; }
        public string F_OperateTypeId { get; set; }
        public string F_OperateType { get; set; }
        public string F_Module { get; set; }
        public string F_IPAddress { get; set; }
        public string F_IPAddressName { get; set; }
        public string F_Host { get; set; }
        public string F_Browser { get; set; }
        public Nullable<int> F_ExecuteResult { get; set; }
        public string F_ExecuteResultJson { get; set; }
        public string F_Description { get; set; }
        public Nullable<int> F_DeleteMark { get; set; }
        public Nullable<int> F_EnabledMark { get; set; }
    }
}