using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Models
{
    public class ShopItem
    {
        public ShopItem()
        {
            DocumentType = "shopitem";
        }
        [Key]
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "dType", NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }


        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Ignore)]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "dateOfAddition", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateOfAddition { get; set; }

        [JsonProperty(PropertyName = "isAvailable", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAvailable { get; set; }

        [JsonProperty(PropertyName = "updatedOn", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedOn { get; set; }

    }


}


