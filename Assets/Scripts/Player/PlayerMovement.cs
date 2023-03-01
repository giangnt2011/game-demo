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
    private bool isMoving = false;

    private Touch touch;
    private float deltaTouchBefore = 0f;

    private bool active { get; set; }
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        EnableDriving(true);


    }
    // Update is called once per frame
    private void Update()
    {
        if (win)
        {
            Win();
            return;
        }
        GetTouchMove();
        if (isMoving)
        {
            MovePlayer();
        }
        

    }

    private void GetTouchMove()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            isMoving = true;

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
                    }
                }
            }
        }
    }
    public void SetEndPoint(Vector3 endpoint)
    {
        EndPoint = endpoint;
    }
    void MovePlayer()
    {
        //Debug.Log(Sliderslider.value);
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(Sliderslider.value, 0, transform.position.z + 0.5f), speed * Time.deltaTime);
        _animator.SetBool("Run", true);
    }
    public void MoveToWinPoint(Vector3 End)
    {
        win = true;
        player.velocity = Vector3.zero;
        StartCoroutine(SwitchAnimation());
        
    }

    private void Win()
    {
        EnableDriving(false);
        player.transform.position = Vector3.Lerp(player.transform.position, EndPoint, stepWin);
    }

    IEnumerator SwitchAnimation()
    {
        yield return new WaitForSeconds(.8f);
        _animator.SetBool("Run", false);
        _animator.SetBool("Dance", true);
    }
    public void EnableDriving(bool enable)
    {
        active = enable;
    }
}
