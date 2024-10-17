using System.Collections;
using UnityEngine;

public class TitleMenuConfigState : IMenuState
{
    public IEnumerator EnterState(TitleMenu titleMenu)
    {
        Debug.Log("Entering Config Menu State");
        yield return null; // Wait for the next frame
    }

    public IEnumerator ExitState(TitleMenu titleMenu)
    {
        Debug.Log("Exiting Config Menu State");
        yield return null; // Wait for the next frame
    }

    public void UpdateState(TitleMenu titleMenu)
    {
        // Logic for updating the Config Menu
    }
}
