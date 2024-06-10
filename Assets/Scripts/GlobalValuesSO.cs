using UnityEngine;

namespace Shapes
{
    [CreateAssetMenu(fileName = "GlobalValues", menuName = "SO/GlobalValues")]
    public class GlobalValuesSO : ScriptableObject
    {
        [SerializeField]
        private float selectionScaleSize;
        public float SelectionScaleSize => selectionScaleSize;
        [SerializeField]
        private float initialScaleTime;
        public float InitialScaleTime => initialScaleTime;
        [SerializeField]
        private float scaleMultiplier;
        public float ScaleMultiplier => scaleMultiplier;
        [SerializeField]
        private float scaleTime;
        public float ScaleTime => scaleTime;

        [SerializeField]
        private float jumpPower;
        public float JumpPower => jumpPower;
        [SerializeField]
        private int jumpCount;
        public int JumpCount => jumpCount;
        [SerializeField]
        private float jumpDuration;
        public float JumpDuration => jumpDuration;
    }
}