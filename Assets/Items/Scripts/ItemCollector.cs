using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    PlayerMovement playerMvt;

    private void Start()
    {
        playerMvt = GetComponent<PlayerMovement>();
    }

    //everytime we're colliding with a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check whether the item we collided with has an item component
        Item nextItem = collision.gameObject.GetComponent<Item>();
        if (nextItem)
        {
            //depending on the item type
            switch (nextItem.GetItemType())
            {
                case Item.Type.clone:
                    break;

                case Item.Type.speedUp:
                    playerMvt.UpdateSpeed(nextItem.GetValue());
                    break;

                case Item.Type.jumpBuff:
                    playerMvt.UpdateJumpForce(nextItem.GetValue());
                    break;
            }

<<<<<<< HEAD
            if (nextItem.CanDestroy())
                //destroy the item
                Destroy(nextItem.gameObject);
=======
            //destroy the item
            Destroy(nextItem.gameObject);
>>>>>>> fe4561ce38f911a8914d114a7c1b78d101a667a8
        }
    }
}
