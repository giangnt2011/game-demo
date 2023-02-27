using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float input;

    public float speed = 5f;
    public Rigidbody rb;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetInput("Horizontal"))
        {
            MovePlayer();
        }

    }

    bool GetInput(string horizontal)
    {
        input = - Input.GetAxis(horizontal) * speed;

        Debug.Log(input);

        return (Mathf.Abs(input) > 0.01f);
    }

    void MovePlayer()
    {
        Debug.Log("moving");
        rb.velocity = Vector3.Normalize(new Vector3((float)(speed*2.5), 0, input)) * speed;
        _animator.SetTrigger("Fast_Run");
    }
}
