using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text CountText;
    public Text WinText;
    private int count;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        WinText.text = "";
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement*speed);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        CountText.text = "Count:" + count.ToString();
        if(count>=12)
        {
            WinText.text = "You Win";
        }
    }

}
