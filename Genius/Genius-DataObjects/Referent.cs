using System.Collections.Generic;

namespace Genius
{
    public class Referent
    {
        public string _Type { get; set; }
        public string Annotator_Id { get; set; }
        public string Annotator_Login { get; set; }
        public string Api_Path { get; set; }
        public string Classification { get; set; }
        public bool Featured { get; set; }
        public string Fragment { get; set; }
        public string Id { get; set; }
        public bool Is_Description { get; set; }
        public string Path { get; set; }
        public ReferentRange Range { get; set; }
        public string Song_Id { get; set; }
        public string URL { get; set; }
        public List<Annotation> Annotations { get; set; }
        public Annotatable Annotatable { get; set; }
        public List<string> Verified_Annotator_Ids { get; set; }
    }

    /// <summary>
    /// Information for anchoring the referent in the source text
    /// </summary>
    public class ReferentRange
    {
        public string Start { get; set; }
        public string StartOffset { get; set; }
        public string End { get; set; }
        public string EndOffset { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public string Content { get; set; }
    }

    /// <summary>
    /// Meta-data about the annotated document
    /// </summary>
    public class Annotatable
    {
        public string Api_Path { get; set; }
        public string Context { get; set; }
        public string Id { get; set; }
        public string Image_Url { get; set; }
        public string Link_Title { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
    }

}

