﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patcher.Logging;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Patcher.UI.Windows
{
    sealed class WindowDisplay : IDisplay
    {
        readonly Application app = new App();
        MainWindow window = new MainWindow();

        internal MainWindow Window { get { return window; } }

        public WindowDisplay()
        {
        }

        public Logger GetLogger(LogLevel maxLogLevel)
        {
            return new WindowLogger(this, maxLogLevel);
        }

        public Prompt GetPrompt()
        {
            return new WindowPrompt(this);
        }

        public Status GetStatus()
        {
            return new WindowStatus(this);
        }

        public void Run(Task task)
        {
            task.Start();
            app.Run(window);
        }

        public void SetWindowHeight(int windowHeight)
        {
            window.Height = windowHeight * 12;
        }

        public void SetWindowWidth(int windowWidth)
        {
            window.Width = windowWidth * 6;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Patcher");
        }

        public void Shutdown()
        {
            Window.WriteMessage(Brushes.Purple, "");
            Window.WriteMessage(Brushes.Purple, "Press any key to quit.");
            Window.TerminateOnKey = true;
        }
    }
}