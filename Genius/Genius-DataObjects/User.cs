using System.Collections.Generic;
using Newtonsoft.Json;

namespace Genius
{
    public class User
    {
        public string Api_Path { get; set; }
        public Avatar Avatar { get; set; }
        public string Header_Image_Url { get; set; }
        public string Human_Readable_Role_For_Display { get; set; }
        public string Id { get; set; }
        public string Iq { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Role_For_Display { get; set; }
        public string Url { get; set; }
    }

    public class CurrentUserMetadata
    {
        public CurrentUserInteractions Interactions { get; set; }
        public CurrentUserRelationships Relationships { get; set; }
        public List<string> Permissions { get; set; }
    }

    #region Sub-classes for CurrentUserMetadataClass
    public class CurrentUserInteractions
    {
        public bool Pyong { get; set; }
        public bool Following { get; set; }
    }

    public class CurrentUserRelationships
    {
        [JsonProperty(PropertyName = "pinned_role")]
        public string PinnedRole { get; set; }
    }
    #endregion
}
