using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{

    [SerializeField] float speed = 2f;

    private Animator animator;

    [SerializeField] Transform cam;

    Rigidbody rb;

    CapsuleCollider caps;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
        //RigidbodyのConstraintsを3つともチェック入れて
        //勝手に回転しないようにする
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        //CapsuleColliderコンポーネントを取得
        caps = GetComponent<CapsuleCollider>();
        //CapsuleColliderの中心の位置を決める
        caps.center = new Vector3(0, 0.76f, 0);
        //CapsuleColliderの半径を決める
        caps.radius = 0.23f;
        //CapsuleColliderの高さを決める
        caps.height = 1.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) return;

        //A・Dキー、←→キーで横移動
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        //W・Sキー、↑↓キーで前後移動
        float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        //AnimatorControllerのParametersに数値を送って
        //アニメーションを出す
        animator.SetFloat("X", x * 100);
        animator.SetFloat("Y", z * 200);

        //前移動の時だけ方向転換をさせる
        if (z != 0 || x != 0) 
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                    cam.eulerAngles.y, transform.rotation.z));
        }

        //xとzの数値に基づいて移動
        transform.position += (transform.forward * z) + (transform.right * x);

        
    }
}

