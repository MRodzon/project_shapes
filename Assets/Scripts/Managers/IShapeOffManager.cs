using System.Threading.Tasks;

namespace Shapes.Core
{
    public interface IShapeOffManager
    {
        #region Public methods

        Task Combat(ShapeTypes type);

        ShapeTypes SelectEnemyShape();

        #endregion Public methods
    }
}