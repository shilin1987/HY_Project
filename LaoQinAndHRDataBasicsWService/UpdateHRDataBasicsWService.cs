using LaoQinAndHRDataBasicsWService.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LaoQinAndHRDataBasicsWService
{
    public partial class UpdateHRDataBasicsWService : ServiceBase
    {
        readonly HRDataMigrationService service;
        public UpdateHRDataBasicsWService()
        {
            InitializeComponent();
            service = new HRDataMigrationService();
        }

        string logFilePath = @"D:\HRDataBasicsServiceLog.txt";

        protected override void OnStart(string[] args)
        {
            log("服务启动！");
            // Set up a timer that triggers every minute.设置定时器
            var timer = new Timer();
            timer.Interval = 3600000; // 3600 seconds 3600秒(一小时)执行一次
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            log("服务停止！");
            base.OnStop();
        }
        protected override void OnPause()
        {
            //服务暂停执行代码
            log("服务暂停执行！");
            base.OnPause();
        }
        protected override void OnContinue()
        {
            //服务恢复执行代码
            log("服务恢复执行！");
            base.OnContinue();
        }
        protected override void OnShutdown()
        {
            //系统即将关闭执行代码
            log("系统即将关闭执行！");
            base.OnShutdown();
        }

        /// <summary>
        /// 定时器中定时执行的任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            //转移数据
            var t1=Task.Run(() =>
            {
                var result = service.DataMigration();
                log(result);
            });
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message"></param>
        private void log(string message)
        {
            using (FileStream stream = new FileStream(logFilePath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine($"{DateTime.Now}:{message}");
            }
        }
    }
}
