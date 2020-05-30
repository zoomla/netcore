using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System.IO;
using System.Data;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //DriveInfo[] drivers = DriveInfo.GetDrives();
            //ViewData["message"] = DriveInfo.GetDrives();
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
                    row["TotalFreeSpace"] = info.TotalFreeSpace / 1024 / 1024 / 1024;
                    //磁盘容量
                    row["TotalSize"] = info.TotalSize / 1024 / 1024 /1024;
                    //磁盘使用量百分比
                    row["Percent"] = info.TotalFreeSpace * 100 / info.TotalSize;
                    //当前用户的磁盘配额
                    row["AvailableFreeSpace"] = info.AvailableFreeSpace / 1024 / 1024 / 1024;
                    data.Rows.Add(row);
                    //DataRow["DriverName"] = info.Name;
                    //DataRow["DriveType"] = info.TotalSize;
                    //DataRow["DriveFormat"] = info.DriveFormat;
                }
            }
            ViewBag.abcd = data;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
