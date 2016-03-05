﻿using Essentials.I18n;

namespace Essentials.Api.Command
{
    public class CommandResult
    {
        private static readonly CommandResult SUCCESS  = new CommandResult( null, ResultType.SUCCESS );
        private static readonly CommandResult SHOW_USAGE  = new CommandResult( null, ResultType.SHOW_USAGE );
        private static readonly CommandResult EMPTY  = new CommandResult( null, ResultType.EMPTY );
        private static readonly CommandResult INVALID_ARGS  = new CommandResult( null, ResultType.INVALID_ARGS );

        public string Message { get; }
        public ResultType Type { get; }

        /// <summary>
        /// Indicate that command was executed with success.
        /// </summary>
        /// <returns></returns>
        public static CommandResult Success()
            => SUCCESS;

        /// <summary>
        /// Commonly indicate that given arguments are invalid, or missing,
        /// and send the command 'Usage' to sender.
        /// </summary>
        /// <returns></returns>
        public static CommandResult ShowUsage()
            => SHOW_USAGE;

        /// <summary>
        /// Indicate that result of execution returned empty result.
        /// </summary>
        /// <returns></returns>
        public static CommandResult Empty()
            => EMPTY;

        /// <summary>
        /// Indicate that given arguments are invalid.
        /// </summary>
        /// <returns></returns>
        public static CommandResult InvalidArgs()
            => INVALID_ARGS;

        /// <summary>
        /// Indicate that given arguments are invalid, and send <paramref name="message"/>
        /// for the command sender.
        /// </summary>
        /// <param name="message">message for sender</param>
        /// <param name="args">Arguments of message</param>
        /// <returns></returns>
        public static CommandResult InvalidArgs( string message, params object[] args )
            => new CommandResult( string.Format( message, args ), ResultType.INVALID_ARGS );

        /// <summary>
        /// Commonly indicate that sender given an invalid argument 
        /// or something does not match the required.
        /// </summary>
        /// <param name="message">message for sender</param>
        /// <param name="args">Arguments of message</param>
        /// <returns></returns>
        public static CommandResult Error( string message, params object[] args ) 
            => new CommandResult( string.Format( message, args ), ResultType.ERROR );

        /// <summary>
        /// Commonly indicate that an given argument is invalid, and send the
        /// give <paramref name="lang"/> to sender.
        /// </summary>
        /// <param name="lang">Translation entry</param>
        /// <param name="args">Arguments of translation entry</param>
        /// <returns></returns>
        public static CommandResult Lang( EssLang lang, params object[] args )
            => new CommandResult( lang.GetMessage( args ), ResultType.LANG );

        /// <summary>
        /// Indicate that given arguments are invalid, and send <paramref name="message"/>
        /// for the command sender.
        /// </summary>
        /// <param name="message">message for sender</param>
        /// <param name="args">Arguments of message</param>
        /// <returns></returns>
        public static CommandResult Generic( string message, params object[] args )
            => new CommandResult( string.Format( message, args ), ResultType.GENERIC );


        public CommandResult( string message, ResultType type )
        {
            Message = message;
            Type = type;
        }

        public enum ResultType
        {
            SUCCESS,
            ERROR,
            SHOW_USAGE,
            LANG,
            GENERIC,
            EMPTY,
            INVALID_ARGS
        }
    }
}