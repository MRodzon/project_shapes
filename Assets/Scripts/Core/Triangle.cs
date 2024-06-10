namespace Shapes.Core
{
    public class Triangle : IShape
    {
        #region Variables

        private ShapeTypes shapeType;

        #endregion Variables

        #region Constructors

        public Triangle()
        {
            shapeType = ShapeTypes.Triangle;
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