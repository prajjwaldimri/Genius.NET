# Annotations

You can interact with annotations on the Genius Server using `AnnotationsClient`. 

`AnnotationsClient` provides methods to Retrieve, Create, Update or Delete annotations.

### Getting the annotations

``` C#
 var getAnnotation = await geniusClient.AnnotationsClient.GetAnnotation("ANNOTATION_ID", TextFormat.Dom);
```

### Creating an annotation

To create a new annotation, you have to first create an `AnnotationPayload`. This is the object which will be serialized and sent to genius servers and act as the data for the annotation.

``` C#
var annotationPayload = new AnnotationPayload
{
    Annotation = new Annotation {Body = new AnnotationBody {MarkDown = "hello **world!**"}},
    Referent = new Referent
    {
        RawAnnotableUrl = "http://seejohncode.com/2014/01/27/vim-commands-piping/",
        Fragment = "execute commands",
        ContextForDisplay = new ContextForDisplay
        {
            BeforeHtml = "You may know that you can ",
            AfterHtml = " from inside of a vim, with a vim command:"
        }
    },
    WebPage = new WebPage
    {
        CanonicalUrl = null,
        OgUrl = null,
        Title = "Secret of Mana"
    }
};
var postAnnotation = await geniusClient.AnnotationsClient.CreateAnnotation(annotationPayload, TextFormat.Dom);
```

!!! note
    These are very few of the fields which can be inputted to the `AnnotationPayload`.

### Updating an annotation

To update an annotation created by the authenticated user, you have to supply an `AnnotationPayload` similarly to above.

``` C#
var updatedAnnotation = await geniusClient.AnnotationsClient.UpdateAnnotation(postAnnotation.Response.Id, annotationUpdatePayload, TextFormat.Dom);
```

### Deleting an Annotation

Use the `DeleteAnnotation` method in `AnnotationsClient` to delete any annotation created by the authenticated user.

``` C#
var deletedAnnotation = await geniusClient.AnnotationsClient.DeleteAnnotation(postAnnotation.Response.Id, TextFormat.Dom);
```

## Voting on the annotations

Users can Up-Vote, Down-Vote or Un-Vote any annotation on Genius. This can be done using the `VoteClient` in Genius.NET

### Upvoting an annotation

``` C#
await geniusClient.VoteClient.Vote(VoteType.Upvote, "Annotation_ID", TextFormat.Dom);
```

### Downvoting an annotation

``` C#
await geniusClient.VoteClient.Vote(VoteType.Downvote, "Annotation_ID", TextFormat.Dom);
```

### Unvoting an annotation

``` C#
await geniusClient.VoteClient.Vote(VoteType.Unvote, "Annotation_ID", TextFormat.Dom);
```

!!! note
    `VoteType` is an enumeration available in Genius.NET library.