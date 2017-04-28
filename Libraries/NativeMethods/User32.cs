﻿/* ------------------------------------------------------------------------- */
///
/// Copyright (c) 2010 CubeSoft, Inc.
/// 
/// Licensed under the Apache License, Version 2.0 (the "License");
/// you may not use this file except in compliance with the License.
/// You may obtain a copy of the License at
///
///  http://www.apache.org/licenses/LICENSE-2.0
///
/// Unless required by applicable law or agreed to in writing, software
/// distributed under the License is distributed on an "AS IS" BASIS,
/// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
/// See the License for the specific language governing permissions and
/// limitations under the License.
///
/* ------------------------------------------------------------------------- */
using System;
using System.Runtime.InteropServices;

namespace Cube.User32
{
    internal static class NativeMethods
    {
        /* ----------------------------------------------------------------- */
        ///
        /// SetForegroundWindow
        /// 
        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633539.aspx
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DllImport(LibName, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /* ----------------------------------------------------------------- */
        ///
        /// SetForegroundWindow
        /// 
        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633549.aspx
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DllImport(LibName, SetLastError = true)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        /* ----------------------------------------------------------------- */
        ///
        /// IsIconic
        /// 
        /// <summary>
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms633527.aspx
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [DllImport(LibName)]
        public static extern bool IsIconic(IntPtr hWnd);

        #region Fields
        const string LibName = "user32.dll";
        #endregion
    }
}