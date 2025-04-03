using UnityEngine;

public class EchoMenu : MonoBehaviour {
  private Animator animator;
  public virtual async Awaitable MenuOpen() {
    gameObject.SetActive(true);
    animator = GetComponent<Animator>();
    Debug.Log($"Menu {this.ToString()}");
    animator.Play("MenuOpen");
    await WaitForAnimation();
    Debug.Log("Menu Opened");
  }
  public virtual async Awaitable MenuClose() {
    animator.StopPlayback();
    animator.Play("MenuClose");
    await WaitForAnimation();
    gameObject.SetActive(false);
    Debug.Log("Menu closed");
  }
  private async Awaitable WaitForAnimation() {
    float counter = 0;
    float waitTime = animator.GetCurrentAnimatorStateInfo(0).length;
    while (counter < waitTime) {
      counter += Time.deltaTime;
      await Awaitable.NextFrameAsync();
    }
  }
}