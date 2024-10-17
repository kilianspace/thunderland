public class Context
{
    private DiscographyModel _cd;
    public DiscographyModel Cd
    {
        get { return _cd; }
        set { _cd = value; }
    }

    public Context(Statemachine machine, DiscographyModel cd)
    {
        _cd = cd;
    }
}
