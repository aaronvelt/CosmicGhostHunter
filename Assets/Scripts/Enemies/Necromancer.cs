using UnityEngine;

public class Necromancer : Enemy
{
    public enum stateEnum { Asleep, Summoning };
    public stateEnum state;
    public float summonTimeDelay = 10f;
    public float summonStartTime = 3f;
    private bool isSummoning = false;

    public Transform summoningPoint;
    public GameObject Ghost;

    // check necromancers state
    void CheckState()
    {
        switch (state)
        {
            case stateEnum.Asleep:
                Asleep();
                break;
            case stateEnum.Summoning:
                summoning();
                break;
        }
    }

    void Update()
    {
        CheckState();
        base.ShowHealthDisplay();
    }

    // Do nothing when asleep (Testing purposes)
    void Asleep()
    {

    }

    // InvokeRepeating SummonGhost once
    void summoning()
    {
        if (!isSummoning)
        {
            InvokeRepeating("SummonGhost", summonStartTime, summonTimeDelay);
            isSummoning = true;
        }
    }

    // instantiate ghost at summonpoint position with Attack state
    void SummonGhost()
    {
        GameObject summonedGhost = Ghost;
        summonedGhost.GetComponent<GhostBehaviour>().state = GhostBehaviour.stateEnum.Attack;
        Instantiate(summonedGhost, summoningPoint.position, transform.rotation);
    }

    public override void damageReaction()
    {
        
    }
}
