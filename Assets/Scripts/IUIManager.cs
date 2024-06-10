using System.Threading.Tasks;

namespace Shapes.Core
{
    public interface IUIManager
    {
        #region Public methods

        void Initialize();

        Task<ShapeTypes> AwaitShapeSelection();

        Task ReturnToShapeSelection();

        Task ShapeOff(IShape shapeToHurt);

        #endregion Public methods
    }
}