using System.Collections; // Add this line
using UnityEngine;


public class MainMenuTopState : IMenuState
{
    // Method to handle entering the Main Menu state
    public IEnumerator EnterState(TitleMenu titleMenu)
    {
        Debug.Log("Entering Main Menu State");
        yield return null; // Wait for the next frame
    }

    // Method to handle exiting the Main Menu state
    public IEnumerator ExitState(TitleMenu titleMenu)
    {
        Debug.Log("Exiting Main Menu State");
        yield return null; // Wait for the next frame
    }

    // Method to update the Main Menu state
    public void UpdateState(TitleMenu titleMenu)
    {
        // Update logic for the main menu (input handling, etc.)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            titleMenu.SetState(new TitleMenuConfigState()); // Transition to the config state
        }
    }
}
