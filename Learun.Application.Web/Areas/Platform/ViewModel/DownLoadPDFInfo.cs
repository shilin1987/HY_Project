using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learun.Application.Web.Areas.Platform.ViewModel
{
    public class DownLoadPDFInfo
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 正面
        /// </summary>
        public string canvasBase64Above { get; set; }
        /// <summary>
        /// 反面
        /// </summary>
        public string canvasBase64Below { get; set; }
    }

    public class JsonStr {
        public DownLoadPDFInfo jsondata { get; set; }

    } 
}