using System.Collections;
using Microsoft.AspNetCore.Mvc;
using model_view_controler.modely;

namespace model_view_controler.Controllers;

public class steaminput : Controller
{
    // GET
    public IActionResult Index()
    {
        Console.WriteLine("pindík");
        ViewData["pyndík"] = "haha penis";

        ViewBag.pytlík = "varle"; // donot.

        string prezos =
            System.IO.File.ReadAllText(
                "C:\\Users\\bezou\\Google Drive\\Educanet\\2022-2023\\Dotnet\\model-view-controler\\presidents.csv");
        string[] prezoParsed = prezos.Split("\n");
        List<Prezidentik> outpt = new List<Prezidentik>();
        bool isfirst = true;
        foreach (string p in prezoParsed)
        {
            string[] splittd = p.Split(",");
            if (splittd.Length == 9)
            {
                Console.WriteLine(splittd[0] + splittd[1] + splittd[2] + splittd[3] + splittd[4] + splittd[5] +
                                  splittd[6] + splittd[7] + splittd[8]);
                outpt.Add(new Prezidentik(splittd));
            }
        }

        int Jcount = 0;
        foreach (Prezidentik prezidentik in outpt)
        {
            if (prezidentik.Name.ToCharArray()[0].ToString().ToLower().Equals("j"))
            {
                Jcount++;
            }
        }
        ViewData["Jcount"] = Jcount;

        int repcount = 0;
        int demcount = 0;
        int others = 0;

        foreach (Prezidentik prezidentik in outpt)
        {
            if (prezidentik.Party.ToLower().Equals("democratic"))
            {
                demcount++;
            }

            if (prezidentik.Party.ToLower().Equals("republican"))
            {
                repcount++;
            }

            if (!prezidentik.Party.ToLower().Equals("republican") && !prezidentik.Party.ToLower().Equals("democratic"))
            {
                others++;
            }
        }
        ViewData["libtards"] = (float)(demcount / outpt.Count * 100);
        ViewData["reptards"] = (float)(repcount / outpt.Count * 100);


        int newyorkers = 0;
        foreach (Prezidentik prezidentik in outpt)
        {
            if (prezidentik.HomeState.ToLower().Equals("new york"))
            {
                newyorkers++;
            }
        }
        ViewData["newyorker"] = newyorkers;
        
        

        return View(outpt.ToArray());
    }
}