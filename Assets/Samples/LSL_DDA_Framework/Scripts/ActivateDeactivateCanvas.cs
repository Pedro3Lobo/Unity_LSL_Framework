using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ActivateDeactivateCanvas : MonoBehaviour
{
    // Reference to the Canvas component
    
    private bool canvas_on = false;
    private bool componentsActive = true;
    public GameObject toogles;

    private void Start()
    {
        ToggleComponentState();
    }

    // Method to deactivate the Canvas


    void ToggleComponentsRecursive(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // Check if the child object has an Image component
            Image imageComponent = child.GetComponent<Image>();
            if (imageComponent != null)
            {
                // Toggle the state of the Image component
                imageComponent.enabled = componentsActive;
            }

            // Check if the child object has a Text component
            Text textComponent = child.GetComponent<Text>();
            if (textComponent != null)
            {
                // Toggle the state of the Text component
                textComponent.enabled = componentsActive;
            }

            // Check if the child object has a TextMeshPro component
            TextMeshProUGUI tmpComponent = child.GetComponent<TextMeshProUGUI>();
            if (tmpComponent != null)
            {
                // Toggle the state of the TextMeshPro component
                tmpComponent.enabled = componentsActive;
            }

            // Recursively toggle components in child objects
            ToggleComponentsRecursive(child);
        }
    }

    public void ToggleComponentState()
    {
        // Toggle the state of the components
        componentsActive = !componentsActive;
        ToggleComponentsRecursive(transform);
        if (componentsActive)
        {
            refreshToggles();
        }
    }

    private void refreshToggles()
    {
        toogles.SetActive(false);
        toogles.SetActive(true);
    }
}
