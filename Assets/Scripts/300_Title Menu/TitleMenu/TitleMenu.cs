using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Title menu class

[System.Serializable]
public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private IMenuState _currentState;
    private SigleleListMenu<string> _menu;

    public GameObject menuContainer; // Container for displaying the menu

    public void InitializeMenu()
    {
        _menu = new SigleleListMenu<string>(menuContainer, null, OnMenuItemSelected);
        _menu.AddItem("Start Game");
        _menu.AddItem("Config");
        _menu.AddItem("Quit");
        SetState(new MainMenuTopState()); // Set the initial state
    }

    public void SetState(IMenuState newState)
    {
        if (_currentState != null)
        {
            StartCoroutine(_currentState.ExitState(this)); // Exit the current state
        }

        _currentState = newState;
        StartCoroutine(_currentState.EnterState(this)); // Enter the new state
    }

    public void Update()
    {
        _currentState?.UpdateState(this); // Update the current state
    }

    private void OnMenuItemSelected(string item)
    {
        switch (item)
        {
            case "Start Game":
                SetState(new TitleMenuStartState()); // Transition to the start game state
                break;
            case "Config":
                SetState(new TitleMenuConfigState()); // Transition to the config state
                break;
            case "Quit":
                Application.Quit(); // Quit the application
                break;
        }
    }

    // Create a menu item
    public void CreateMenuItem(string itemName)
    {
        GameObject buttonObject = new GameObject(itemName); // Create a GameObject for the button
        Button button = buttonObject.AddComponent<Button>(); // Add Button component
        Text buttonText = buttonObject.AddComponent<Text>(); // Add Text component

        // Button settings
        buttonText.text = itemName; // Set the button text
        buttonText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // Set the font
        buttonText.alignment = TextAnchor.MiddleCenter; // Center the text

        // Set the parent of the button to the menu container
        buttonObject.transform.SetParent(menuContainer.transform);

        // Set the button click event
        button.onClick.AddListener(() => OnMenuItemSelected(itemName));
    }
}
