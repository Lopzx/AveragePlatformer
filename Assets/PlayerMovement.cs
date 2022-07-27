using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform trans_component;
    Animator animator;
    public Vector2 prev_pos;
    Rigidbody2D rigidbody;
    BoxCollider2D BoxCollider;
    public bool isjumping;

    // Start is called before the first frame update
    void Start()
    {
        trans_component = this.GetComponent<Transform>();
        animator = GetComponent<Animator>();
        animator.speed = 0.5f;
        prev_pos = trans_component.position;
        rigidbody = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    private bool grounded()
    {
        float extraspace = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(BoxCollider.bounds.center, Vector2.down, BoxCollider.bounds.extents.y + extraspace );
        Debug.Log(hit.distance);
        Debug.Log(hit.collider);
        Debug.DrawRay(BoxCollider.bounds.center, (Vector2.down * BoxCollider.bounds.extents), Color.green, 0.05f);
        if(hit.collider == null ){
            return true;
        } else {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        prev_pos = trans_component.position;
        if (Input.GetButton("Horizontal"))
        {
            float input = Input.GetAxis("Horizontal");
            Vector2 new_val = new Vector2(input * Time.deltaTime * 3 + prev_pos.x, prev_pos.y);
            trans_component.position = new_val;

            animator.Play("Running");
            if (new_val.x - prev_pos.x <= 0f)
            {
                trans_component.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (new_val.x - prev_pos.x > 0f)
            {
                trans_component.rotation = Quaternion.Euler(0, 0, 0);
            }

            /*prev_pos = new_val;*/
        }
        else
        {
            animator.Play("Idle");
        }


        if (Input.GetButtonDown("Jump") && !isjumping) {
            isjumping = true;
            rigidbody.AddForce(new Vector2(0, 300f));
        } else if (!Input.GetButtonDown("Jump"))
        {
            isjumping = grounded();
        }
    }


}
