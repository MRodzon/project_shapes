namespace Shapes.Core
{
    internal class Circle : IShape
    {
        #region Variables

        private ShapeTypes shapeType;

        #endregion Variables

        #region Constructors

        public Circle()
        {
            shapeType = ShapeTypes.Circle;
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