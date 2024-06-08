using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 3;
    Rigidbody2D rb;
    BoxCollider2D coll;
    Vector2 inputDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 dir = (Vector3)mousePos - transform.position;
        transform.up = dir;

        rb.velocity = inputDir.normalized * speed;

        Vector3 minPos = Camera.main.ViewportToWorldPoint(Vector3.zero) + (transform.position - coll.bounds.min);
        Vector3 maxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)) + (transform.position - coll.bounds.max);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x), Mathf.Clamp(transform.position.y, minPos.y, maxPos.y));
    }

    public void SetInputDir(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
    }
}
