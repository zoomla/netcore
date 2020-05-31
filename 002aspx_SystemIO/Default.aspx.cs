using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
     

namespace _200528study
{
    //控制台方法不适合aspx:
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine($"山东上格科技，统一全世界，22领先东北亚");
    //        Console.WriteLine($"孙总您好，发哥机器人和您汇报本机存储状态：");
    //        Console.WriteLine($"");

    //        DriveInfo[] drs = DriveInfo.GetDrives();
    //        //筛选可访问的分区
    //        var q = from d in drs
    //                where d.IsReady
    //                select d;
    //        foreach (var di in q)
    //        {
    //            //Console.WriteLine($"山东上格科技，统一全世界，领先东北亚");

    //            Console.WriteLine($"驱动器名:{di.Name}");
    //            Console.WriteLine($"卷标:{di.VolumeLabel}");
    //            Console.WriteLine($"总容量:{di.TotalSize}");
    //            Console.WriteLine($"当前或用空间:{di.TotalFreeSpace}");
    //        }
    //        //Console.WriteLine("Hello World!");
    //        Console.Read();
    //    }
    //}
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                InitDrivers();
            }
        }
        private void InitDrivers()
        {
            //获取当前机器上所有磁盘分区信息
            DriveInfo[] drivers = DriveInfo.GetDrives();
            DataTable data = new DataTable();
            data.Columns.Add("DriverName", typeof(string));
            data.Columns.Add("DriveType", typeof(string));
            data.Columns.Add("DriveFormat", typeof(string));
            data.Columns.Add("VolumeLabel", typeof(string));
            data.Columns.Add("TotalFreeSpace", typeof(long));
            data.Columns.Add("TotalSize", typeof(long));
            data.Columns.Add("Percent", typeof(float));
            data.Columns.Add("AvailableFreeSpace", typeof(float));
            foreach (DriveInfo info in drivers)
            {
                //这里仅列出硬盘分区的使用情况
                if (info.DriveType == DriveType.Fixed)
                {
                    DataRow row = data.NewRow();
                    //磁盘分区名称
                    row["DriverName"] = info.Name;
                    //磁盘分区类型，如软驱、硬盘或者光驱等
                    row["DriveType"] = info.DriveType;
                    //磁盘分区文件系统，如FAT16、FAT32及NTFS等
                    row["DriveFormat"] = info.DriveFormat;
                    //磁盘分区卷标
                    row["VolumeLabel"] = info.VolumeLabel;
                    //磁盘空闲容量
                    row["TotalFreeSpace"] = info.TotalFreeSpace;
                    //磁盘容量
                    row["TotalSize"] = info.TotalSize;
                    //磁盘使用量百分比
                    row["Percent"] = info.TotalFreeSpace * 100 / info.TotalSize;
                    //当前用户的磁盘配额
                    row["AvailableFreeSpace"] = info.AvailableFreeSpace;
                    data.Rows.Add(row);
                }
            }
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
    }
}