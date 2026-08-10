using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CutoutMaskUI : Image {
    
    private static readonly int StencilComp = Shader.PropertyToID("_StencilComp");

    public override Material materialForRendering {
        get {
            var newMaterial = new Material(base.materialForRendering);
            newMaterial.SetFloat(StencilComp, (float)CompareFunction.NotEqual);
            return newMaterial;
        }
    }
}
