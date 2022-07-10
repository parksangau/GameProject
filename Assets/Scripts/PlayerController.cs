using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 5;
    public float jumpForce = 800;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    private AudioSource flowerAudio;
    private int healthValue = -10;
    Animator anim;
    Rigidbody rb;


        void Start()
        {
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
            flowerAudio = GetComponent<AudioSource>();
        }

        void Update()
        {
            ControllPlayer();
        }

        void OnCollisionEnter(Collision collision)
        {
          if (collision.gameObject.tag == "Lion")
          {
            flowerAudio.Play();
            Debug.Log("LION");
          }

          if (collision.gameObject.tag == "Cat")
          {
            flowerAudio.Play();
            Debug.Log("Cat");
          }

          if (collision.gameObject.tag == "Dog")
          {
            flowerAudio.Play();
            Debug.Log("Dog");
          }

        }

        //충돌 감지 함수
        void OnTriggerEnter(Collider collision)
        {

            if (collision.gameObject.tag == "Item")
            { // tag 가 Item 인 오브젝트와 충돌 시
                collision.gameObject.SetActive(false);  //꽃을 먹은 것처럼 안 보이게 비활성화
                GameController.instance.MinusHealth(healthValue);
                flowerAudio.Play();
                Debug.Log("GET Flower!!!");
            }

        }

        void ControllPlayer()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
                anim.SetInteger("Walk", 1);
            }
            else
            {
                anim.SetInteger("Walk", 0);
            }

            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

            if (Input.GetButtonDown("Jump") && Time.time > canJump)
            {
                rb.AddForce(0, jumpForce, 0);
                canJump = Time.time + timeBeforeNextJump;
                anim.SetTrigger("jump");
            }
        }

    }
