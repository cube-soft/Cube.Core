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
using System.Threading;
using System.Threading.Tasks;
using Cube.Mixin.Observing;
using Cube.Mixin.Syntax;
using NUnit.Framework;

namespace Cube.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// PresentableTest
    ///
    /// <summary>
    /// Tests the PresentableBase and related classes.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class PresentableTest
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Create_Throws
        ///
        /// <summary>
        /// Tests to create a new instance of the PresentableBase inherited
        /// class when the SynchronizationContext.Current is null.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Create_Throws()
        {
            Assert.That(SynchronizationContext.Current, Is.Null);
            Assert.That(() => new Presenter(), Throws.ArgumentNullException);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Subscribe
        ///
        /// <summary>
        /// Tests the Subscribe and Send methods.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Subscribe()
        {
            var n = 0;
            void action(int i) => ++n;

            using var src = new Presenter(new());
            using (src.Subscribe<int>(action))
            using (src.Subscribe<int>(action))
            {
                5.Times(i => src.SendMessage<int>());
                Assert.That(n, Is.EqualTo(10));

                5.Times(i => src.SendMessage<long>());
                Assert.That(n, Is.EqualTo(10));
            }

            5.Times(i => src.SendMessage<int>());
            Assert.That(n, Is.EqualTo(10));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Post
        ///
        /// <summary>
        /// Tests the Subscribe and Post methods.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Post()
        {
            var cts = new CancellationTokenSource();
            using (var src = new Presenter(new()))
            using (src.Subscribe<int>(e => cts.Cancel()))
            {
                src.PostMessage<int>();
                Assert.That(() => Wait(cts), Throws.TypeOf<AggregateException>());
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Track
        ///
        /// <summary>
        /// Tests the Track method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Track()
        {
            var dest = default(DialogMessage);
            using (var src = new Presenter(new()))
            using (src.Subscribe<DialogMessage>(e => dest = e))
            {
                src.TrackAsync(() => { /* OK */ });
                src.TrackSync(() => throw new OperationCanceledException("Ignore"));
                src.TrackSync(() => throw new ArgumentException(nameof(Track)));
            }

            Assert.That(dest.Text,    Does.StartWith(nameof(Track)));
            Assert.That(dest.Title,   Is.Not.Null.And.Not.Empty);
            Assert.That(dest.Icon,    Is.EqualTo(DialogIcon.Error));
            Assert.That(dest.Buttons, Is.EqualTo(DialogButtons.Ok));
            Assert.That(dest.Value,   Is.EqualTo(DialogStatus.Ok));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Track_Sequence
        ///
        /// <summary>
        /// Tests the Track method with multiple actions.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Track_Sequence()
        {
            var n = 0;
            using (var src = new Presenter(new()))
            using (src.Subscribe<DialogMessage>(e => n++))
            {
                src.TrackAsync(() => throw new ArgumentException(), () => n++);
                Task.Delay(200).Wait();
            }
            Assert.That(n, Is.EqualTo(2));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Track_Message
        ///
        /// <summary>
        /// Tests the Track method with objects of Message inherited class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Track_Message()
        {
            var n = 0;
            using (var src = new Presenter(new()))
            {
                3.Times(i => src.TrackAsync(new DialogMessage(), e => n++));
                Task.Delay(300).Wait();
            }
            Assert.That(n, Is.EqualTo(3));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Track_CancelMessage
        ///
        /// <summary>
        /// Tests the Track method with objects of CancelMessage inherited
        /// class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(true,  ExpectedResult = 0)]
        [TestCase(false, ExpectedResult = 2)]
        public int Track_CancelMessage(bool cancel)
        {
            var n = 0;
            using (var src = new Presenter(new()))
            using (src.Subscribe<OpenFileMessage>(e => e.Cancel = cancel))
            {
                2.Times(i => src.TrackAsync(new OpenFileMessage(), e => n++));
                Task.Delay(200).Wait();
            }
            return n;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Send_Throws
        ///
        /// <summary>
        /// Tests the Send method with a null object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Send_Throws()
        {
            using var src = new Presenter(new());
            Assert.That(() => src.SendMessage(default(object)), Throws.ArgumentNullException);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PropertyChanged
        ///
        /// <summary>
        /// Tests the PropertyChanged event.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void PropertyChanged()
        {
            var n   = 0;
            var cts = new CancellationTokenSource();
            using var src = new Presenter(new());
            5.Times(i => src.Value = nameof(PropertyChanged));
            Assert.That(src.Value, Is.EqualTo(nameof(PropertyChanged)));
            Assert.That(n, Is.EqualTo(0));

            src.Value = string.Empty;
            src.PropertyChanged += (s, e) => { ++n; cts.Cancel(); };
            5.Times(i => src.Value = nameof(PropertyChanged));
            Assert.That(() => Wait(cts), Throws.TypeOf<AggregateException>());
            Assert.That(src.Value, Is.EqualTo(nameof(PropertyChanged)));
            Assert.That(n, Is.EqualTo(1));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetDispatcher
        ///
        /// <summary>
        /// Tests the GetDispatcher method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void GetDispatcher()
        {
            using var src = new Presenter(new());
            Assert.That(src.GetDispatcher(), Is.Not.Null);
        }

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Wait
        ///
        /// <summary>
        /// Waits for the test result.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Wait(CancellationTokenSource cts) => Task.Delay(10000, cts.Token).Wait();

        /* ----------------------------------------------------------------- */
        ///
        /// Presenter
        ///
        /// <summary>
        /// Represents the presenter for testing.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private class Presenter : Presentable<Person>
        {
            public Presenter() : base(new()) { Observe(); }
            public Presenter(SynchronizationContext ctx) : base(new(), new(), ctx) {
                Assert.That(Context, Is.Not.Null);
                Observe();
            }
            public void PostMessage<T>() where T : new() => Post<T>();
            public void SendMessage<T>() where T : new() => Send<T>();
            public void SendMessage<T>(T m) => Send(m);
            public void TrackSync(Action e) => Track(e, true);
            public void TrackAsync(params Action[] e) => Track(e);
            public void TrackAsync<T>(Message<T> m, Action<T> e) => Track(m, e);
            public void TrackAsync<T>(CancelMessage<T> m, Action<T> e) => Track(m, e);
            public Dispatcher GetDispatcher() => GetDispatcher(false);
            private void Observe() { Assets.Add(Facade.Subscribe(e => { })); }
            public string Value { get => Get<string>(); set => Set(value); }
        }

        #endregion
    }
}
