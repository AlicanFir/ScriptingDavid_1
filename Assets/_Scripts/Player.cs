using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Control Keys")]
    [SerializeField]
    private KeyCode upKey;
    [SerializeField]
    private KeyCode downKey;

    [Header("Player Settings")]
    [SerializeField, Range(5, 20)]
    private float speed;

    [SerializeField]
    private Transform topLimit, bottomLimit;

    private Transform _transform;

    private float _topLimitFinal, _bottomLimitFinal;

    private void Awake()
    {
        _transform = transform;

        _topLimitFinal = topLimit.position.y - _transform.localScale.y * 0.5f;
        _bottomLimitFinal = bottomLimit.position.y + _transform.localScale.y * 0.5f;
    }

    private void Update()
    {
        if (Input.GetKey(upKey))
        {
            _transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
        else if (Input.GetKey(downKey))
        {
            _transform.Translate(Vector3.down * (speed * Time.deltaTime));
        }

        if (_transform.position.y > _topLimitFinal)
        {
            _transform.position = new Vector3(_transform.position.x, _topLimitFinal, 0);
        }
        if (_transform.position.y < _bottomLimitFinal)
        {
            _transform.position = new Vector3(_transform.position.x, _bottomLimitFinal, 0);
        }
    }
}
