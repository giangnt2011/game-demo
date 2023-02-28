using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private Animator _animator;
    [SerializeField] [Range(-1,1)] private float input;

    public float speed = 5f;
    [SerializeField] private Rigidbody player;

    bool win = false;
    private Vector3 EndPoint;

    [SerializeField] private Slider Sliderslider;

    [SerializeField] private Driver driver;

    [SerializeField] private float stepWin;

    private Touch touch;
    private float deltaTouchBefore = 0f;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        driver.EnableDriving(true);


    }
    // Update is called once per frame
    private void Update()
    {
        if (win)
        {
            Win();
            return;
        }
        
        if (GetTouchMove())
        {
            MovePlayer();
        }
        
    }

    private bool GetTouchMove()
    {
        //input = - Input.GetAxis(horizontal);

        //Debug.Log(input);
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (Mathf.Abs(touch.deltaPosition.x - deltaTouchBefore) > 0 )
                {
                    if(Sliderslider.value < 1 || Sliderslider.value > -1)
                    {
                        if(touch.deltaPosition.x < 0)
                        {
                            Sliderslider.value -= 0.08f;
                        }
                        else
                        {
                            Sliderslider.value += 0.08f;
                        }
                        return true;
                    }
                }
            }
        }

        return false;
    }
    public void SetEndPoint(Vector3 endpoint)
    {
        EndPoint = endpoint;
    }
    void MovePlayer()
    {
       Debug.Log("moving");
        transform.Translate(EndPoint.normalized *speed*Time.deltaTime);

        _animator.SetBool("Run", true);
    }
    public void MoveToWinPoint(Vector3 End)
    {
        win = true;
        //EndPoint = End;
        //Vector3 position = Vector3.Lerp(player.transform.position, End, 1f);
        //player.transform.position = Vector3.MoveTowards(player.transform.position, position, speed*2);
        player.velocity = Vector3.zero;
        StartCoroutine(SwitchAnimation());
        
    }

    private void Win()
    {
        Debug.Log(EndPoint);
        driver.EnableDriving(false);
        player.transform.position = Vector3.Lerp(player.transform.position, EndPoint, stepWin);
    }

    IEnumerator SwitchAnimation()
    {
        yield return new WaitForSeconds(.8f);
        _animator.SetBool("Run", false);
        _animator.SetBool("Dance", true);
    }
}
