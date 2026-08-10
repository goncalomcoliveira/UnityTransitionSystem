using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GoncaloMCOliveira.TransitionSystem {
    
    [CreateAssetMenu(menuName = "Transitions/Library")]
    public class TransitionLibrary : ScriptableObject {
    
        [SerializeField] private List<Transition> transitions;
        private Dictionary<string, Transition> lookup;

        public Transition Get(string id) {
            lookup ??= BuildLookup();   // If null build lookup
            return lookup[id];
        }

        private Dictionary<string, Transition> BuildLookup() {
            return transitions.ToDictionary(t => t.Id);
        }
    }
}