using StarterAssets;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchLookInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {
    public StarterAssetsInputs starterAssetsInputs;
    private bool isTouching = false;
    private Vector2 touchStartPos;
    private Vector2 smoothLookVelocity;
    public float smoothTime = 0.1f;

    // New fields for flipping directions
    public bool flipHorizontal = false;
    public bool flipVertical = false;

    public void OnPointerDown(PointerEventData eventData) {
        isTouching = true;
        touchStartPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData) {
        isTouching = false;
        starterAssetsInputs.LookInput(Vector2.zero);
    }

    public void OnDrag(PointerEventData eventData) {
        if (isTouching) {
            Vector2 touchDelta = eventData.position - touchStartPos;

            // Normalize touch delta and cap between 0 and 1
            touchDelta = Vector2.ClampMagnitude(touchDelta, 1f);

            // Apply flipping based on the boolean fields
            if (flipHorizontal) {
                touchDelta.x = -touchDelta.x;
            }

            if (flipVertical) {
                touchDelta.y = -touchDelta.y;
            }

            // Apply smoothing
            Vector2 smoothedLook = Vector2.SmoothDamp(starterAssetsInputs.look, touchDelta, ref smoothLookVelocity, smoothTime);

            // Update look input
            starterAssetsInputs.LookInput(smoothedLook);

            touchStartPos = eventData.position;
        }
    }
}
