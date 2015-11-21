﻿/// Copyright(C) 2015 Unforbidable Works
///
/// This program is free software; you can redistribute it and/or
/// modify it under the terms of the GNU General Public License
/// as published by the Free Software Foundation; either version 2
/// of the License, or(at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
/// GNU General Public License for more details.
///
/// You should have received a copy of the GNU General Public License
/// along with this program; if not, write to the Free Software
/// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using Patcher.UI.CommandLine;
using Patcher.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patcher
{
    [Usage("patcher [--data=\"Data\"] [--rules=\"MyRules\"]\n[--output=\"MyPlugin.esp\"] [--author=\"Me\"] [--keepdirtyedits[=true|=false]]")]
    public class ProgramOptions : Options
    {
        [Option("data", 'd')]
        [DefaultValue("..")]
        [Description("Path to the game data folder.\nA path relative to the executable is allowed.\nDefault: ..")]
        public string DataFolder { get; private set; }

        [Option("rules", 'r')]
        [DefaultValue("default")]
        [Description("Name of the folder contaning rules to run that is\nlocated in Patcher\\rules\nin the game data folder.\nDefault: default")]
        public string RulesFolder { get; private set; }

        [Option("output", 'o')]
        [Description("Name of the created plugin file. The file\nwill be created in the game data folder.\nDefault: Patcher-default.esp")]
        public string OutputFilename { get; private set; }

        [Option("author")]
        [Description("Author name written to the generated plugin.\nDefault: Patcher 1.x.x")]
        public string Author { get; private set; }

        [Option("description")]
        [Description("Description written to the generated plugin.\nDefault: Generated by Patcher 1.x.x")]
        public string Description { get; private set; }

        [Option("param")]
        [Description("Define a parameter name and value - plugin_name/name:value")]
        public List<string> Parameters { get; set; }

        [Option("exitwhendone")]
        [Description("Close the window automatically when everything is sucessfully done.")]
        [DefaultValue(false)]
        public bool ExitWhenDone { get; set; }

        [Option("plugins")]
        [Description("Path to plugins.txt file to load.\nDefault: The game default location")]
        public string PluginListFile { get; private set; }

        [Option("mo-profile")]
        [Description("Path to Mod Organizer profile.")]
        public string ModOrganizerProfile { get; set; }

        [Option("mo-mods")]
        [Description("Path to Mod Organizer mods folder.\nThere is no need to specify this path unless\na non-default path has been configured.")]
        public string ModOrganizerModsPath { get; set; }

        [Option("keepdirtyedits")]
        [Description("Do not purge overriding forms that are\nidentical to the original form.\nDefault: false")]
        [DefaultValue(false)]
        public bool KeepDirtyEdits { get; private set; }

        [Option("maxloadingthreads")]
        [Description("Specifies the maximum background workers\nused during the loading of form data. Set to zero to disable assynchronous loading.\nDefault: 2")]
        [DefaultValue(2)]
        public int MaxLoadingThreads { get; set; }

        [Option("debug", 'D')]
        [Description("Enable debug mode within specified scope:\n* - Everything\nplugin_file_name\n  - All rules of a plugin\nplugin_file_name/rule_file\n  - All rules loaded from a rule file\nDefault: Disabled")]
        public string DebugScope { get; private set; }

        [Option("consoleloglevel", 'L')]
        [Description("Minimal message log level that will be\ndisplayed on the screen.\nNote that the complete long will be saved\nto the Data folder.\n0 - Show no messages (not recommended)\n1 - Show errors only\n2 - Show errors and warnings\n3 - Show the above and general messages (recommended)\n4 - Show all messages\nDefault: 3")]
        [DefaultValue((int)LogLevel.Info)]
        public int ConsoleLogLevel { get; private set; }

        [Option("consolewidth")]
        [Description("Set the width of the console to given number of\ncolumns.\nDefault: 80")]
        [DefaultValue(0)]
        [Obsolete]
        public int WindowWidth { get; set; }

        [Option("consoleheight")]
        [Description("Set the height of the console to given number of\nrows.\nDefault: 20")]
        [DefaultValue(0)]
        [Obsolete]
        public int WindowHeight { get; set; }

        [Option("maximize")]
        [Description("Open the main window maximized.\nDefault: false")]
        [DefaultValue(false)]
        public bool StartWindowMaximized { get; set; }

        [Option("minimize")]
        [Description("Open the main window minimized.\nDefault: false")]
        [DefaultValue(false)]
        public bool StartWindowMinimized { get; set; }

        [Option("version")]
        [Description("Print the program version information.")]
        [DefaultValue(false)]
        public bool PrintVersion { get; private set; }

    }
}
