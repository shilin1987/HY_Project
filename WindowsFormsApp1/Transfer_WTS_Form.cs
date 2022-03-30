using LaoQinAndHRDataBasicsWService.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.AttendanceWebReference;
using WindowsFormsApp1.WTSWebReference;

namespace WindowsFormsApp1
{
    public partial class Transfer_wts : Form
    {
        public Transfer_wts()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//用户线程中访问控件

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var service = new HRDataMigrationService();
            Task t1=Task.Run( ()=> {
                txtInfo.Text =DateTime.Now+" | "+ service.DataMigration();
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AuthorityService service = new AuthorityService();
            try
            {
                var resResult = service.GetAuthToken("DEFAULT", "wtspassword", "");
                var isSuccess=resResult.resFlag;
                txtInfo.Text += resResult.resMsg;
                var account= resResult.resCode;
                var token= resResult.resData.ToString();

                txtInfo.Text +="请求是否成功:"+ isSuccess;
                if (isSuccess=="1") {

                    AttendanceService attendance = new AttendanceService();

                    var result=attendance.AddSingleAttendanceRecord(token,"HY003711", "2022-03-28 08:17","1","0","","","admin","1","");
                    txtInfo.Text += " 插入劳勤数据提醒:"+result.resMsg;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
