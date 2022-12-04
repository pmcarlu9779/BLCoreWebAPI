
namespace BLCoreWebAPI.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.8.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class NodeRedNode
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Id { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Type { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("z", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Z { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Name { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("method", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Method { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("ret", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Ret { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("paytoqs", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Paytoqs { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Url { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("tls", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Tls { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("persist", Required = Newtonsoft.Json.Required.Always)]
        public bool Persist { get; set; } = false;

        [Newtonsoft.Json.JsonProperty("proxy", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Proxy { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("insecureHTTPParser", Required = Newtonsoft.Json.Required.Always)]
        public bool InsecureHTTPParser { get; set; } = false;

        [Newtonsoft.Json.JsonProperty("authType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string AuthType { get; set; } = "";

        [Newtonsoft.Json.JsonProperty("senderr", Required = Newtonsoft.Json.Required.Always)]
        public bool Senderr { get; set; } = false;

        [Newtonsoft.Json.JsonProperty("headers", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<object> Headers { get; set; } = new System.Collections.ObjectModel.Collection<object>();

        [Newtonsoft.Json.JsonProperty("x", Required = Newtonsoft.Json.Required.Always)]
        public int X { get; set; } = 0;

        [Newtonsoft.Json.JsonProperty("y", Required = Newtonsoft.Json.Required.Always)]
        public int Y { get; set; } = 0;

        [Newtonsoft.Json.JsonProperty("wires", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<System.Collections.Generic.ICollection<string>> Wires { get; set; } = new System.Collections.ObjectModel.Collection<System.Collections.Generic.ICollection<string>>();

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }
}
