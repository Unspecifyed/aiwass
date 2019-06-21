using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    public float speed = 3f;
    public int health { get { return currentHealth; } }
    protected int currentHealth;
    Rigidbody2D rigidody2d;

    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 2.0f;
    public Animator _animator;
    Vector2 _lookDirection = new Vector2(1, 0);
    public GameObject _projectile;
    public ParticleSystem _healthSparks;
    public AudioSource _audioSource;
    public AudioClip _hitS, _cogS;


    // Start is called before the first frame update
    void Start()
    {

        rigidody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _healthSparks = gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();

        currentHealth = maxHealth;

        _audioSource= GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            _lookDirection.Set(move.x, move.y);
            _lookDirection.Normalize();

        }
        _animator.SetFloat("Look X", _lookDirection.x);
        _animator.SetFloat("Look Y", _lookDirection.y);
        _animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidody2d.position;
        position = position + move * speed * Time.deltaTime;

        rigidody2d.MovePosition(position);
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
            PlaySound(_cogS);
        }
        LookRay();

    }
    public void PlaySound(AudioClip clip){
        _audioSource.PlayOneShot(clip);
    }
    void LookRay(){
        if(Input.GetKeyDown(KeyCode.X)){
            RaycastHit2D hit = Physics2D.Raycast(rigidody2d.position+ Vector2.up*0.2f,_lookDirection,1.5f, LayerMask.GetMask("NPC"));
            if( hit.collider != null){
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if(character !=null){
                    character.DisplayDialog();
                }

            }
        }

    }
    void Launch()
    {
        GameObject projectileObject = Instantiate(_projectile, rigidody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(_lookDirection, 300);
        _animator.SetTrigger("Launch");
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            _animator.SetTrigger("Hit");
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
            PlaySound(_hitS);

        }
        else
        {

            _healthSparks.Play();
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth/ (float)maxHealth);
    }
}
