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
namespace System.Collections.Generic
{
    #region IReadOnlyCollection<T>

    /* --------------------------------------------------------------------- */
    ///
    /// IReadOnlyCollection(T)
    ///
    /// <summary>
    /// Represents a strongly-typed, read-only collection of elements.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public interface IReadOnlyCollection<T> : IEnumerable<T>, IEnumerable
    {
        /* ----------------------------------------------------------------- */
        ///
        /// Count
        ///
        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        int Count { get;  }
    }

    #endregion

    #region IReadOnlyList<T>

    /* --------------------------------------------------------------------- */
    ///
    /// IReadOnlyList(T)
    ///
    /// <summary>
    /// Represents a read-only collection of elements that can be accessed
    /// by index.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public interface IReadOnlyList<T> : IReadOnlyCollection<T>,
        IEnumerable<T>, IEnumerable
    {
        /* ----------------------------------------------------------------- */
        ///
        /// Item
        ///
        /// <summary>
        /// Gets the element at the specified index in the read-only list.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        T this[int index] { get; }
    }

    #endregion
}