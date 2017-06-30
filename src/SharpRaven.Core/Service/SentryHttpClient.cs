using Newtonsoft.Json;
using SharpRaven.Core.Config;
using SharpRaven.Core.Service.Models;
using SharpRaven.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharpRaven.Core.Service
{
    class SentryHttpClient : IClient
    {
        private IConfig _config;
        private ILog _log;

        public SentryHttpClient(IConfig config) : this(config,new ConsoleLog())
        {
        }

        public SentryHttpClient(IConfig config, ILog log)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (log == null)
                throw new ArgumentNullException(nameof(log));

            _config = config;
            _log = log;
        }

        public async Task<SentryServerResponse> SendAsync(JsonPacket packet)
        {
            try
            {
                using (var cts = new CancellationTokenSource(_config.Timeout))
                {
                    var client = new HttpClient();
                    client.Timeout = _config.Timeout;

                    var stringPacket = JsonConvert.SerializeObject(packet);
                    var requestBody = new StringContent(stringPacket, Encoding.UTF8, "application/json");
                    var request = new HttpRequestMessage(HttpMethod.Post, _config.CurrentDsn.SentryUri);
                    request.Content = requestBody;
                    request.Headers.Add("X-Sentry-Auth", PacketBuilder.CreateAuthenticationHeader(this._config.CurrentDsn));
                    request.Headers.Add("User-Agent",PacketBuilder.UserAgent);

                    var response = await client.SendAsync(request,cts.Token);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        _log.Error($"Not able to send packet to sentry dns: {_config.CurrentDsn} with status code {response.StatusCode}");
                        return null;
                    }

                    var stringContent = await response.Content.ReadAsStringAsync();
                    var serverResponse = JsonConvert.DeserializeObject<SentryServerResponse>(stringContent);
                    return serverResponse;
                }
            }
            catch (TaskCanceledException)
            {
                _log.Error($"Web called cancelled with timeout {_config.Timeout.TotalSeconds} seconds, sentry dns: {_config.CurrentDsn}");
                return null;
            }
            catch (System.Exception ex)
            {
                _log.Error($"Not able to send packet to sentry dns: {_config.CurrentDsn} with Exception {ex}");
                return null;
            }
        }
    }
}
