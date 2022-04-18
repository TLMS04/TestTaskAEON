using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Rigidbody _rb;
    private DateTime _time;
    // Start is called before the first frame update
    void Start()
    {
        _time = DateTime.Now;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        _rb.AddForce(movement * _speed);


    }
    void OnTriggerEnter(Collider other)
    {
        var result = Result.GetInstance();
        string resultText = "";
        if (other.TryGetComponent(out FinishZone finishZone))
        {
            resultText = $"Вы выиграли за {(DateTime.Now-_time).Seconds} (секунд)";
            
        }
        else
        {
            resultText = "Вы проиграли";
        }
        result.SetText(resultText);
        SceneManager.LoadScene("MainMenu");
    }
}
