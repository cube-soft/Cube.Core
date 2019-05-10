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
using Cube.Mixin.Collections;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cube.Tests.Mixin
{
    /* --------------------------------------------------------------------- */
    ///
    /// EnumerableTest
    ///
    /// <summary>
    /// Tests extended methods of the IEnumerable(T) class.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class EnumerableTest
    {
        #region Tests

        #region GetOrEmpty

        /* ----------------------------------------------------------------- */
        ///
        /// GetOrEmpty
        ///
        /// <summary>
        /// Tests of the GetOrDefault extended method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void GetOrEmpty()
        {
            var sum = 0;
            var src = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (var i in src.GetOrEmpty()) sum += i;
            Assert.That(sum, Is.EqualTo(55));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetOrEmpty_Null
        ///
        /// <summary>
        /// Tests of the GetOrDefault extended method with the null object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void GetOrEmpty_Null()
        {
            var sum = 0;
            var src = default(List<int>);
            foreach (var i in src.GetOrEmpty()) sum += i;
            Assert.That(sum, Is.EqualTo(0));
        }

        #endregion

        #region FirstIndex

        /* ----------------------------------------------------------------- */
        ///
        /// FirstIndex
        ///
        /// <summary>
        /// Tests the FirstIndex method at the specified condition.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void FirstIndex()
        {
            var src = Enumerable.Range(1, 50).Select(e => e * 2);
            Assert.That(src.FirstIndex(e => e < 20), Is.EqualTo(0));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FirstIndex_Empty
        ///
        /// <summary>
        /// Tests the FirstIndex method against the empty List(T) object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void FirstIndex_Empty()
        {
            var src = Enumerable.Empty<int>();
            Assert.That(() => src.FirstIndex(e => e < 20), Throws.TypeOf<InvalidOperationException>());
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FirstIndex_Default
        ///
        /// <summary>
        /// Tests the FirstIndex method against the default of List(T).
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void FirstIndex_Default()
        {
            var src = default(List<int>);
            Assert.That(() => src.FirstIndex(e => e < 20), Throws.TypeOf<ArgumentNullException>());
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FirstIndex_NeverMatch
        ///
        /// <summary>
        /// Tests the FirstIndex method with the never-matched predicate.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void FirstIndex_NeverMatch()
        {
            var src = Enumerable.Range(1, 10);
            Assert.That(() => src.FirstIndex(e => e > 100), Throws.TypeOf<InvalidOperationException>());
        }

        #endregion

        #region FirstIndexOf

        /* ----------------------------------------------------------------- */
        ///
        /// FirstIndexOf
        ///
        /// <summary>
        /// Tests the FirstIndexOf method at the specified condition.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void FirstIndexOf()
        {
            var src = Enumerable.Range(1, 50).Select(e => e * 2);
            Assert.That(src.FirstIndexOf(e => e < 20), Is.EqualTo(0));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FirstIndexOf_Empty
        ///
        /// <summary>
        /// Tests the FirstIndexOf method against the empty List(T) object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void FirstIndexOf_Empty()
        {
            var src = Enumerable.Empty<int>();
            Assert.That(src.FirstIndexOf(e => e < 20), Is.EqualTo(-1));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FirstIndexOf_Default
        ///
        /// <summary>
        /// Tests the FirstIndexOf method against the default of List(T).
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void FirstIndexOf_Default()
        {
            var src = default(List<int>);
            Assert.That(src.FirstIndexOf(e => e < 20), Is.EqualTo(-1));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// FirstIndexOf_NeverMatch
        ///
        /// <summary>
        /// Tests the FirstIndexOf method with the never-matched predicate.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void FirstIndexOf_NeverMatch()
        {
            var src = Enumerable.Range(1, 10);
            Assert.That(src.FirstIndexOf(e => e > 100), Is.EqualTo(-1));
        }

        #endregion

        #region LastIndex

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndex
        ///
        /// <summary>
        /// Tests the LastIndex method at the specified condition.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(10, ExpectedResult = 9)]
        [TestCase( 1, ExpectedResult = 0)]
        public int LastIndex(int count) => Enumerable.Range(0, count).LastIndex();

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndex
        ///
        /// <summary>
        /// Tests the LastIndex method at the specified condition.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LastIndex()
        {
            var src = Enumerable.Range(1, 50).Select(e => e * 2);
            Assert.That(src.LastIndex(e => e < 20), Is.EqualTo(8));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndex_Empty
        ///
        /// <summary>
        /// Tests the LastIndex method against the empty List(T) object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LastIndex_Empty() => Assert.That(
            () => new List<int>().LastIndex(),
            Throws.TypeOf<InvalidOperationException>()
        );

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndex_Default
        ///
        /// <summary>
        /// Tests the LastIndex method against the default of List(T).
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LastIndex_Default()
        {
            var src = default(List<int>);
            Assert.That(() => src.LastIndex(), Throws.TypeOf<ArgumentNullException>());
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndex_NeverMatch
        ///
        /// <summary>
        /// Tests the LastIndex method with the never-matched predicate.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LastIndex_NeverMatch()
        {
            var src = Enumerable.Range(1, 10);
            Assert.That(() => src.LastIndex(e => e > 100), Throws.TypeOf<InvalidOperationException>());
        }

        #endregion

        #region LastIndexOf

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndexOf
        ///
        /// <summary>
        /// Tests the LastIndexOf method at the specified condition.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(10, ExpectedResult =  9)]
        [TestCase( 1, ExpectedResult =  0)]
        [TestCase( 0, ExpectedResult = -1)]
        public int LastIndexOf(int count) => Enumerable.Range(0, count).LastIndexOf();

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndexOf
        ///
        /// <summary>
        /// Tests the LastIndexOf method at the specified condition.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LastIndexOf()
        {
            var src = Enumerable.Range(1, 50).Select(e => e * 2);
            Assert.That(src.LastIndexOf(e => e < 20), Is.EqualTo(8));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndexOf_Default
        ///
        /// <summary>
        /// Tests the LastIndexOf method against the default of List(T).
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LastIndexOf_Default()
        {
            var src = default(List<int>);
            Assert.That(src.LastIndexOf(), Is.EqualTo(-1));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// LastIndexOf_NeverMatch
        ///
        /// <summary>
        /// Tests the LastIndexOf method with the never-matched predicate.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void LastIndexOf_NeverMatch()
        {
            var src = Enumerable.Range(1, 10);
            Assert.That(src.LastIndexOf(e => e > 100), Is.EqualTo(-1));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Clamp
        ///
        /// <summary>
        /// Tests the Clamp method at the specified condition.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(10,  5, ExpectedResult = 5)]
        [TestCase(10, 20, ExpectedResult = 9)]
        [TestCase(10, -1, ExpectedResult = 0)]
        [TestCase( 0, 10, ExpectedResult = 0)]
        [TestCase( 0, -1, ExpectedResult = 0)]
        public int Clamp(int count, int index) => Enumerable.Range(0, count).Clamp(index);

        /* ----------------------------------------------------------------- */
        ///
        /// Clamp_Default
        ///
        /// <summary>
        /// Tests the Clamp method against the default of List(T).
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Clamp_Default()
        {
            var src = default(List<int>);
            Assert.That(src.Clamp(100), Is.EqualTo(0));
        }

        #endregion

        #region Compact

        /* ----------------------------------------------------------------- */
        ///
        /// Compact
        ///
        /// <summary>
        /// Executes the test of the Compact extended method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Compact()
        {
            var src = new[] { "Hello", "world!", string.Empty, null };
            Assert.That(src.Length,            Is.EqualTo(4));
            Assert.That(src.Compact().Count(), Is.EqualTo(3));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Compact_ValueType
        ///
        /// <summary>
        /// Executes the test of the Compact extended method with the
        /// value type collection.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Compact_ValueType()
        {
            var src = new[] { 3, 1, 4, 1, 5 };
            Assert.That(src.Length,            Is.EqualTo(5));
            Assert.That(src.Compact().Count(), Is.EqualTo(5));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Compact_ValueType
        ///
        /// <summary>
        /// Executes the test of the Compact extended method with the
        /// empty collection.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Compact_Empty()
        {
            var src = Enumerable.Empty<int>();
            Assert.That(src.Count(),           Is.EqualTo(0));
            Assert.That(src.Compact().Count(), Is.EqualTo(0));
        }

        #endregion

        #region Flatten

        /* ----------------------------------------------------------------- */
        ///
        /// Flatten
        ///
        /// <summary>
        /// Tests the Flatten extended method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Flatten()
        {
            var src = new[]
            {
                new Tree { Name = "1st" },
                new Tree
                {
                    Name     = "2nd",
                    Children = new[]
                    {
                        new Tree
                        {
                            Name     = "2nd-1st",
                            Children = new[] { new Tree { Name = "2nd-1st-1st" } },
                        },
                        new Tree { Name = "2nd-2nd" },
                        new Tree
                        {
                            Name     = "2nd-3rd",
                            Children = new[]
                            {
                                new Tree { Name = "2nd-3rd-1st" },
                                new Tree { Name = "2nd-3rd-2nd" },
                            },
                        },
                    },
                },
                new Tree { Name = "3rd" },
            };

            var dest = src.Flatten(e => e.Children).ToList();
            Assert.That(dest.Count, Is.EqualTo(9));
            Assert.That(dest[0].Name, Is.EqualTo("1st"));
            Assert.That(dest[1].Name, Is.EqualTo("2nd"));
            Assert.That(dest[2].Name, Is.EqualTo("3rd"));
            Assert.That(dest[3].Name, Is.EqualTo("2nd-1st"));
            Assert.That(dest[4].Name, Is.EqualTo("2nd-2nd"));
            Assert.That(dest[5].Name, Is.EqualTo("2nd-3rd"));
            Assert.That(dest[6].Name, Is.EqualTo("2nd-1st-1st"));
            Assert.That(dest[7].Name, Is.EqualTo("2nd-3rd-1st"));
            Assert.That(dest[8].Name, Is.EqualTo("2nd-3rd-2nd"));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Flatten_Empty
        ///
        /// <summary>
        /// Tests the Flatten extended method with the empty array.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Flatten_Empty()
        {
            var src = Enumerable.Empty<Tree>();
            Assert.That(src.Flatten(e => e.Children).Count(), Is.EqualTo(0));
        }

        #endregion

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Tree
        ///
        /// <summary>
        /// Represents the tree structure.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        class Tree
        {
            public string Name { get; set; }
            public IEnumerable<Tree> Children { get; set; }
        }

        #endregion
    }
}
