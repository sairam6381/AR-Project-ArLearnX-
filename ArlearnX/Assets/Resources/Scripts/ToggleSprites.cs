using UnityEngine;
using UnityEngine.UI;

public class ToggleSprites : MonoBehaviour
{
    public GameObject[] spritesToToggle;
    private bool areSpritesVisible = false;

    void Start()
    {
        // Initially set all sprites to be inactive
        foreach (GameObject spriteObject in spritesToToggle)
        {
            spriteObject.SetActive(false);
        }
    }

    // Call this function when the button is clicked
    public void OnToggleButtonClicked()
    {
        // Toggle visibility state
        areSpritesVisible = !areSpritesVisible;

        // Update the visibility of the sprites
        SetSpriteVisibility(areSpritesVisible);
    }

    void SetSpriteVisibility(bool isVisible)
    {
        // Loop through all the GameObjects and set their activity state
        foreach (GameObject spriteObject in spritesToToggle)
        {
            spriteObject.SetActive(isVisible);
        }
    }
}
