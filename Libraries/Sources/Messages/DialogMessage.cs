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

namespace Cube
{
    #region DialogMessage

    /* --------------------------------------------------------------------- */
    ///
    /// DialogMessage
    ///
    /// <summary>
    /// Represents the message that is sent when showing a message box.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class DialogMessage : Message<string>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// DialogMessage
        ///
        /// <summary>
        /// Initializes a new instance of the DialogMessage class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public DialogMessage() { Value = string.Empty; }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Icon
        ///
        /// <summary>
        /// Gets or sets the icon that is displayed by a message box.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public DialogIcon Icon { get; set; } = DialogIcon.Error;

        /* ----------------------------------------------------------------- */
        ///
        /// Buttons
        ///
        /// <summary>
        /// Gets or sets the kind of buttons that are displayed by a
        /// message box.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public DialogButtons Buttons { get; set; } = DialogButtons.Ok;

        /* ----------------------------------------------------------------- */
        ///
        /// Status
        ///
        /// <summary>
        /// Gets or sets the button that is clicked by a user.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public DialogStatus Status { get; set; } = DialogStatus.Ok;

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// Creates a new instance of the DialogMessage class with the
        /// specified exception.
        /// </summary>
        ///
        /// <param name="src">Exception object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static DialogMessage Create(Exception src) => new DialogMessage
        {
            Title   = "Error",
            Value   = $"{src.Message} ({src.GetType().Name})",
            Icon    = DialogIcon.Error,
            Buttons = DialogButtons.Ok,
            Status  = DialogStatus.Ok,
        };

        #endregion
    }

    #endregion

    #region DialogIcon

    /* --------------------------------------------------------------------- */
    ///
    /// DialogIcon
    ///
    /// <summary>
    /// Specifies the icon that is displayed by a message box.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public enum DialogIcon
    {
        /// <summary>The message box contains no symbols.</summary>
        None = 0,
        /// <summary>The message box contains a symbol consisting of white X in a circle with a red background.</summary>
        Error = 16,
        /// <summary>The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.</summary>
        Warning = 48,
        /// <summary>The message box contains a symbol consisting of a lowercase letter i in a circle.</summary>
        Information = 64,
    }

    #endregion

    #region DialogButtons

    /* --------------------------------------------------------------------- */
    ///
    /// DialogButtons
    ///
    /// <summary>
    /// Specifies the kind of buttons that are displayed by a message box.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public enum DialogButtons
    {
        /// <summary>The message box displays an OK button.</summary>
        Ok = 0,
        /// <summary>The message box displays OK and Cancel buttons.</summary>
        OkCancel = 1,
        /// <summary>The message box displays Yes and No buttons.</summary>
        YesNo = 4,
        /// <summary>The message box displays Yes, No, and Cancel buttons.</summary>
        YesNoCancel = 3,
    }

    #endregion

    #region DialogStatus

    /* --------------------------------------------------------------------- */
    ///
    /// DialogStatus
    ///
    /// <summary>
    /// Specifies the button that is clicked by a user.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public enum DialogStatus
    {
        /// <summary>The message box returns no result.</summary>
        None = 0,
        /// <summary>The result value of the message box is OK.</summary>
        Ok = 1,
        /// <summary>The result value of the message box is Cancel.</summary>
        Cancel = 2,
        /// <summary>The result value of the message box is Yes.</summary>
        Yes = 6,
        /// <summary>The result value of the message box is No.</summary>
        No = 7,
    }

    #endregion
}