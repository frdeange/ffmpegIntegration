using System.Collections.Generic;
using System.IO;
using LiveDrmOperationsV3.Helpers;
using LiveDRMOperationsV3.Models;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LiveDrmOperationsV3.Models
{
    public class StreamingPolicyInfo : BaseModel
    {
        [JsonProperty("streamingPolicyName")] public string StreamingPolicyName { get; set; }
     
        [JsonProperty("amsAccountName")] public string AMSAccountName { get; set; }

        [JsonProperty(PropertyName = "id")] public string Id => (AMSAccountName + ":" + Partition).ToLower();

        [JsonProperty(PropertyName = "partitionKey", NullValueHandling = NullValueHandling.Ignore)]
        public override string PartitionKey => Partition;

        public StreamingPolicyInfo(bool isVod)
        {
            Partition = isVod ? AssetEntry.DefaultPartitionValue : BaseModel.DefaultPartitionValue;
        }

        [JsonIgnore] private string Partition { get; set; }
    }
}