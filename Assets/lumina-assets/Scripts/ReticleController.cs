using UnityEngine;

public class ReticleController : MonoBehaviour
{
    public GameObject reticle; // Reference to the reticle GameObject

    // Method to show the reticle
    public void ShowReticle()
    {
        reticle.SetActive(true);
    }

    // Method to hide the reticle
    public void HideReticle()
    {
        reticle.SetActive(false);
    }

    // Method to check if the reticle is active
    public bool IsReticleActive()
    {
        return reticle.activeSelf;
    }

    // Method to set the position of the reticle
    public void SetReticlePosition()
    {
        reticle.transform.position = Input.mousePosition;
    }

        public Vector3 GetReticlePosition()
    {
        return reticle.transform.position;
    }
}