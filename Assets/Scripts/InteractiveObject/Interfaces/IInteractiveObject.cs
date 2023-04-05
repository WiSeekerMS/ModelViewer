namespace InteractiveObject.Interfaces
{
    public interface IInteractiveObject : IObjectTransform, IObjectOutline, 
        IObjectDecompose, IObjectEffect, IObjectLocalization
    {
        bool Visibility { get; set; }
        void SetVisibilityBodyFront(bool isVisible);
    }
}