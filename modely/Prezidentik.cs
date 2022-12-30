namespace model_view_controler.modely;

public class Prezidentik
{
    public String PresidencyID { get; private set; }
    public String Name { get; private set; }
    public String Wikipedia { get; private set; }
    public String PresidentFrom { get; private set; }
    public String PresidentTo { get; private set; }
    public String Party { get; private set; }
    public String PortraitImage { get; private set; }
    public String Thumbnail { get; private set; }
    public String HomeState { get; private set; }

    public Prezidentik(string[] inp)
    {
        PresidencyID = inp[0];
        Name = inp[1];
        Wikipedia = inp[2];
        PresidentFrom = inp[3];
        PresidentTo = inp[4];
        Party = inp[5];
        PortraitImage = inp[6];
        Thumbnail = inp[7];
        HomeState = inp[8];
    }
}