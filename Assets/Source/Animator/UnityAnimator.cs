using UnityEngine;
public class UnityAnimator : IAnimator
{
    Animator animator;

    public UnityAnimator(Animator animator)
    {
        this.animator = animator;
    }

    public IParameter ParameterFloat(string name)
    {
        return new AnimatorParameter(animator, name);
    }

    public IAnimation StartAnimation(string name)
    {
        return new UnityAnimation(animator, name);
    }
}