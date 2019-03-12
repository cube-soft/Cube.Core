﻿/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
using System;
using System.IO;

namespace Cube.FileSystem
{
    /* --------------------------------------------------------------------- */
    ///
    /// Refresher
    ///
    /// <summary>
    /// Implements the IRefresher interface by using the standard
    /// .NET Framework.
    /// </summary>
    ///
    /// <remarks>
    /// Information オブジェクトのプロパティは読み取り専用であるため、
    /// 外部から更新する事はできません。そのため、更新の際には
    /// Invoke メソッド経由で取得できるオブジェクトに対して更新処理を
    /// 実行する必要があります。
    /// </remarks>
    ///
    /* --------------------------------------------------------------------- */
    [Serializable]
    public class Refresher
    {
        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// Creates a new instance of the Refreshable class with the
        /// specified path.
        /// </summary>
        ///
        /// <param name="src">Source path.</param>
        ///
        /* ----------------------------------------------------------------- */
        public virtual Refreshable Create(string src)
        {
            var dest = new Refreshable(src);
            Invoke(dest);
            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Invoke
        ///
        /// <summary>
        /// Invokes the refresh operation.
        /// </summary>
        ///
        /// <param name="src">Object to be refreshed.</param>
        ///
        /* ----------------------------------------------------------------- */
        public virtual void Invoke(Refreshable src)
        {
            var obj = CreateCore(src.Source);

            src.Exists               = obj.Exists;
            src.Name                 = obj.Name;
            src.Extension            = obj.Extension;
            src.FullName             = obj.FullName;
            src.Attributes           = obj.Attributes;
            src.CreationTime         = obj.CreationTime;
            src.LastAccessTime       = obj.LastAccessTime;
            src.LastWriteTime        = obj.LastWriteTime;
            src.Length               = obj.Exists ? (TryCast(obj)?.Length ?? 0) : 0;
            src.IsDirectory          = obj is DirectoryInfo;
            src.NameWithoutExtension = Path.GetFileNameWithoutExtension(src.Source);
            src.DirectoryName        = TryCast(obj)?.DirectoryName ??
                                       Path.GetDirectoryName(src.Source);
        }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// CreateCore
        ///
        /// <summary>
        /// Creates a new instance of the FileSystemInfo class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private FileSystemInfo CreateCore(string path) =>
            Directory.Exists(path) ?
            new DirectoryInfo(path) as FileSystemInfo :
            new FileInfo(path) as FileSystemInfo;

        /* ----------------------------------------------------------------- */
        ///
        /// TryCast
        ///
        /// <summary>
        /// Tries to cast to the FileInfo class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private FileInfo TryCast(FileSystemInfo src) => src as FileInfo;

        #endregion
    }
}
