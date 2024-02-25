using UnityEngine;

namespace HW_1.Task4
{
    [RequireComponent(typeof(Ball))]
    public class BallView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Material _redMaterial;
        [SerializeField] private Material _whiteMaterial;
        [SerializeField] private Material _greenMaterial;
        
        private Ball _ball;

        private void Start()
        {
            SetColor();
        }

        private void OnValidate()
        {
            if (_ball == null)
                _ball = GetComponent<Ball>();

            if (_renderer != null
                && _redMaterial != null
                && _whiteMaterial != null
                && _greenMaterial != null)
            {
                switch (_ball.Type)
                {
                    case BallType.Red:
                        _renderer.sharedMaterial = _redMaterial;
                        break;
                    case BallType.White:
                        _renderer.sharedMaterial = _whiteMaterial;
                        break;
                    case BallType.Green:
                        _renderer.sharedMaterial = _greenMaterial;
                        break;
                }
            }
        }

        [EditorButton]
        private void SetColor()
        {
            switch (_ball.Type)
            {
                case BallType.Red:
                    _renderer.sharedMaterial = _redMaterial;
                    break;
                case BallType.White:
                    _renderer.sharedMaterial = _whiteMaterial;
                    break;
                case BallType.Green:
                    _renderer.sharedMaterial = _greenMaterial;
                    break;
            }
        }
    }
}