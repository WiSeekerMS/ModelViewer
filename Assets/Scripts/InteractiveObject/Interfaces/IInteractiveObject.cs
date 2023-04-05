namespace InteractiveObject.Interfaces
{
    public interface IInteractiveObject : IObjectTransform, IObjectOutline, 
        IObjectDecompose, IObjectAnimated, IObjectLocalization
    {
        bool Visibility { get; set; }
        void SetVisibilityBodyFront(bool isVisible);
    }
}