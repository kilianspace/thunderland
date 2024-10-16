

public class CorePayload{

  // Backing field for InputActions
  private CoreContext _coreContext;

  // Public property to access InputActions
  public CoreContext CoreContext
  {
      get => _coreContext;
      set => _coreContext = value; // Set the value from external source
  }

  // Constructor to initialize InputActions
  public CorePayload(CoreContext context)
  {

      Log.Info("CorePayload / CorePayload Constructor", 1);
      _coreContext = context;

  }

}
