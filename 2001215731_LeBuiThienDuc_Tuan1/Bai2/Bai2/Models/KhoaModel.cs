using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bai2.Models
{
    public class KhoaModel
    {
        public string TenKhoa { get; set; }
        public int namThanhLap{get;set;}
        public string message { get; set; }
        public KhoaModel()
        {
            TenKhoa = "Khoa CNTT";
            namThanhLap = 2003;
            message = "WelCome To HUIT";
        }

    }
}