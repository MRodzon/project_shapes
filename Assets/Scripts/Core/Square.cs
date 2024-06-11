namespace Shapes.Core
{
    public class Square : IShape
    {
        #region Variables

        private ShapeTypes shapeType;

        #endregion Variables

        #region Constructors

        public Square()
        {
            shapeType = ShapeTypes.Square;
        }

        #endregion Constructors

        #region Public methods

        public ShapeTypes GetShapeType()
        {
            return shapeType;
        }

        #endregion Public methods
    }
}