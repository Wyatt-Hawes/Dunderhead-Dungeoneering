using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimationTransitionHandler : MonoBehaviour, IPointerUpHandler
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Subscribe to the animation event
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            AnimationEvent animEvent = new AnimationEvent();
            animEvent.time = clip.length; // Event time is set to the end of the animation
            animEvent.functionName = "OnAnimationEnd"; // Call OnAnimationEnd method
            clip.AddEvent(animEvent); // Add the event to the animation clip
        }
    }

    // Called when the pointer is released from the object
    public void OnPointerUp(PointerEventData eventData)
    {
        // Set a parameter in the Animator controller to trigger the transition
        animator.SetBool("PointerUp", true);
    }

    // Called when the animation reaches its end
    private void OnAnimationEnd()
    {
        // Reset the parameters when the animation ends
        animator.SetBool("PointerUp", false);
        animator.SetBool("Highlighted", false);
        animator.SetBool("Selected", false);

    }
}
