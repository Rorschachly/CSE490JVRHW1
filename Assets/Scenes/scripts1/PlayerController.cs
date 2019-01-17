using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpAmount;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool jump = Input.GetKeyDown(KeyCode.Space);

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        if (jump)
        {
            rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * jumpAmount, ForceMode.Impulse);
            
        }

        rb.AddForce(movement * speed);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 0)
        {
            winText.text = "You Win!";
        }
    }
}