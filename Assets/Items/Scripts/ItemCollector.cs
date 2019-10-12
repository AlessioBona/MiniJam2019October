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
            print(nextItem.GetItemType());
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

            //destroy the item
            Destroy(nextItem.gameObject);
        }
    }
}
