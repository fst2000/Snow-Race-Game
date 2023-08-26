using UnityEngine;
public class UnityAnimation : IAnimation
{
    Animator animator;
    string name;

    public UnityAnimation(Animator animator, string name)
    {
        this.animator = animator;
        this.name = name;
    }

    public void Play() => animator.CrossFade(name, 0.1f);
}