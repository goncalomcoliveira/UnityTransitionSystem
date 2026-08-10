using System.Collections.Generic;
using GoncaloMCOliveira.Singleton;
using UnityEngine;

namespace GoncaloMCOliveira.TransitionSystem {
    
    public class TransitionManager : PersistentSingleton<TransitionManager> {

        [SerializeField] private TransitionLibrary transitionLibrary;
        [SerializeField] private TransitionCanvas transitionCanvas;

        private readonly Dictionary<string, TransitionHandle> active = new();

        public TransitionHandle Play(string transitionId) {
        
            var transition = transitionLibrary.Get(transitionId);
        
            if (transition.StopAllOnStart) {
                StopActive();
            }
            else {
                foreach (var id in transition.StopTransitionsOnStart)
                    Stop(id);
            }
        
            // Stop existing transition with same ID
            Stop(transitionId);
        
            var handle = new TransitionHandle(transitionId);

            active[transitionId] = handle;

            handle.Completed += () => {
                if (transition.StopOnComplete) {
                    handle.Stop();
                }
            };
            handle.Stopped += () => active.Remove(transitionId);

            StartCoroutine(transition.Play(transitionCanvas, handle));
        
            return handle;
        }

        public void Stop(string transitionId) {
            if (active.TryGetValue(transitionId, out var handle)) {
                handle.Stop();
            }
        }
    
        public void StopActive() {
            foreach (var handle in active.Values)
                handle.Stop();
            active.Clear();
        }

        public bool IsActive(string transitionId)
            => active.ContainsKey(transitionId);
    }
}