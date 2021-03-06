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

using Patcher.Data.Plugins.Content.Fields.Skyrim;
using Patcher.Rules.Compiled.Fields.Skyrim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patcher.Rules.Compiled.Constants.Skyrim;
using Patcher.Rules.Compiled.Forms.Skyrim;
using Patcher.Rules.Compiled.Forms;

namespace Patcher.Rules.Proxies.Fields.Skyrim
{
    [Proxy(typeof(IWeatherSound))]
    public sealed class WeatherSoundProxy : FieldProxy<WeatherSoundItem>, IWeatherSound
    {
        public IForm Sound
        {
            get
            {
                return Provider.CreateReferenceProxy<IForm>(Field.Sound);
            }

            set
            {
                EnsureWritable();
                Field.Sound = value.ToFormId();
            }
        }

        public WeatherSoundTypes Type
        {
            get
            {
                return Field.Type.ToWeatherSoundTypes();
            }

            set
            {
                EnsureWritable();
                Field.Type = value.ToWeatherSoundType();
            }
        }
    }
}
