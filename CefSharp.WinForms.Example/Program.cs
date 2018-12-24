// Copyright © 2010 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.Example;
using CefSharp.Example.Handlers;
using CefSharp.WinForms.Example.Handlers;
using CefSharp.WinForms.Example.Minimal;

namespace CefSharp.WinForms.Example
{
    public class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            //const bool simpleSubProcess = false;
           

            //For Windows 7 and above, best to include relevant app.manifest entries as well
            Cef.EnableHighDPISupport();

            //We're going to manually call Cef.Shutdown below, this maybe required in some complex scenarios
            CefSharpSettings.ShutdownOnExit = true;

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(getInitSetting(),
                performDependencyCheck: true,
                browserProcessHandler: null);

            Application.Run(new BrowserForm(false));

            //            //NOTE: Using a simple sub processes uses your existing application executable to spawn instances of the sub process.
            //            //Features like JSB, EvaluateScriptAsync, custom schemes require the CefSharp.BrowserSubprocess to function
            //            if (simpleSubProcess)
            //            {
            //                var exitCode = Cef.ExecuteProcess();

            //                if (exitCode >= 0)
            //                {
            //                    return exitCode;
            //                }

            //#if DEBUG
            //                if (!System.Diagnostics.Debugger.IsAttached)
            //                {
            //                    MessageBox.Show("When running this Example outside of Visual Studio" +
            //                                    "please make sure you compile in `Release` mode.", "Warning");
            //                }
            //#endif

            //                var settings = new CefSettings();
            //                settings.BrowserSubprocessPath = "CefSharp.WinForms.Example.exe";

            //                Cef.Initialize(settings);

            //                var browser = new SimpleBrowserForm();
            //                Application.Run(browser);
            //            }
            //            else
            //            {
            //#if DEBUG
            //                if (!System.Diagnostics.Debugger.IsAttached)
            //                {
            //                    MessageBox.Show("When running this Example outside of Visual Studio" +
            //                                    "please make sure you compile in `Release` mode.", "Warning");
            //                }
            //#endif

            //                const bool multiThreadedMessageLoop = true;

            //                var browser = new BrowserForm(multiThreadedMessageLoop);
            //                //var browser = new SimpleBrowserForm();
            //                //var browser = new TabulationDemoForm();

            //                //IBrowserProcessHandler browserProcessHandler;

            //                //if (multiThreadedMessageLoop)
            //                //{
            //                //    browserProcessHandler = new BrowserProcessHandler();
            //                //}
            //                //else
            //                //{
            //                //    //Get the current taskScheduler (must be called after the form is created)
            //                //    var scheduler = TaskScheduler.FromCurrentSynchronizationContext();

            //                //    browserProcessHandler = new WinFormsBrowserProcessHandler(scheduler);
            //                //}

            //                //var settings = new CefSettings();
            //                //settings.MultiThreadedMessageLoop = multiThreadedMessageLoop;
            //                //settings.ExternalMessagePump = !multiThreadedMessageLoop;

            //                CefExample.Init(getInitSetting(), browserProcessHandler: browserProcessHandler);

            //                Application.Run(browser);
            //            }

            return 0;
        }

        /// <summary>
        /// 浏览器初始化, 需要在主线程进行
        /// </summary>
        public static CefSettings getInitSetting()
        {
            CefSettings settings = new CefSettings();

            // Increase the log severity so CEF outputs detailed information, useful for debugging
            settings.LogSeverity = LogSeverity.Verbose;
            // By default CEF uses an in memory cache, to save cached data e.g. passwords you need to specify a cache path
            // NOTE: The executing user must have sufficient privileges to write to this folder.
            settings.CachePath = "cache";

            // Enable WebRTC                            
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");

            //Enable GPU Acceleration
            settings.CefCommandLineArgs.Add("disable-gpu", "0");

            // Don't use a proxy server, always make direct connections. Overrides any other proxy server flags that are passed.
            // Slightly improves Cef initialize time as it won't attempt to resolve a proxy
            settings.CefCommandLineArgs.Add("no-proxy-server", "1");


            //Cef.Initialize(settings);
            return settings;
        }

    }
}
