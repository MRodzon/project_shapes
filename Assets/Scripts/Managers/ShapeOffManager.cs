using Shapes.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shapes.Managers
{
    public class ShapeOffManager : IShapeOffManager
    {
        #region Variables

        private IUIManager uiManager;

        private List<IShape> enemyShapes;

        private IShape selectedEnemyShape;

        #endregion Variables

        #region Constructors

        public ShapeOffManager(IUIManager uiManager)
        {
            this.uiManager = uiManager;
        }

        #endregion Constructors

        #region Public methods

        public async Task Combat(ShapeTypes type)
        {
            var shape = SelectShape(type);

            var shapeToHurt = ShapeOffVictim(shape, selectedEnemyShape);

            await uiManager.ShapeOff(shapeToHurt);
        }

        public ShapeTypes SelectEnemyShape()
        {
            selectedEnemyShape = SelectRandomShape();

            return selectedEnemyShape.GetShapeType();
        }

        #endregion Public methods

        #region Private methods

        private IShape ShapeOffVictim(IShape shape, IShape enemyShape)
        {
            return enemyShape;
        }

        private IShape SelectShape(ShapeTypes type)
        {
            switch (type)
            {
                case ShapeTypes.Triangle:
                    return new Triangle();

                case ShapeTypes.Circle:
                    return new Circle();

                case ShapeTypes.Square:
                    return new Square();

                default:
                    return null;
            }
        }

        private IShape SelectRandomShape()
        {
            int value = UnityEngine.Random.Range(1, Enum.GetNames(typeof(ShapeTypes)).Length);

            return SelectShape((ShapeTypes)value);
        }

        #endregion Private methods
    }
}