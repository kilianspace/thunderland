using UnityEngine;
using UnityEngine.UI;

public class TitleMenuManager : MonoBehaviour
{
    private TitleMenu _titleMenu;

    private void Awake()
    {
        _titleMenu = gameObject.AddComponent<TitleMenu>(); // Add TitleMenu to this GameObject
    }

    private void Start()
    {
        InitializeMenu(); // Initialize the menu
    }

    private void InitializeMenu()
    {
        // Create the menu container
        GameObject menuContainer = new GameObject("MenuContainer");
        menuContainer.transform.SetParent(transform);

        _titleMenu.menuContainer = menuContainer; // Set the container in TitleMenu

        // Initialize the menu
        _titleMenu.InitializeMenu();
    }

    private void Update()
    {
        // Update the current state of the menu
        if (_titleMenu != null)
        {
            _titleMenu.Update();
        }
    }
}
