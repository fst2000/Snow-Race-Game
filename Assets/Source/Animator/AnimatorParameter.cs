using UnityEngine;
public class AnimatorParameter : IParameter
{
    Animator animator;
    string name;

    public AnimatorParameter(Animator animator, string name)
    {
        this.animator = animator;
        this.name = name;
    }

    public void Load(float param)
    {
        animator.SetFloat(name, param);
    }
}