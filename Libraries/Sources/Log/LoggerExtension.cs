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
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Cube.Log
{
    /* --------------------------------------------------------------------- */
    ///
    /// LoggerExtension
    ///
    /// <summary>
    /// Provides extended methods for logging.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public static class LoggerExtension
    {
        #region Methods

        #region LogDebug

        /* ----------------------------------------------------------------- */
        ///
        /// LogDebug
        ///
        /// <summary>
        /// Outputs log as DEBUG level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="message">Message string.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogDebug<T>(this T src, string message) =>
            Logger.Debug(src.GetType(), message);

        /* ----------------------------------------------------------------- */
        ///
        /// LogDebug
        ///
        /// <summary>
        /// Outputs log as DEBUG level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="error">Exception object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogDebug<T>(this T src, Exception error) =>
            Logger.Debug(src.GetType(), error);

        /* ----------------------------------------------------------------- */
        ///
        /// LogDebug
        ///
        /// <summary>
        /// Monitors the running time and outputs it as DEBUG level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="func">Function to monitor.</param>
        /// <param name="message">Method name of message.</param>
        ///
        /// <returns>Function result.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static U LogDebug<T, U>(this T src, Func<U> func,
            [CallerMemberName] string message = null) =>
            Logger.Debug(src.GetType(), func, message);

        /* ----------------------------------------------------------------- */
        ///
        /// LogDebug
        ///
        /// <summary>
        /// Monitors the running time and outputs it as DEBUG level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="action">Action to monitor.</param>
        /// <param name="message">Method name or message.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogDebug<T>(this T src, Action action,
            [CallerMemberName] string message = null) =>
            Logger.Debug(src.GetType(), action, message);

        #endregion

        #region LogInfo

        /* ----------------------------------------------------------------- */
        ///
        /// LogInfo
        ///
        /// <summary>
        /// Outputs log as INFO level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="message">Message string.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogInfo<T>(this T src, string message) =>
            Logger.Info(src.GetType(), message);

        /* ----------------------------------------------------------------- */
        ///
        /// LogInfo
        ///
        /// <summary>
        /// Outputs log as INFO level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="error">Exception object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogInfo<T>(this T src, Exception error) =>
            Logger.Info(src.GetType(), error);

        /* ----------------------------------------------------------------- */
        ///
        /// LogInfo
        ///
        /// <summary>
        /// Outputs system information as INFO level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="assembly">Assembly object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogInfo<T>(this T src, Assembly assembly) =>
            Logger.Info(src.GetType(), assembly);

        #endregion

        #region LogWarn

        /* ----------------------------------------------------------------- */
        ///
        /// LogWarn
        ///
        /// <summary>
        /// Outputs log as WARN level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="message">Message string.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogWarn<T>(this T src, string message) =>
            Logger.Warn(src.GetType(), message);

        /* ----------------------------------------------------------------- */
        ///
        /// LogWarn
        ///
        /// <summary>
        /// Outputs log as WARN level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="error">Exception object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogWarn<T>(this T src, Exception error) =>
            Logger.Warn(src.GetType(), error);

        /* ----------------------------------------------------------------- */
        ///
        /// LogWarn
        ///
        /// <summary>
        /// Outputs log as WARN level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="func">Function to monitor.</param>
        ///
        /// <returns>Function result.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static U LogWarn<T, U>(this T src, Func<U> func) =>
            LogWarn(src, func, default(U));

        /* ----------------------------------------------------------------- */
        ///
        /// LogWarn
        ///
        /// <summary>
        /// Outputs log as WARN level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="func">Function to monitor.</param>
        /// <param name="error">
        /// Value that returns when an exception occurs.
        /// </param>
        ///
        /// <returns>Function result.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static U LogWarn<T, U>(this T src, Func<U> func, U error) =>
            Logger.Warn(src.GetType(), func, error);

        /* ----------------------------------------------------------------- */
        ///
        /// LogWarn
        ///
        /// <summary>
        /// Outputs log as WARN level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="action">Function to monitor.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogWarn<T>(this T src, Action action) =>
            Logger.Warn(src.GetType(), action);

        #endregion

        #region LogError

        /* ----------------------------------------------------------------- */
        ///
        /// LogError
        ///
        /// <summary>
        /// Outputs log as ERROR level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="message">Message string.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogError<T>(this T src, string message) =>
            Logger.Error(src.GetType(), message);

        /* ----------------------------------------------------------------- */
        ///
        /// LogError
        ///
        /// <summary>
        /// Outputs log as ERROR level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="error">Exception object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogError<T>(this T src, Exception error) =>
            Logger.Error(src.GetType(), error);

        /* ----------------------------------------------------------------- */
        ///
        /// LogError
        ///
        /// <summary>
        /// Outputs log as ERROR level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="func">Function to monitor.</param>
        ///
        /// <returns>Function result.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static U LogError<T, U>(this T src, Func<U> func) =>
            LogError(src, func, default(U));

        /* ----------------------------------------------------------------- */
        ///
        /// LogError
        ///
        /// <summary>
        /// Outputs log as ERROR level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="func">Function to monitor.</param>
        /// <param name="err">
        /// Value that returns when an exception occurs.
        /// </param>
        ///
        /// <returns>Function result.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static U LogError<T, U>(this T src, Func<U> func, U err) =>
            Logger.Error(src.GetType(), func, err);

        /* ----------------------------------------------------------------- */
        ///
        /// LogError
        ///
        /// <summary>
        /// Outputs log as ERROR level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="action">Function to monitor.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogError<T>(this T src, Action action) =>
            Logger.Error(src.GetType(), action);

        #endregion

        #region LogFatal

        /* ----------------------------------------------------------------- */
        ///
        /// LogFatal
        ///
        /// <summary>
        /// Outputs log as FATAL level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="message">Message string.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogFatal<T>(this T src, string message) =>
            Logger.Fatal(src.GetType(), message);

        /* ----------------------------------------------------------------- */
        ///
        /// LogFatal
        ///
        /// <summary>
        /// Outputs log as FATAL level.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="error">Exception object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogFatal<T>(this T src, Exception error) =>
            Logger.Fatal(src.GetType(), error);

        /* ----------------------------------------------------------------- */
        ///
        /// LogFatal
        ///
        /// <summary>
        /// Outputs log as FATAL level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="func">Function to monitor.</param>
        ///
        /// <returns>Function result.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static U LogFatal<T, U>(this T src, Func<U> func) =>
            LogFatal(src, func, default(U));

        /* ----------------------------------------------------------------- */
        ///
        /// LogFatal
        ///
        /// <summary>
        /// Outputs log as FATAL level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="func">Function to monitor.</param>
        /// <param name="err">
        /// Value that returns when an exception occurs.
        /// </param>
        ///
        /// <returns>Function result.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static U LogFatal<T, U>(this T src, Func<U> func, U err) =>
            Logger.Fatal(src.GetType(), func, err);

        /* ----------------------------------------------------------------- */
        ///
        /// LogFatal
        ///
        /// <summary>
        /// Outputs log as FATAL level when an exception occurs.
        /// </summary>
        ///
        /// <param name="src">Targe object.</param>
        /// <param name="action">Function to monitor.</param>
        ///
        /* ----------------------------------------------------------------- */
        public static void LogFatal<T>(this T src, Action action) =>
            Logger.Fatal(src.GetType(), action);

        #endregion

        #endregion
    }
}