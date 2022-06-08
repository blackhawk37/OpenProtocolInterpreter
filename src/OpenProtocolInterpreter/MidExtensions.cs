﻿using OpenProtocolInterpreter.Communication;
using System;
using System.Linq;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Mid Extensions functions
    /// </summary>
    public static class MidExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TMid"></typeparam>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static Mid0005 GetAcceptCommand<TMid>(this TMid mid) where TMid : Mid, IAcceptableCommand
        {
            return new Mid0005(mid.Header.Mid);
        }

        /// <summary>
        /// Generates a Communication Negative Acknowledge mid (<see cref="Mid0004"/>) instance for the failed mid and with the informed error code.
        /// </summary>
        /// <typeparam name="TMid"><see cref="Mid"/> instance and <see cref="IDeclinableCommand"/> implementer</typeparam>
        /// <param name="mid">Current failed mid</param>
        /// <param name="error"><see cref="Mid0004"/> error code</param>
        /// <returns>A new <see cref="Mid0004"/> instance</returns>
        public static Mid0004 GetDeclineCommand<TMid>(this TMid mid, Error error) where TMid : Mid, IDeclinableCommand
        {
            return new Mid0004(mid.Header.Mid, error);
        }

        /// <summary>
        /// Assert that error code is a possible error for the current failed mid and generates a Communication Negative Acknowledge mid (<see cref="Mid0004"/>) 
        /// instance for the failed mid and with the informed error code.
        /// </summary>
        /// <typeparam name="TMid"><see cref="Mid"/> instance and <see cref="IDeclinableCommand"/> implementer</typeparam>
        /// <param name="mid">Current failed mid</param>
        /// <param name="error"><see cref="Mid0004"/> error code</param>
        /// <returns>A new <see cref="Mid0004"/> instance</returns>
        /// <exception cref="ArgumentException">Throws if error is not a possible error for the current failed Mid</exception>
        public static Mid0004 AssertAndGetDeclineCommand<TMid>(this TMid mid, Error error) where TMid : Mid, IDeclinableCommand
        {
            if (!mid.PossibleErrors.Contains(error))
            {
                throw new ArgumentException($"{error} is not a possible error for {mid.Header.Mid}");
            }

            return mid.GetDeclineCommand(error);
        }

        /// <summary>
        /// <see cref="Mid.Pack()"/> then concatenate NUL charactor to it`s end
        /// </summary>
        /// <param name="mid">Mid instance</param>
        /// <returns>Mid's package in string with NUL character</returns>
        public static string PackWithNul(this Mid mid)
        {
            if (mid == default)
            {
                return default;
            }

            var value = mid.Pack();
            return string.Concat(value, '\0');
        }

        /// <summary>
        /// <see cref="Mid.PackBytes()"/> then concatenate NUL charactor to it`s end
        /// </summary>
        /// <param name="mid">Mid instance</param>
        /// <returns>Mid's package in bytes with NUL character</returns>
        public static byte[] PackBytesWithNul(this Mid mid)
        {
            if (mid == default)
            {
                return default;
            }

            var bytes = mid.PackBytes();
            return bytes.Concat(new byte[] { 0x00 }).ToArray();
        }
    }
}