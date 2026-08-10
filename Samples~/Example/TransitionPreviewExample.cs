using System.Collections;
using GoncaloMCOliveira.TransitionSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionPreviewExample : MonoBehaviour {

    #region Fade

    public void StartFadeIn() {
        TransitionManager.Instance.Play("FadeIn");
    }
    
    public void StopFadeIn() {
        TransitionManager.Instance.Stop("FadeIn");
    }
    
    public void StartFadeOut() {
        TransitionManager.Instance.Play("FadeOut");
    }
    
    public void StopFadeOut() {
        TransitionManager.Instance.Stop("FadeOut");
    }

    public void FadeNextScene() {
        StartCoroutine(FadeNextSceneEnumerator());
    }
    
    private IEnumerator FadeNextSceneEnumerator() {
        var handle = TransitionManager.Instance.Play("FadeOut");
        yield return handle.WaitForFinish();

        SceneManager.LoadScene("BaseScene");
        
        TransitionManager.Instance.Play("FadeIn");
    }

    #endregion
    
    #region Slide

    public void StartSlideIn() {
        TransitionManager.Instance.Play("SlideIn");
    }
    
    public void StopSlideIn() {
        TransitionManager.Instance.Stop("SlideIn");
    }
    
    public void StartSlideOut() {
        TransitionManager.Instance.Play("SlideOut");
    }
    
    public void StopSlideOut() {
        TransitionManager.Instance.Stop("SlideOut");
    }

    public void SlideNextScene() {
        StartCoroutine(SlideNextSceneEnumerator());
    }
    
    private IEnumerator SlideNextSceneEnumerator() {
        var handle = TransitionManager.Instance.Play("SlideOut");
        yield return handle.WaitForFinish();

        SceneManager.LoadScene("BaseScene");
        
        TransitionManager.Instance.Play("SlideIn");
    }

    #endregion
    
    #region Grow

    public void StartGrowIn() {
        TransitionManager.Instance.Play("GrowIn");
    }
    
    public void StopGrowIn() {
        TransitionManager.Instance.Stop("GrowIn");
    }
    
    public void StartGrowOut() {
        TransitionManager.Instance.Play("GrowOut");
    }
    
    public void StopGrowOut() {
        TransitionManager.Instance.Stop("GrowOut");
    }

    public void GrowNextScene() {
        StartCoroutine(GrowNextSceneEnumerator());
    }
    
    private IEnumerator GrowNextSceneEnumerator() {
        var handle = TransitionManager.Instance.Play("GrowOut");
        yield return handle.WaitForFinish();

        SceneManager.LoadScene("BaseScene");
        
        TransitionManager.Instance.Play("GrowIn");
    }

    #endregion
    
    #region Mask

    public void StartMaskIn() {
        TransitionManager.Instance.Play("MaskIn");
    }
    
    public void StopMaskIn() {
        TransitionManager.Instance.Stop("MaskIn");
    }
    
    public void StartMaskOut() {
        TransitionManager.Instance.Play("MaskOut");
    }
    
    public void StopMaskOut() {
        TransitionManager.Instance.Stop("MaskOut");
    }

    public void MaskNextScene() {
        StartCoroutine(MaskNextSceneEnumerator());
    }
    
    private IEnumerator MaskNextSceneEnumerator() {
        var handle = TransitionManager.Instance.Play("MaskOut");
        yield return handle.WaitForFinish();

        SceneManager.LoadScene("BaseScene");
        
        TransitionManager.Instance.Play("MaskIn");
    }

    #endregion
    
    #region Animation

    public void StartAnimationIn() {
        TransitionManager.Instance.Play("AnimationIn");
    }
    
    public void StopAnimationIn() {
        TransitionManager.Instance.Stop("AnimationIn");
    }
    
    public void StartAnimationOut() {
        TransitionManager.Instance.Play("AnimationOut");
    }
    
    public void StopAnimationOut() {
        TransitionManager.Instance.Stop("AnimationOut");
    }

    public void AnimationNextScene() {
        StartCoroutine(AnimationNextSceneEnumerator());
    }
    
    private IEnumerator AnimationNextSceneEnumerator() {
        var handle = TransitionManager.Instance.Play("AnimationOut");
        yield return handle.WaitForFinish();

        SceneManager.LoadScene("BaseScene");
        
        TransitionManager.Instance.Play("AnimationIn");
    }

    #endregion
    
}