using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private Animator _animator;
    private readonly string _run1 = "_Run1";
    private readonly string _run2 = "_Run2";
    private int _currentPoint;
    private bool _moveObject = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        float axisX;
        float axisY;

        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        if (_enemy.transform.position.x > target.transform.position.x)
        {
            if (_moveObject == true) 
            {
                axisX = -2.98f;
                axisY = 0;
                _weapon.MoveObject(axisX, axisY);
                _moveObject = false;
            }

            _animator.SetBool(_run1, false);
            _animator.SetBool(_run2, true);
        }
        else
        {
            if (_moveObject == false)
            {
                axisX = 2.82f;
                axisY = 180;
                _weapon.MoveObject(axisX, axisY);
                _moveObject = true;
            }

            _animator.SetBool(_run2, false);
            _animator.SetBool(_run1, true);
        }
    }
}