using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    public float WalkSpeed;
    public float JumpForce;
    public AnimationClip _walk, _jump;
    public Animation _Legs;
    public Transform _Blade, _GroundCast;
    public Camera cam;
    public bool mirror;


    private bool _canJump, _canWalk;
    private bool _isWalk, _isJump;
    private float rot, _startScale;
    private Rigidbody2D rig;
    private Vector2 _inputAxis;
    private RaycastHit2D _hit;
    public AudioSource Walksound;
    public AudioSource Jumpsound;
    public AudioSource Heartsound;
    public GameObject Diploma;
    public bool isHit;

    private Vector2 knockBack = new Vector2(0,0);



    void Start()
    {
        rig = gameObject.GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
    }

    void Update()
    {
        if (_hit = Physics2D.Linecast(new Vector2(_GroundCast.position.x, _GroundCast.position.y + 0.2f), _GroundCast.position))
        {
            if (!_hit.transform.CompareTag("Player"))
            {
                _canJump = true;
                _canWalk = true;
            }
        }
        else _canJump = false;

        _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (_inputAxis.y > 0 && _canJump)
        {
            _canWalk = false;
            _isJump = true;
        }
        if (isHit == true)
        {
            rig.AddForce(new Vector2(150, 120));
            isHit = false;

        }


    }

    void FixedUpdate()
    {

        Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - _Blade.transform.position;
        dir.Normalize();

        if (cam.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x + 0.2f)
            mirror = false;
        if (cam.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x - 0.2f)
            mirror = true;

        if (!mirror)
        {
            rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.localScale = new Vector3(_startScale, _startScale, 1);
            _Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }
        if (mirror)
        {
            rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
            transform.localScale = new Vector3(-_startScale, _startScale, 1);
            _Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }

        if (_inputAxis.x != 0)
        {
            rig.velocity = new Vector2(_inputAxis.x * WalkSpeed * Time.deltaTime, rig.velocity.y);

            if (_canWalk)
            {
                _Legs.clip = _walk;
                _Legs.Play();
                if (!Walksound.isPlaying)
                {
                    Walksound.Play();
                }

            }
        }
        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
        }
        //add knockback velocity and apply some friction
        rig.velocity+=knockBack;
        knockBack = knockBack * 0.9f;

        if (_isJump)
        {
            rig.AddForce(new Vector2(0, JumpForce));
            _Legs.clip = _jump;
            _Legs.Play();
            _canJump = false;
            _isJump = false;
            if (!Jumpsound.isPlaying)
            {
                Jumpsound.Play();
            }
        }
    }

    public bool IsMirror()
    {
        return mirror;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _GroundCast.position);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Scroll")
        {
            Diploma.SetActive(true);
            if (Diploma == null)
            {
                Destroy(col.gameObject);
            }
            else
            {
                Destroy(col.gameObject);
            }

        }
        //Knockback
        if(col.tag == "Boss")
        {
            print("hit by boss");
            Vector2 bossVeloc = col.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
            //print(bossVeloc);
            //bossVeloc.x *= 5;
            knockBack = bossVeloc;
           
        }


    }
  
}

    /*public IEnumerator Knockback (float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while( knockDur > timer )
    
            timer += Time.deltaTime;

        //rig.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        //rig.AddForce(knockbackDir * -500f);
        // rig.AddForce(new Vector2(knockbackDir.x, knockbackDir.y));
        if (_inputAxis.x < 0)
        {
            float xDir = knockbackDir.x * 100000;
            rig.AddForce(new Vector2(xDir, knockbackDir.y * -1000));
        }
        else
        {
            float xDir = knockbackDir.x * -100000;
            rig.AddForce(new Vector2(xDir, knockbackDir.y * -1000));
        }
        yield return 0;
      }
       
    }

    public void Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            //rig.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
            //rig.AddForce(knockbackDir * -500f);
            // rig.AddForce(new Vector2(knockbackDir.x, knockbackDir.y));
            if (_inputAxis.x < 0)
            {
                float xDir = knockbackDir.x * 100000;
                rig.AddForce(new Vector2(xDir, knockbackDir.y * -1000));
            }
            else
            {
                float xDir = knockbackDir.x * -100000;
                rig.AddForce(new Vector2(xDir, knockbackDir.y * -1000));
            }

        }
    }

}
*/