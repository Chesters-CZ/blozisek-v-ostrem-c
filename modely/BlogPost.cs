using System.Runtime.Serialization;

namespace model_view_controler.modely;

public class BlogPost
{
    public String? PostName;
    public String? DatePosted;
    public String? ShortContent;
    public String? LongContent;
    public int? ID ;

    public BlogPost(string postName, string datePosted, string shortContent, string longContent, int id)
    {
        PostName = postName;
        DatePosted = datePosted;
        ShortContent = shortContent;
        LongContent = longContent;
        ID = id;
    }

    public BlogPost()
    {
    }
}