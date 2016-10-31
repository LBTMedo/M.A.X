using UnityEngine;
using System.Collections;

    public class Labirint3Gumbi : MonoBehaviour
    {

        public GameObject Trigger3;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D coll)
        {

            if (coll.name == Trigger3.name)
            {
                Debug.Log("Trigger3", gameObject);
            }
            else
            {
                Debug.Log("Trigger1", gameObject);

            }


        }
    }

