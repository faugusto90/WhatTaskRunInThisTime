using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatTaskRunInThisTime
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TaskService ts = new TaskService(@"server", "User", "Domain", "Password"))
            {
                StringBuilder sb = new StringBuilder();
                var tasks = ts.AllTasks;

                var minDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 59, 59);
                var maxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 01, 00);

                foreach (var item in tasks)
                {
                    if (item.LastRunTime >= minDate && item.LastRunTime <= maxDate)
                    {
                        sb.AppendLine("Folder " + item.Folder + "\n Path " + item.Path + "\n  Name:" + item.Name);
                    }
                }

               Console.Write(sb.ToString());

                Console.ReadKey();
            }
        }
    }
}
