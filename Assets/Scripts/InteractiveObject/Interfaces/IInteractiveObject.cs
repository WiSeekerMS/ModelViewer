namespace InteractiveObject.Interfaces
{
    public interface IInteractiveObject : IObjectTransform, 
        IObjectOutline, IObjectEffect, IObjectLocalization
    {
        bool Visibility { get; set; }
        void SetVisibilityBodyFront(bool isVisible);
    }
}