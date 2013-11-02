﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace Brienz.Util
{
    /// <summary>
    /// Name:Stone
    /// DateTime: 2011/12/31 16:39:26
    /// Description:WinRAR压缩
    /// </summary>
    public class ZipHelper
    {
        // WinRAR安装注册表key
        private const string WinRAR_KEY = @"WinRAR.ZIP\shell\open\command";

        /// <summary>
        /// 利用 WinRAR 进行压缩
        /// </summary>
        /// <param name="path">将要被压缩的文件夹（绝对路径）</param>
        /// <param name="rarPath">压缩后的 .rar 的存放目录（绝对路径）</param>
        /// <param name="rarName">压缩文件的名称（包括后缀）</param>
        /// <returns>true 或 false。压缩成功返回 true，反之，false。</returns>
        public bool RAR(string path, string rarPath, string rarName)
        {
            bool flag = false;
            string rarexe;       //WinRAR.exe 的完整路径
            RegistryKey regkey;  //注册表键
            Object regvalue;     //键值
            string cmd;          //WinRAR 命令参数
            ProcessStartInfo startinfo;
            Process process;
            try
            {
                regkey = Registry.ClassesRoot.OpenSubKey(WinRAR_KEY);
                regvalue = regkey.GetValue("");  // 键值为 "d:\Program Files\WinRAR\WinRAR.exe" "%1"
                rarexe = regvalue.ToString();
                regkey.Close();
                rarexe = rarexe.Substring(1, rarexe.Length - 7);  // d:\Program Files\WinRAR\WinRAR.exe

                Directory.CreateDirectory(path);
                //压缩命令，相当于在要压缩的文件夹(path)上点右键->WinRAR->添加到压缩文件->输入压缩文件名(rarName)
                cmd = string.Format("a {0} {1} -r",
                                    rarName,
                                    path);
                startinfo = new ProcessStartInfo();
                startinfo.FileName = rarexe;
                startinfo.Arguments = cmd;                          //设置命令参数
                startinfo.WindowStyle = ProcessWindowStyle.Hidden;  //隐藏 WinRAR 窗口

                startinfo.WorkingDirectory = rarPath;
                process = new Process();
                process.StartInfo = startinfo;
                process.Start();
                process.WaitForExit(); //无限期等待进程 winrar.exe 退出
                if (process.HasExited)
                {
                    flag = true;
                }
                process.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }
        /// <summary>
        /// 利用 WinRAR 进行解压缩
        /// </summary>
        /// <param name="path">文件解压路径（绝对）</param>
        /// <param name="rarPath">将要解压缩的 .rar 文件的存放目录（绝对路径）</param>
        /// <param name="rarName">将要解压缩的 .rar 文件名（包括后缀）</param>
        /// <returns>true 或 false。解压缩成功返回 true，反之，false。</returns>
        public bool UnRAR(string path, string rarPath, string rarName)
        {
            bool flag = false;
            string rarexe;
            RegistryKey regkey;
            Object regvalue;
            string cmd;
            ProcessStartInfo startinfo;
            Process process;
            try
            {
                regkey = Registry.ClassesRoot.OpenSubKey(WinRAR_KEY);
                regvalue = regkey.GetValue("");
                rarexe = regvalue.ToString();
                regkey.Close();
                rarexe = rarexe.Substring(1, rarexe.Length - 7);

                Directory.CreateDirectory(path);
                //解压缩命令，相当于在要压缩文件(rarName)上点右键->WinRAR->解压到当前文件夹
                cmd = string.Format("x {0} {1} -y",
                                    rarName,
                                    path);
                startinfo = new ProcessStartInfo();
                startinfo.FileName = rarexe;
                startinfo.Arguments = cmd;
                startinfo.WindowStyle = ProcessWindowStyle.Hidden;

                startinfo.WorkingDirectory = rarPath;
                process = new Process();
                process.StartInfo = startinfo;
                process.Start();
                process.WaitForExit();
                if (process.HasExited)
                {
                    flag = true;
                }
                process.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }
    }
    /// <summary>
    /// Name:Stone
    /// DateTime: 2012/1/4 16:26:08
    /// Description:7Z解压管理类
    /// </summary>
    public class _7zRAR
    {
        // 7z.exe 安装地址
        private const string _7zEXE = @"7-Zip\7z.exe";
        /// <summary>
        /// 利用 7z.exe 进行压缩
        /// </summary>
        /// <param name="_7zPath">将要被压缩的文件夹（绝对路径）</param>
        /// <param name="filePath">压缩后的 .rar 的存放目录（绝对路径）</param>
        /// <param name="rarName">压缩文件的名称（包括后缀）</param>
        /// <returns>true 或 false。压缩成功返回 true，反之，false。</returns>
        public bool _7zZip(string _7zPath, string filePath, string rarName)
        {
            bool flag = false;
            string cmd;          //7zip 命令参数
            ProcessStartInfo startinfo;
            Process process;
            try
            {
                cmd = String.Format(@"a -mx=9 {0} {1}",
                    filePath +"\\" + rarName, _7zPath);
                startinfo = new ProcessStartInfo();
                startinfo.FileName = _7zEXE;
                startinfo.Arguments = cmd;                          //设置命令参数
                startinfo.WindowStyle = ProcessWindowStyle.Hidden;  //隐藏 WinRAR 窗口

                startinfo.WorkingDirectory = filePath;
                process = new Process();
                process.StartInfo = startinfo;
                process.Start();
                process.StartInfo.UseShellExecute = false;
                process.WaitForExit(); //无限期等待进程 winrar.exe 退出
                if (process.HasExited)
                {
                    flag = true;
                }
                process.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }
        /// <summary>
        /// 利用 7zExE 进行压缩
        /// </summary>
        /// <param name="_7zPath">将要被压缩的文件夹（物理路径）</param>
        /// <param name="filePath">压缩后的的存放目录（物理路径）</param>
        /// <returns>true 或 false。压缩成功返回 true，反之，false。</returns>
        public bool Un7zRAR(string _7zPath, string filePath)
        {
            bool flag = false;

            string cmd;
            ProcessStartInfo startinfo;
            Process process;
            try
            {
                cmd = String.Format(@"x {0} -o{1} -y",
                    _7zPath, filePath);
                startinfo = new ProcessStartInfo();
                startinfo.FileName = _7zEXE;
                startinfo.Arguments = cmd;
                startinfo.WindowStyle = ProcessWindowStyle.Hidden;

                process = new Process();
                process.StartInfo = startinfo;
                process.Start();
                process.WaitForExit();
                if (process.HasExited)
                {
                    flag = true;
                }
                process.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return flag;
        }
    }
}
