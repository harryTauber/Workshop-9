// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    // Triggered as soon as the object is outside of the camera frustum.
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
