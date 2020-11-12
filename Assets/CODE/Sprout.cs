using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout : MonoBehaviour {


    public List<Sprite> growthStages = new List<Sprite>();
    public List<ColliderFrames> growthHitBoxStages = new List<ColliderFrames>();
    SpriteRenderer sprite;

    BoxCollider2D box;

    [Range(0,1)]
    public float growthI;

    public int stage;

    public List<TreeFruit> fruit = new List<TreeFruit>();

    bool sproutFruit;
    bool fruitDropped;
	// Use this for initialization
	void Start () {
        sprite = GetComponentInChildren<SpriteRenderer>();
        box = GetComponentInChildren<BoxCollider2D>();
        foreach (TreeFruit f in fruit)
        {
            f.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        float i = (growthStages.ToArray().Length-1) * growthI;


        if (growthI>=1)
        {
            if (!sproutFruit)
            {
                foreach(TreeFruit f in fruit)
                {
                    f.gameObject.SetActive(true);
                }
                sproutFruit = true;
            }
        }

        if(sproutFruit)
        {
            if(growthI<1)
            {
                foreach (TreeFruit f in fruit)
                {
                    f.gameObject.SetActive(false);
                }
                sproutFruit = false;
            }
        }
     

        stage = Mathf.CeilToInt(i);


        sprite.sprite = growthStages[stage];
        box.size = growthHitBoxStages[stage].size;
        box.offset = growthHitBoxStages[stage].offset;
		
	}


    public void DropFruit()
    {
        if(growthI>=1&&!fruitDropped)
        {
            foreach(TreeFruit f in fruit)
            {
                f.DropFruit();
            }

            fruitDropped = true;
        }
    }

    [System.Serializable]
    public struct ColliderFrames
    {
        public Vector2 offset;
        public Vector2 size;


    }
}
