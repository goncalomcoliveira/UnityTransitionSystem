using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GoncaloMCOliveira.TransitionSystem {
    
    [CreateAssetMenu(menuName = "Transitions/Fade")]
    public class FadeTransition : Transition {
    
        [Header("Fade Attributes")]
        [SerializeField] private Image overlayPrefab;
    
        public override IEnumerator Play(TransitionCanvas canvas, TransitionHandle handle) {
        
            var overlay = Instantiate(overlayPrefab, canvas.Root);
            var color = overlay.color;

            handle.Stopped += Cleanup;
        
            var start = Direction == TransitionDirection.Out ? 0f : 1f;
            var end = Direction == TransitionDirection.Out ? 1f : 0f;

            color.a = start;
            overlay.color = color;

            var t = 0f;
            while (t < Duration) {
                if (handle.IsStopped)
                    yield break;

                t += Time.deltaTime;
                var normalized = Mathf.Clamp01(t / Duration);
                var eased = Curve.Evaluate(normalized);

                color.a = Mathf.Lerp(start, end, eased);
                overlay.color = color;

                yield return null;
            }

            // Normal completion path — NO destroy here
            color.a = end;
            overlay.color = color;

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