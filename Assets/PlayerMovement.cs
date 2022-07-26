using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform trans_component;
    Animator animator;
    public Vector2 prev_pos;

    // Start is called before the first frame update
    void Start()
    {
        trans_component = this.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        animator.speed = 0.5f;
        prev_pos = trans_component.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            float input = Input.GetAxis("Horizontal");
            Vector2 new_val = new Vector2(input * Time.deltaTime * 3 + prev_pos.x, 0);
            trans_component.position = new_val;

            animator.Play("Running");

            Debug.Log(new_val.x - prev_pos.x);
            if (new_val.x - prev_pos.x <= 0f)
            {
                trans_component.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (new_val.x - prev_pos.x > 0f)
            {
                trans_component.rotation = Quaternion.Euler(0, 0, 0);
            }

            prev_pos = new_val;
        } else {
            animator.Play("Idle");
        }
    }


}
