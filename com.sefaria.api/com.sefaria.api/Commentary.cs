using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace com.sefaria.api
{
    public class Commentary
    {
        /// <summary>
        /// The map id.
        /// </summary>
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("anchorRef")]
        public String AnchorRef { get; set; }

        
    }
}
