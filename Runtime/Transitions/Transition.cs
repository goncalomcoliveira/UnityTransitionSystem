using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoncaloMCOliveira.TransitionSystem {
    
    public enum TransitionDirection {
        In,   // on-screen → off-screen
        Out   // off-screen → on-screen
    }

    public abstract class Transition : ScriptableObject {
    
        [Header("General Attributes")]
    
        [SerializeField] private string id;
        public string Id => id;
    
        [SerializeField] private float duration = 0.5f;
        public float Duration => duration;
    
        [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        public AnimationCurve Curve => curve;
    
        [SerializeField] private TransitionDirection direction = TransitionDirection.Out;
        public TransitionDirection Direction => direction;
    
        [Header("Lifecycle")]
    
        [SerializeField] private bool stopOnComplete = true;
        public bool StopOnComplete => stopOnComplete;
    
        [Header("Start Behavior")]
        [SerializeField] private bool stopAllOnStart = false;
        public bool StopAllOnStart => stopAllOnStart;
    
        [SerializeField] private List<string> stopTransitionsOnStart = new();
        public List<string> StopTransitionsOnStart => stopTransitionsOnStart;
    
        public abstract IEnumerator Play(
            TransitionCanvas canvas,
            TransitionHandle handle
        );
    }
}