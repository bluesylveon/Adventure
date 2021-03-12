using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _anim;
    private static readonly string Walk = "Walk";
        private static readonly string isMoving = "isMoving";

    // private static readonly int Walk = Animator.StringToHash("Walk");
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();

    }



    void move()
    {
        float speed = 8;

        int movement = 10; 
        if(Input.GetKey("a") || Input.GetKey("d")  ){
            if(Input.GetKey("a") ){
                 _anim.Play("Left");
                movement*=-1;
            } else if(Input.GetKey("d") ){
                _anim.Play("Right");
            }
            transform.Translate(new Vector2(movement, 0) *  Time.deltaTime);

        }
        else if(Input.GetKey("w") || Input.GetKey("s") ){
            if(Input.GetKey("s")){
                _anim.Play("Down");
                movement*=-1;
            } else if (Input.GetKey("w")){
                _anim.Play("Up");
                // transform.Translate(new Vector2(0, 16) *  Time.deltaTime);
            _anim.SetBool(isMoving, false);
            }
            transform.Translate(new Vector2(0, movement) *  Time.deltaTime);

        } else {
            _anim.SetBool(isMoving, false);
            _anim.SetInteger(Walk, 0);
        }
    }
}
