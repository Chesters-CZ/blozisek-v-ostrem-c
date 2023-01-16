using System.Globalization;
using System.Text.Json;
using Markdig;
using Microsoft.AspNetCore.Mvc;
using model_view_controler.modely;

namespace model_view_controler.Controllers;

public class steaminput : Controller
{
    public JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        { WriteIndented = true, IncludeFields = true };

    // GET
    public IActionResult Index()
    {
        try
        {
            string deboska =
                System.IO.File.ReadAllText("Databaze.json");
            BlogPost[]? outpt = JsonSerializer.Deserialize<BlogPost[]>(deboska, SerializerOptions);

            foreach (BlogPost post in outpt)
            {
                post.LongContent = Markdown.ToHtml(post.LongContent);
            }

            return View(outpt);
        }
        catch (Exception e)
        {
            return View();
        }
    }

    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost] // create new post
    public IActionResult Add(string header, string shortContent, string longContent)
    {
        Console.WriteLine($"RECEIVED FORM: {header}, {shortContent}, {longContent}");
        List<BlogPost>? blozisky;
        string deboska = System.IO.File.ReadAllText("Databaze.json");
        Console.WriteLine(deboska);
        blozisky = JsonSerializer.Deserialize<List<BlogPost>>(deboska, SerializerOptions);
        if (blozisky == null)
        {
            blozisky = new List<BlogPost>();
        }


        blozisky.Add(new BlogPost(header, DateTime.Now.ToString(CultureInfo.CurrentCulture), shortContent, longContent,
            blozisky.Count));
        foreach (BlogPost blozisek in blozisky)
        {
            
            Console.Write(blozisek.PostName);
            Console.Write(blozisek.DatePosted);
            Console.Write(blozisek.ShortContent);
            Console.Write(blozisek.LongContent);
            Console.WriteLine(blozisek.ID);
        }

        System.IO.File.WriteAllText("Databaze.json",
            JsonSerializer.Serialize(blozisky.ToArray(), SerializerOptions));

        return Index();
    }

    [HttpPost] // edit old post
    public IActionResult Index(string header, string shortContent, string longContent, string postID, string postDate)
    {
        Console.WriteLine($"RECEIVED FORM: {header}, {shortContent}, {longContent}, {postID}, {postDate}");
        int ID = int.Parse(postID);
        List<BlogPost>? blozisky;
        string deboska = System.IO.File.ReadAllText("Databaze.json");
        Console.WriteLine(deboska);
        blozisky = JsonSerializer.Deserialize<List<BlogPost>>(deboska, SerializerOptions);
        if (blozisky == null)
        {
            blozisky = new List<BlogPost>();
        }

        for (int i = 0; i < blozisky.Count; i++)
        {
            if (blozisky[i].ID == ID)
            {
                blozisky[i] = new BlogPost(header, postDate, shortContent, longContent, ID);
                break;
            }
        }

        foreach (BlogPost blozisek in blozisky)
        {
            Console.Write(blozisek.PostName);
            Console.Write(blozisek.DatePosted);
            Console.Write(blozisek.ShortContent);
            Console.Write(blozisek.LongContent);
            Console.WriteLine(blozisek.ID);
        }

        System.IO.File.WriteAllText("Databaze.json",
            JsonSerializer.Serialize(blozisky.ToArray(), SerializerOptions));

        return Index();
    }


    [HttpPost] // edit old post
    public IActionResult Delete(string postID)
    {
        int ID = int.Parse(postID);
        Console.WriteLine($"RECEIVED FORM: {postID}");
        List<BlogPost>? blozisky;
        string deboska = System.IO.File.ReadAllText("Databaze.json");
        Console.WriteLine(deboska);
        blozisky = JsonSerializer.Deserialize<List<BlogPost>>(deboska, SerializerOptions);
        if (blozisky == null)
        {
            blozisky = new List<BlogPost>();
        }

        for (int i = 0; i < blozisky.Count; i++)
        {
            if (blozisky[i].ID == ID)
            {
                blozisky.RemoveAt(i);
                break;
            }
        }

        foreach (BlogPost blozisek in blozisky)
        {
            Console.Write(blozisek.PostName);
            Console.Write(blozisek.DatePosted);
            Console.Write(blozisek.ShortContent);
            Console.Write(blozisek.LongContent);
            Console.WriteLine(blozisek.ID);
        }

        System.IO.File.WriteAllText("Databaze.json",
            JsonSerializer.Serialize(blozisky.ToArray(), SerializerOptions));

        return Index();
    }
}