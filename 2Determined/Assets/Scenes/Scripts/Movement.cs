using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float acceleration;
    public float maxSpd;

    float moveSpd = 0;


    // Update is called once per frame
    void Update()
    {

        Vector3 current;

        //Moves character left
        if (Input.GetKey(KeyCode.RightArrow))
        {

            //accelerates the character
            if (this.moveSpd < this.maxSpd)
            {
                this.moveSpd += acceleration;

                // puts character at the intended speed
                if (this.moveSpd > this.maxSpd)
                {
                    this.moveSpd = this.maxSpd;
                }
            }

            current = new Vector3(this.transform.position.x + this.moveSpd, this.transform.position.y, this.transform.position.z);

            this.transform.position = current;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //accelerates the character
            if (this.moveSpd > -(this.maxSpd))
            {
                this.moveSpd -= acceleration;

                // puts character at the intended speed
                if (this.moveSpd < -(this.maxSpd))
                {
                    this.moveSpd = (-this.maxSpd);
                }
            }

            current = new Vector3(this.transform.position.x + this.moveSpd, this.transform.position.y, this.transform.position.z);

            this.transform.position = current;
        }

        else
        {
            //accelerates the character
            if (this.moveSpd > 0)
            {
                this.moveSpd -= acceleration;

                // puts character at the intended speed
                if (this.moveSpd < 0)
                {
                    this.moveSpd = 0;
                }
            }

            this.transform.position.Set(this.transform.position.x + this.moveSpd, this.transform.position.y, this.transform.position.z);
        }



    }


}