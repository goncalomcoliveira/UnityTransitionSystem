using System.Collections;
using UnityEngine;

namespace GoncaloMCOliveira.TransitionSystem {
    
    [CreateAssetMenu(menuName = "Transitions/Animation")]
    public class AnimationTransition : Transition {
    
        [Header("Animation Attributes")]
        [SerializeField] private GameObject animatedPrefab;
        [SerializeField] private string stateName;
        [SerializeField] private bool overwriteDuration = false;
    
        public override IEnumerator Play(TransitionCanvas canvas, TransitionHandle handle) {
            
            var go = Instantiate(animatedPrefab, canvas.Root);
            var animator = go.GetComponent<Animator>();
    
            Debug.Assert(animator, "Animator missing on animated prefab");
    
            handle.Stopped += Cleanup;
    
            animator.Play(stateName, 0, 0f);
    
            float duration;
    
            if (overwriteDuration) {
                duration = Duration;
                animator.speed = GetAnimationLength(animator) / Duration;
            }
            else {
                duration = GetAnimationLength(animator);
                animator.speed = 1f;
            }
    
            var t = 0f;
            while (t < duration) {
                if (handle.IsStopped)
                    yield break;
    
                t += Time.deltaTime;
                yield return null;
            }
    
            handle.Complete();
            yield break;
    
            void Cleanup() {
                if (go)
                    Destroy(go);
                handle.Stopped -= Cleanup;
            }
        }
    
        private float GetAnimationLength(Animator animator) {
            var clips = animator.runtimeAnimatorController.animationClips;
            foreach (var clip in clips)
                if (clip.name == stateName)
                    return clip.length;
    
            Debug.LogWarning($"Animation clip '{stateName}' not found");
            return Duration;
        }
    }
}


