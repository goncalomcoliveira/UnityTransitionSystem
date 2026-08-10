using System;
using System.Collections;
using UnityEngine;

namespace GoncaloMCOliveira.TransitionSystem {
    
    public sealed class TransitionHandle {
        public string Id { get; }
        public bool IsStopped { get; private set; }
        public bool IsCompleted { get; private set; }

        public event Action Stopped;
        public event Action Completed;

        internal TransitionHandle(string id) {
            Id = id;
        }

        public void Stop() {
            if (IsStopped) return;
            IsStopped = true;
            Stopped?.Invoke();
        }

        internal void Complete() {
            if (IsStopped) return;
            IsCompleted = true;
            Completed?.Invoke();
        }
    
        public IEnumerator WaitForFinish() {
            yield return new WaitUntil(() => IsStopped || IsCompleted);
        }
    }
}

