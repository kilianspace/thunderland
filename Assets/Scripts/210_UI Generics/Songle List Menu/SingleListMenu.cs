using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SigleleListMenu<T>
{
    private List<T> _items;
    private Action<T> _onItemSelected;
    private GameObject _menuContainer;

    public SigleleListMenu(GameObject menuContainer, GameObject menuItemPrefab, Action<T> onItemSelected)
    {
        _items = new List<T>();
        _menuContainer = menuContainer;
        _onItemSelected = onItemSelected;
    }

    // Add an item to the menu
    public void AddItem(T item)
    {
        _items.Add(item);
        CreateMenuItem(item); // Create the menu item using the item directly
    }

    // Remove an item from the menu
    public void RemoveItem(T item)
    {
        _items.Remove(item);
        UpdateMenu();
    }

    // Create a menu item
    private void CreateMenuItem(T item) // Change string to T
    {
        GameObject buttonObject = new GameObject(item.ToString()); // Create a GameObject for the button
        Button button = buttonObject.AddComponent<Button>(); // Add Button component
        Text buttonText = buttonObject.AddComponent<Text>(); // Add Text component

        buttonText.text = item.ToString(); // Set the button text
        buttonText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); // Set the font
        buttonText.alignment = TextAnchor.MiddleCenter; // Center the text

        buttonObject.transform.SetParent(_menuContainer.transform); // Set the parent of the button

        // Set the button click event
        button.onClick.AddListener(() => _onItemSelected(item)); // Use the item itself
    }

    // Update the menu (no longer needed as items are created on AddItem)
    private void UpdateMenu()
    {
        // No implementation needed
    }
}
