using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private readonly string _run1 = "_Run1";
    private readonly string _run2 = "_Run2";

    private Transform[] _points;
    private int _currentPoint;
    private Animator _animator;

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

        if (_enemy.transform.position.x < target.transform.position.x)
        {
            _animator.SetBool(_run2, false);
            _animator.SetBool(_run1, true);
        }
        else
        {
            _animator.SetBool(_run1, false);
            _animator.SetBool(_run2, true);
        }
    }
}