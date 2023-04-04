namespace Parts
{
    public interface IModel : IModelTransform, IModelOutline, 
        IModelDecompose, IModelAnimated, IModelLocalization
    {
        bool Visibility { get; set; }
        void SetVisibilityBodyFront(bool isVisible);
    }
}