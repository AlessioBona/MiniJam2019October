
public class DNACollectable : Collectable
{
    public override void OnCollect(Clone _clone)
    {
        _clone.ONDNACollection();

        base.OnCollect(_clone);
    }
}
