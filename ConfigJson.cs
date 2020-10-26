using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Shiro_Sharp
{
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
    }
}
