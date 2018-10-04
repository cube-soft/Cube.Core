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
using NUnit.Framework;

namespace Cube.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// PowerTest
    ///
    /// <summary>
    /// Tests for the Power class.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class PowerTest
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Subscribe
        ///
        /// <summary>
        /// Executes the test for observing the PowerModeChanged event.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(true,  ExpectedResult = 2)]
        [TestCase(false, ExpectedResult = 4)]
        public int Subscribe(bool ignore)
        {
            var mock = new PowerModeContext(Power.Mode);
            Power.Configure(mock);
            mock.IgnoreStatusChanged = ignore;

            var count  = 0;
            var powewr = Power.Subscribe(() => ++count);

            mock.Mode = PowerModes.Resume;       // Resume -> Resume
            mock.Mode = PowerModes.StatusChange; // Resume -> StatusChange
            mock.Mode = PowerModes.Suspend;      // StatusChange -> Suspend
            mock.Mode = PowerModes.Suspend;      // Suspend -> Suspend
            mock.Mode = PowerModes.StatusChange; // Suspend -> StatusChange
            mock.Mode = PowerModes.Resume;       // StatusChange -> Resume

            powewr.Dispose();

            mock.Mode = PowerModes.Suspend;
            mock.Mode = PowerModes.Resume;

            return count;
        }

        #endregion
    }
}
