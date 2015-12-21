using System;
using WhatsHoppening.Extensions;
using WhatsHoppening.Domain.ClientStorage;
using WhatsHoppening.Domain.Interfaces;
using System.Web;

namespace WhatsHoppening.Providers.ClientStorage
{
    public class CookieClientStorageProvider : IClientStorageProvider
    {
        private readonly ILogger _logger = null;

        public CookieClientStorageProvider(ILogger logger)
        {
            _logger = logger;
        }

        private HttpCookieCollection ReadableCookies
        {
            get
            {
                return HttpContext.Current.Request.Cookies;
            }
        }

        private HttpCookieCollection WriteableCookies
        {
            get
            {
                return HttpContext.Current.Response.Cookies;
            }
        }

        void IClientStorageProvider.Clear(ClearClientStorageRequest clearClientStorageRequest)
        {
            try
            {
                WriteableCookies.Remove(clearClientStorageRequest.Key);
            }
            catch (Exception e)
            {
                _logger.Log(Domain.LogSeverity.Warn, "An exception occurred attempting to clear cookie {0}. Swallowing error : {1}.".FormatWith(clearClientStorageRequest.Key, e.Message));
            }
        }

        ReadClientStorageResposne IClientStorageProvider.Read(ReadClientStorageRequest readClientStorageRequest)
        {
            ReadClientStorageResposne readClientStorageResponse = null;

            try
            {
                readClientStorageResponse = new ReadClientStorageResposne();

                if (ReadableCookies[readClientStorageRequest.Key] != null)
                {
                    readClientStorageResponse.Value = ReadableCookies[readClientStorageRequest.Key].Value;
                }
            }
            catch (Exception e)
            {
                throw new Exception("An exception occurred attempting to read a cookie value: [{0}].".FormatWith(readClientStorageRequest.Key), e);
            }

            return readClientStorageResponse;
        }

        void IClientStorageProvider.Write(WriteClientStorageRequest writeClientStorageRequest)
        {
            try
            {
                if (ReadableCookies[writeClientStorageRequest.Key] != null)
                {
                    WriteableCookies[writeClientStorageRequest.Key].Value = writeClientStorageRequest.Value;
                }
                else
                {
                    WriteableCookies.Add(new HttpCookie(writeClientStorageRequest.Key, writeClientStorageRequest.Value));
                }
            }
            catch (Exception e)
            {
                _logger.Log(Domain.LogSeverity.Warn, "An exception occurred trying to write to a cookie: [{0}]. Swallowing exception.".FormatWith(writeClientStorageRequest.Key));
            }
        }
    }
}
