using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PortraitButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("Pressed", true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetBool("Pressed", false);
    }
}
