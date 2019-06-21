using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float _speed = 3.0f;
    public bool _vertical;
    Rigidbody2D _rigidbody2d;
    public float _changeTime = 3.0f;
    public float _timer;
    Animator _animator;
    int _direction = 1;
    bool _broken = true;
    public ParticleSystem _smokeEffect;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _timer = _changeTime;
        _animator = GetComponent<Animator>();
        _smokeEffect = gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_broken)
        {
            return;
        }

        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            _direction = -_direction;
            _timer = _changeTime;
        }
        Vector2 position = _rigidbody2d.position;

        if (_vertical)
        {
            _animator.SetFloat("Move X", 0);
            _animator.SetFloat("Move Y", _direction);

            position.y = position.y + Time.deltaTime * _speed * _direction;

        }
        else
        {
            _animator.SetFloat("Move X", _direction);
            _animator.SetFloat("Move Y", 0);


            position.x = position.x + Time.deltaTime * _speed * _direction;
            float yar = position.x + Time.deltaTime * _speed * _direction;

        }
        //Debug.Log(position);
        _rigidbody2d.MovePosition(position);


    }
    public void Fix(){
        _broken =false;
        _rigidbody2d.simulated =false;
        _animator.SetTrigger("Fixed");
        _smokeEffect.Stop();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }

    }
}
