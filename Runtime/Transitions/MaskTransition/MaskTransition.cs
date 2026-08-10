using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GoncaloMCOliveira.TransitionSystem {
    
    [CreateAssetMenu(menuName = "Transitions/Mask")]
    public class MaskTransition : Transition {

        [Header("Mask Attributes")]
        [SerializeField] private Image overlayPrefab;
        [SerializeField] private Vector2 screenPosition = new(0.5f, 0.5f);
        [SerializeField] private float maxSize = 2000f;

        public override IEnumerator Play(TransitionCanvas canvas, TransitionHandle handle) {
        
            var overlay = Instantiate(overlayPrefab, canvas.Root);
            var rect = overlay.rectTransform;
        
            handle.Stopped += Cleanup;

            rect.anchorMin = rect.anchorMax = screenPosition;
            rect.anchoredPosition = Vector2.zero;

            var start = Direction == TransitionDirection.Out ? Vector2.one * maxSize : Vector2.zero;
            var end = Direction == TransitionDirection.Out ? Vector2.zero : Vector2.one * maxSize;

            rect.sizeDelta = start;

            var t = 0f;
            while (t < Duration) {
                if (handle.IsStopped)
                    yield break;

                t += Time.deltaTime;
                var eased = Curve.Evaluate(Mathf.Clamp01(t / Duration));
                rect.sizeDelta = Vector2.Lerp(start, end, eased);

                yield return null;
            }

            rect.sizeDelta = end;

            handle.Complete();
            yield break;

            void Cleanup() {
                if (overlay)
                    Destroy(overlay.gameObject);
                handle.Stopped -= Cleanup;
            }
        }
    }
}