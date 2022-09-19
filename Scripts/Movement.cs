using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Music _musicJump;

    private readonly string _run2 = "_Run2";
    private readonly string _run1 = "_Run1";
    private readonly string _stop = "_Stop";
    private readonly string _jump = "_Jump";
    private bool _stopMove = false;

    private Animator _animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_stopMove == false)
        {
            _animator.SetBool(_stop, false);

            if (Input.GetKey(KeyCode.D))
            {
                _animator.SetBool(_run2, false);
                _animator.SetBool(_jump, false);
                _animator.SetBool(_run1, true);
                transform.Translate(_speed * Time.deltaTime, 0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _animator.SetBool(_run1, false);
                _animator.SetBool(_jump, false);
                _animator.SetBool(_run2, true);
                transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _musicJump.PlayMusic();
                _animator.SetBool(_run2, false);
                _animator.SetBool(_run1, false);
                _animator.SetBool(_jump, true);
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            _stopMove = true;
            _animator.SetBool(_run1, false);
            _animator.SetBool(_run2, false);
            _animator.SetBool(_jump, false);
            _animator.SetBool(_stop, true);
        }
        else
        {
            _stopMove = false;
        }
    }
}