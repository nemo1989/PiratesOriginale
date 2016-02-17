using UnityEngine;
using System.Collections;

public class Light : MonoBehaviour {
	
    public GameController controller;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
	void OnTriggerEnter2D(Collider2D colide)
	{
		if (colide.gameObject.tag == "Player") 
		{
            controller.isInLight = true;
		}
        if (colide.gameObject.tag == "Mirror")
        {
         
            colide.gameObject.GetComponent<MirrorScript>().showLight = true;
           
        }
	}

	void OnTriggerStay2D(Collider2D colide)
	{

		if(colide.gameObject.tag == "Player")
			{
                controller.isInLight = true;
			}
        if (colide.gameObject.tag == "Mirror")
        {
            
           colide.gameObject.GetComponent<MirrorScript>().showLight = true;
        }

	}
	void OnTriggerExit2D(Collider2D colide)
	{

		if(colide.gameObject.tag == "Player")
			{
                controller.isInLight = false;
			
			}
        if (colide.gameObject.tag == "Mirror")
        {
            colide.gameObject.GetComponent<MirrorScript>().showLight = false;
        }

	}
}
