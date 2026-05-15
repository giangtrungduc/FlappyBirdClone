using UnityEngine;

public class Bird : MonoBehaviour
{
    public float flapStrength = 4f;
    public float flapRot = 4f;
    public GameObject[] charactors;
    private int currentVisualIndex;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        for(int i = 0; i < charactors.Length; i++)
        {
            if(i == 0) charactors[i].gameObject.SetActive(true);
            else charactors[i].gameObject.SetActive(false);
        }
        currentVisualIndex = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetCharactor();
        }
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || IsScreenTouched()) && Manager.Instance.isPlay)
        {
            rb.linearVelocity = Vector2.up * flapStrength;
            Music.Instance.PlayWingClip();
        }
        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocity.y * flapRot);
    }
    private bool IsScreenTouched()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            return true;
        }
        return false;
    }
    private void SetCharactor()
    {
        charactors[currentVisualIndex].gameObject.SetActive(false);
        int newIndex = currentVisualIndex;
        while(newIndex == currentVisualIndex)
        {
            newIndex = Random.Range(0, charactors.Length);
        }
        currentVisualIndex = newIndex;
        charactors[currentVisualIndex].gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (Manager.Instance.isPlay)
            {
                Manager.Instance.Die();
                Animator anim = GetComponentInChildren<Animator>();
                if(anim != null)
                {
                    anim.SetTrigger("Die");
                }
                Music.Instance.PlayHitClip();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            Manager.Instance.IncreasePoint();
            Debug.Log(" +1 điểm");
            Music.Instance.PlayPointClip();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            SetCharactor();
            Destroy(collision.gameObject);
        }
    }
}
