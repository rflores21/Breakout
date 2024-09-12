using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playa : MonoBehaviour
{
    public string leftKey = "up";
    public string rightKey = "down";
    public string fiyaKey = "space";
    public bool _readyToFire = false;
    public GameObject _ballPrefab;
    public Ball _ball;
    

    // Start is called before the first frame update
    void Start()
    {
        if(_readyToFire)
            _ballPrefab.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftKey))
        {
            transform.Translate(new Vector2(-10f, 0f) * Time.deltaTime);
        }
        else if (Input.GetKey(rightKey))
        {
            transform.Translate(new Vector2(10f, 0f) * Time.deltaTime);
        }
        if (Input.GetKeyDown(fiyaKey)) {
            if (_readyToFire)
                Fireball();
         }

    }

    void Fireball()
    {
    {
        _readyToFire = false;
        _ballPrefab.SetActive(false);

         Ball newBall = Instantiate(_ball, _ballPrefab.transform.position, Quaternion.identity);
         float angle;
         angle = Mathf.Deg2Rad * Random.Range(60,120);
        //  if (transform.position.x < 0.0f)
        //      angle = Mathf.Deg2Rad * Random.Range(-30, 30);
        //  else
        //      angle = Mathf.Deg2Rad * Random.Range(150, 210);
         Vector2 force = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
         newBall.GetComponent<Rigidbody2D>().AddForce(force * 1.0f);
    }
    }
}
