using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D _rigid;
    float _speed = 6;
    Vector3 _dir = Vector3.zero;
    bool _grounded = true;
    int _nFish = 3;


    //public Text _xtx;
    //public Text _ytx;
    //public Text _ztx;

    public GameObject gameover;


    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        gameover.SetActive(false);
    }

    private void Update()
    {
        _dir.x = Input.acceleration.x;
        _dir.y = Input.acceleration.y;
        _dir.z = Input.acceleration.z;

        //_xtx.text = _dir.x.ToString();
        //_ytx.text = _dir.y.ToString();
        //_ztx.text = _dir.z.ToString();

        _rigid.velocity = new Vector2(_dir.x * _speed, _rigid.velocity.y);

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        if (hitinfo.collider != null)
        {
            _grounded = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //gameover.SetActive(true);

        if (collision.CompareTag("Spikes"))
        {
            gameover.SetActive(true);
        }
        else if (collision.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
            _nFish -= 1;
            Debug.Log(_nFish);
            if (_nFish <= 0)
            {
                gameover.SetActive(true);
            }
        }
    }

    public void JumpCat()
    {
        if (_grounded)
        {
            _rigid.velocity = new Vector2(_dir.x * _speed, _speed * 1.7f);
            _grounded = false;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Home");
    }
}
