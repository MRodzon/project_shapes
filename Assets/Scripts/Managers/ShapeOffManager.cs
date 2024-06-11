using Shapes.Core;
using System;
using System.Threading.Tasks;

namespace Shapes.Managers
{
    public class ShapeOffManager : IShapeOffManager
    {
        #region Variables

        private IUIManager uiManager;

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
            var playerShape = SelectShape(type);

            var shapeToHurt = GetShapeOffVictim(playerShape, selectedEnemyShape);

            await uiManager.ShapeOffAttackStage(selectedEnemyShape);

            if (shapeToHurt != null)
            {
                await uiManager.ShapeOffFallout(shapeToHurt);
            }
        }

        public ShapeTypes SelectEnemyShape()
        {
            selectedEnemyShape = SelectRandomShape();

            return selectedEnemyShape.GetShapeType();
        }

        #endregion Public methods

        #region Private methods

        private IShape GetShapeOffVictim(IShape playerShape, IShape enemyShape)
        {
            if (playerShape.GetShapeType() == enemyShape.GetShapeType())
            {
                return null;
            }

            switch (playerShape.GetShapeType())
            {
                case ShapeTypes.Triangle:
                    return enemyShape.GetShapeType() == ShapeTypes.Circle ? enemyShape : playerShape;

                case ShapeTypes.Circle:
                    return enemyShape.GetShapeType() == ShapeTypes.Square ? enemyShape : playerShape;

                case ShapeTypes.Square:
                    return enemyShape.GetShapeType() == ShapeTypes.Triangle ? enemyShape : playerShape;

                default:
                    return null;
            }
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