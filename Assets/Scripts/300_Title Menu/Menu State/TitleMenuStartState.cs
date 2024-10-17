using System.Collections; // Add this line
using UnityEngine;


public class TitleMenuStartState : IMenuState
{
    public IEnumerator EnterState(TitleMenu titleMenu)
    {
        Debug.Log("Starting Game");
        yield return new WaitForSeconds(1);


        // Logic here!


    }

    public IEnumerator ExitState(TitleMenu titleMenu)
    {
        yield return null;
    }

    public void UpdateState(TitleMenu titleMenu)
    {
        //Update logic here
    }
}
