using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Test : MonoBehaviour
{
    private int GCD(int a,int b)
    {
        while(a > 1 && b > 1)
        {
            if (a > b) a = a % b;
            else b = b % a;

            if (a > 1) return a;
            else return b;
        }

        return 0;
    }

    private int[] array = new int[5];

    [SerializeField] public class Action
    {
        public int m_Value { get; set; }

        private int m_Hp = 100;

        private int m_Power = 50;

        private bool m_IsDeath = false;

        public int Add(int a,int b)
        {
            int c = a + b;
            return c;
        }

        public void Attac()
        {
            Debug.Log(this.m_Power + "のダメージを与えた");
        }

        public void Damage(int damage)
        {
            this.m_Hp -= damage;

            Debug.Log(damage + "のダメージを受けた");
        }

        public void Update()
        {
            if(this.m_Hp <= 0)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                this.Attac();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                this.Damage(100);
            }
        }
    }

    Action actUpdate = new Action();
    
    class Vector3
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello kumamon");

        for(int i = 0; i < 10; i++)
        {
            Debug.Log(GCD(i*17, i+1*11));
        }

        array[0] = 1239;
        array[1] = 4930;
        array[2] = 0572;
        array[3] = 5720;
        array[4] = 4927;


        for(int i = 0; i < array.Length; i++)
        {
            Debug.Log(array[i]);
        }

        Action action = new Action();

        Debug.Log(action.Add(100, 200));
        
    }

    // Update is called once per frame
    void Update()
    {
        actUpdate.Update();

        Vector2 startPos = new Vector2(2.0f, 1.0f);
        Vector2 endPos = new Vector2(8.0f, 5.0f);
        Vector2 dir = endPos - startPos;

        float len = dir.magnitude;

        

        Debug.Log(len);
    }
}
