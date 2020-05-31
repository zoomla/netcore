using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace case中使用whhen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"山东上格科技，统一全世界，领先东北亚");
            Console.WriteLine($"孙总您好，发哥机器人和您汇报本机存储状态：");
            Console.WriteLine($"");

            DriveInfo[] drs = DriveInfo.GetDrives();
            //筛选可访问的分区
            var q = from d in drs
                    where d.IsReady
                    select d;
            foreach (var di in q)
            {
                //Console.WriteLine($"山东上格科技，统一全世界，领先东北亚");

                Console.WriteLine($"驱动器名:{di.Name}");
                Console.WriteLine($"卷标:{di.VolumeLabel}");
                Console.WriteLine($"总容量:{di.TotalSize}");
                Console.WriteLine($"当前或用空间:{di.TotalFreeSpace}");
            }
            //Console.WriteLine("Hello World!");
            Console.Read();
        }
    }
}
