using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    public GameObject ObjectMove;
    public Transform Start1;
    public Transform End1;

    public float Speed;

    private Vector3 MoveTo;

    // Start is called before the first frame update
    void Start()
    {
        MoveTo = End1.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectMove.transform.position = Vector3.MoveTowards(ObjectMove.transform.position, MoveTo, Speed * Time.deltaTime);

        if(ObjectMove.transform.position == End1.position)
        {
            MoveTo = Start1.position;
        }
        if (ObjectMove.transform.position == Start1.position)
        {
            MoveTo = End1.position;
        }
    }
}
