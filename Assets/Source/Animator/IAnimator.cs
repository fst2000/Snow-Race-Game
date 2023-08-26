public interface IAnimator
{
    IAnimation StartAnimation(string name);
    IParameter ParameterFloat(string name);
}