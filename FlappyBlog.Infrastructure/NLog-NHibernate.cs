using System;
using NHibernate;
using NLog;

namespace FlappyBlog.Infrastructure
{
	///Add <add key="nhibernate-logger" value="MyNamespace.NLogFactory, MyAssemblyName"/>
    
    public class NLogFactory : ILoggerFactory
    {
        #region ILoggerFactory Members

        public IInternalLogger LoggerFor(Type type)
        {
            return new NLogLogger(LogManager.GetLogger(type.FullName));
        }

        public IInternalLogger LoggerFor(string keyName)
        {
            return new NLogLogger(LogManager.GetLogger(keyName));
        }

        #endregion
    }

    public class NLogLogger : IInternalLogger
    {
        private readonly Logger _logger;

        public NLogLogger(Logger logger)
        {
            _logger = logger;
        }

        #region Properties

        public bool IsDebugEnabled { get { return _logger.IsDebugEnabled; } }

        public bool IsErrorEnabled { get { return _logger.IsErrorEnabled; } }

        public bool IsFatalEnabled { get { return _logger.IsFatalEnabled; } }

        public bool IsInfoEnabled { get { return _logger.IsInfoEnabled; } }

        public bool IsWarnEnabled { get { return _logger.IsWarnEnabled; } }

        #endregion

        #region IInternalLogger Methods

        public void Debug(object message, Exception exception)
        {
            _logger.DebugException(message.ToString(), exception);
        }

        public void Debug(object message)
        {
            _logger.Debug(message.ToString());
        }

        public void DebugFormat(string format, params object[] args)
        {
            _logger.Debug(String.Format(format, args));
        }

        public void Error(object message, Exception exception)
        {
            _logger.ErrorException(message.ToString(), exception);
        }

        public void Error(object message)
        {
            _logger.Error(message.ToString());
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _logger.Error(String.Format(format, args));
        }

        public void Fatal(object message, Exception exception)
        {
            _logger.FatalException(message.ToString(), exception);
        }

        public void Fatal(object message)
        {
            _logger.Fatal(message.ToString());
        }

        public void Info(object message, Exception exception)
        {
            _logger.InfoException(message.ToString(), exception);
        }

        public void Info(object message)
        {
            _logger.Info(message.ToString());
        }

        public void InfoFormat(string format, params object[] args)
        {
            _logger.Info(String.Format(format, args));
        }

        public void Warn(object message, Exception exception)
        {
            _logger.WarnException(message.ToString(), exception);
        }

        public void Warn(object message)
        {
            _logger.Warn(message.ToString());
        }

        public void WarnFormat(string format, params object[] args)
        {
            _logger.Warn(String.Format(format, args));
        }

        #endregion
    }
}