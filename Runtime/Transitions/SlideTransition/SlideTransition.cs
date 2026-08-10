using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GoncaloMCOliveira.TransitionSystem {
    
    [CreateAssetMenu(menuName = "Transitions/Slide")]
    public class SlideTransition : Transition {
        
        [Header("Slide Attributes")]
        [SerializeField] private Image overlayPrefab;
        [SerializeField] private Vector2 slideDirection;
        [SerializeField] private float slidePadding;

        public override IEnumerator Play(TransitionCanvas canvas, TransitionHandle handle) {
            
            var overlay = Instantiate(overlayPrefab, canvas.Root);
            var overlayRect = overlay.rectTransform;
            
            handle.Stopped += Cleanup;
            
            var moveDirection = slideDirection.normalized;
            
            var rootSize = canvas.Root.rect.size;

            // Half extents of the screen
            var halfSize = rootSize * 0.5f;
            
            var distanceToEdge = Mathf.Min(
                halfSize.x / Mathf.Abs(moveDirection.x == 0 ? float.Epsilon : moveDirection.x),
                halfSize.y / Mathf.Abs(moveDirection.y == 0 ? float.Epsilon : moveDirection.y)
            );
            
            // Multiply by 2 so the fullscreen image fully leaves the screen
            var totalDistance = distanceToEdge * 2f + slidePadding;
            
            var start = Direction == TransitionDirection.Out ? moveDirection * totalDistance : Vector2.zero;
            var end = Direction == TransitionDirection.Out ? Vector2.zero : moveDirection * totalDistance;

            overlayRect.anchoredPosition = start;

            var t = 0f;
            while (t < Duration) {
                if (handle.IsStopped)
                    yield break;

                t += Time.deltaTime;
                var normalized = Mathf.Clamp01(t / Duration);
                var eased = Curve.Evaluate(normalized);

                overlayRect.anchoredPosition = Vector2.Lerp(start, end, eased);

                yield return null;
            }

            // Normal completion path — NO destroy here
            overlayRect.anchoredPosition = end;
            
            handle.Complete();
            yield break;

            // Cleanup when stopped
            void Cleanup() {
                if (overlay)
                    Destroy(overlay.gameObject);

                handle.Stopped -= Cleanup;
            }
        }
    }
}