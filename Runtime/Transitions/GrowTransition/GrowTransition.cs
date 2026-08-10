using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GoncaloMCOliveira.TransitionSystem {
    
    [CreateAssetMenu(menuName = "Transitions/Grow")]
    public class GrowTransition : Transition {

        [Header("Grow Attributes")]
        [SerializeField] private Image overlayPrefab;
        [SerializeField] private Vector2 screenPosition = new(0.5f, 0.5f);
        [SerializeField] private Vector3 maxScale = Vector3.one * 2f;

        public override IEnumerator Play(TransitionCanvas canvas, TransitionHandle handle) {
        
            var overlay = Instantiate(overlayPrefab, canvas.Root);
            var rect = overlay.rectTransform;

            handle.Stopped += Cleanup;

            rect.anchorMin = rect.anchorMax = screenPosition;
            rect.anchoredPosition = Vector2.zero;

            var start = Direction == TransitionDirection.Out ? Vector3.zero : maxScale;
            var end = Direction == TransitionDirection.Out ? maxScale : Vector3.zero;

            rect.localScale = start;

            float t = 0f;
            while (t < Duration) {
                if (handle.IsStopped)
                    yield break;

                t += Time.deltaTime;
                var eased = Curve.Evaluate(Mathf.Clamp01(t / Duration));
                rect.localScale = Vector3.Lerp(start, end, eased);

                yield return null;
            }

            rect.localScale = end;

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