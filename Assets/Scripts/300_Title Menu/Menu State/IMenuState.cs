using System.Collections; // Add this line
using UnityEngine;


public interface IMenuState
{
    IEnumerator EnterState(TitleMenu titleMenu);
    IEnumerator ExitState(TitleMenu titleMenu);
    void UpdateState(TitleMenu titleMenu);
}
