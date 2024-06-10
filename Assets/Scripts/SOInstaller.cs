using UnityEngine;
using Zenject;

namespace Shapes.Installers
{
    [CreateAssetMenu(fileName = "SOInstaller", menuName = "Installers/SOInstaller")]
    public class SOInstaller : ScriptableObjectInstaller<SOInstaller>
    {
        #region Variables

        [SerializeField]
        private GlobalValuesSO globalValuesSO;
        
        #endregion Variables

        #region Public methods

        public override void InstallBindings()
        {
            Container.BindInstance(globalValuesSO);
        }

        #endregion Public methods
    }
}