﻿#region License
/******************************************************************************
* Copyright 2018-2021 The AutoCore Authors. All Rights Reserved.
* 
* Licensed under the GNU Lesser General Public License, Version 3.0 (the "License"); 
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
* 
* https://www.gnu.org/licenses/lgpl-3.0.html
* 
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*****************************************************************************/
#endregion


using AutoCore.MapToolbox.PCL;
using UnityEditor;
using UnityEngine.UIElements;

namespace AutoCore.MapToolbox.Editor.PCL
{
    class IntensitySampleRangeEditor : SettingsProvider
    {
        public static float min = Externs.IntensityPrecentMin;
        public static float max = Externs.IntensityPrecentMax;
        public static float width = Externs.DefaultWidth;
        public static float speed_limit = Externs.DefaultSpeedLimit;
        public IntensitySampleRangeEditor(string path, SettingsScope scopes) : base(path, scopes) { }
        [SettingsProvider] static SettingsProvider Project() => new IntensitySampleRangeEditor("Project/MapToolbox", SettingsScope.Project);
        public override void OnGUI(string searchContext)
        {
            base.OnGUI(searchContext);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.MinMaxSlider("Intensity range to color", ref min, ref max, 0, 100);
            EditorGUILayout.LabelField($"    {min:f3}%-{max:f3}%");
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.FloatField("Default width", width);
            EditorGUILayout.FloatField("Default speed Limit", speed_limit);
        }
        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            min = Externs.IntensityPrecentMin;
            max = Externs.IntensityPrecentMax;
            width = Externs.DefaultWidth;
            speed_limit = Externs.DefaultSpeedLimit;
        }
        public override void OnDeactivate()
        {
            base.OnDeactivate();
            Externs.IntensityPrecentMin = min;
            Externs.IntensityPrecentMax = max;
            Externs.DefaultWidth = width;
            Externs.DefaultSpeedLimit = speed_limit;
        }
    }
}