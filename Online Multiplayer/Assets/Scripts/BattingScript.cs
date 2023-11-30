using UnityEngine;

public class BattingScript : MonoBehaviour
{

    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right click");
            anim.SetBool("isBatting", true);
        }
        else
        {
            anim.SetBool("isBatting", false);
        }

    }
}
