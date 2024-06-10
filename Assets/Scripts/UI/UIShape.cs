using DG.Tweening;
using Shapes.Core;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Shapes.UI
{
    public class UIShape : MonoBehaviour
    {
        #region Variables

        [SerializeField]
        protected Image shapeIcon;

        protected GlobalValuesSO globalValuesSO;

        protected Sequence showSequence;
        protected Sequence shapeOffSequence;

        #endregion Variables

        #region Properties

        public Image ShapeIcon => shapeIcon;

        protected ShapeTypes shapeType;
        public ShapeTypes ShapeType => shapeType;

        #endregion Properties

        #region Public methods

        public virtual void Initialize()
        {
            shapeIcon.DOFade(0, 0);

            ShowShape();
        }

        public virtual Task ShowShape()
        {
            return Task.CompletedTask;
        }

        public virtual Task HideShape()
        {
            return Task.CompletedTask;
        }

        public virtual Task ShapeAttack()
        {
            return Task.CompletedTask;
        }

        public virtual Task ShapeTakeDamage()
        {
            return Task.CompletedTask;
        }

        #endregion Public methods

        #region Private methods

        [Inject]
        private void Construct(GlobalValuesSO globalValuesSO)
        {
            this.globalValuesSO = globalValuesSO;
        }

        #endregion Private methods
    }
}