using System;
using UnityEngine;

public class EchoMenu : MonoBehaviour {
  private Animator animator;
  public virtual async Awaitable MenuOpen() {
    animator.speed = 1;
    await Awaitable.NextFrameAsync();
    animator.Play("MenuOpen");
    Debug.Log($"Menu {this.ToString()}");
    await WaitForAnimation();
    Debug.Log("Menu Opened");
  }
  public virtual void MenuOpenPrep() {
    gameObject.SetActive(true);
    animator = GetComponent<Animator>();
    animator.speed = 0;
    animator.Play("MenuOpen");
  }
  public virtual async Awaitable MenuClose() {
    animator.StopPlayback();
    animator.Play("MenuClose");
    await WaitForAnimation();
    gameObject.SetActive(false);
    Debug.Log("Menu closed");
  }
  protected async Awaitable WaitForAnimation() {
    float counter = 0;
    float waitTime = animator.GetCurrentAnimatorStateInfo(0).length;
    Debug.Log($"Wait for {waitTime}");
    while (counter < waitTime) {
      counter += Time.deltaTime;
      await Awaitable.NextFrameAsync();
    }
  }
}