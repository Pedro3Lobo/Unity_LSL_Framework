using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    // Reference to the image component
    public Image image;
    private Vector3 endPosition = new Vector3(6000, 0, 0);

    // Flag to check if the image is currently moving
    private bool isMoving = false;



    public void MoveImageToTargetPosition()
    {
        if (!isMoving)
        {
            // Start moving the image
            isMoving = true;
            image.transform.position = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);

        }
        else
        {
            isMoving = false;
            image.transform.position = endPosition;
        }
    }

    
}
