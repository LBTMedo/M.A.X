using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeBlocks : MonoBehaviour {

    public Sprite[] SlikeSOLID;
    public Sprite[] SlikeFLOAT;
    int tipBlockov = 1;
    private Image image;
    public static int Block = 0;
	// Use this for initialization
	void Start () {
        image = GameObject.Find("slika").GetComponent<Image>();
        if (Settings.ZamenjajTip == 1){
            
            image.sprite = SlikeSOLID[0];
        }
        else if(Settings.ZamenjajTip == 2)
        {
            image.sprite = SlikeFLOAT[0];
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Settings.ZamenjajTip == 1 && Settings.ZamenjajTip != tipBlockov)
        {
            tipBlockov = Settings.ZamenjajTip;
            image.sprite = SlikeSOLID[0];
        }
        else if(Settings.ZamenjajTip == 2 && Settings.ZamenjajTip != tipBlockov)
        {
            tipBlockov = Settings.ZamenjajTip;
            image.sprite = SlikeFLOAT[0];
        }
	
	}
   public void ZamenjajBlocke()
    {
        if(tipBlockov == 1)
        {
            if (Block < 3)
            {
            
                Block++;
                Debug.Log(Block);
                if (Block == 1)
                {
                    image.sprite = SlikeSOLID[Block];

                }
                if (Block == 2)
                {
                    image.sprite = SlikeSOLID[Block];

                }
                else if (Block == 3)
                {
                    image.sprite = SlikeSOLID[Block];

                }


            }
            else if (Block == 3)
            {
                Block = 0;
                image.sprite = SlikeSOLID[Block];
            }

        }
        else
        {
            if (Block < 3)
            {
                Block++;
                Debug.Log(Block);
                if (Block == 1)
                {
                    image.sprite = SlikeFLOAT[Block];

                }
                if (Block == 2)
                {
                    image.sprite = SlikeFLOAT[Block];

                }
                else if (Block == 3)
                {
                    image.sprite = SlikeFLOAT[Block];

                }


            }
            else if (Block == 3)
            {
                Block = 0;
                image.sprite = SlikeFLOAT[Block];
            }

        }
    }
}
