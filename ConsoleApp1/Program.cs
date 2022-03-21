using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ////Test Serilog Example One
            //Log.Logger = new LoggerConfiguration()
            //.MinimumLevel.Verbose() // 設定最低顯示層級   預設: Information
            //.WriteTo.Console() // 輸出到 指令視窗
            //.WriteTo.File("log-.log",
            //    rollingInterval: RollingInterval.Day, // 每天一個檔案
            //    outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u5}] {Message:lj}{NewLine}{Exception}"
            //) // 輸出到檔案 檔名範例: log-20211005.log
            //.CreateLogger();

            //Log.Information("Init Ruyut");

            //Log.Debug("debug");

            //Log.CloseAndFlush();
            ////
            
            ////Test Serial Example Two, config setting from .json
            //Directory.GetCurrentDirectory return bin folder
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            //How to get the value from .json
            //var testobj = config.GetSection("Serilog").GetSection("MinimumLevel").GetSection("Default");

            Log.Logger = new LoggerConfiguration()  //初始化 Logger 配置
            .ReadFrom.Configuration(builder.Build()) //将 Serilog 连接到我们的配置
            .CreateLogger(); //初始化 Logger

            Log.Logger.Information($"Run Test Serilog Example 2 {DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss")}");
            ////
        }
    }
}
