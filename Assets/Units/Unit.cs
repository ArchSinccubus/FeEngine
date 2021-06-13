using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{

    #region Unity Events

    public UnityEvent DieEvent;

    public UnityEvent<int> TakeDamageEvent;

    public UnityEvent<CustomFETile> MovedToTileEvent;

    public UnityEvent<int> HealDamageEvent;

    public UnityEvent HPChangedEvent;

    public UnityEvent LevelUpEvent;

    #endregion

    public UnitSO BaseDetails;

    public string Name;

    public StatsStruct baseStats, currStats;

    public bool PermaDeath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Initialization
    public void InitUnit(UnitSO basis)
    {
        BaseDetails = basis;
        Name = basis.Name;

        currStats = baseStats = basis.BaseStats;
    }

    
    public void initForCombat()
    {

    } 
    #endregion

    #region Events
    private void AffectHP(int amount)
    {
        Debug.Log(amount);

    }

    private void HPChanged()
    {

    }

    private void LevelUp()
    { 
        
    }

    private void Die()
    {
        if (PermaDeath)
        {
            //Make sure to set their death on and that they can't come back.
        }
        else
        {
            //Make sure they can return in the next map.
        }
    }

    private void MoveToTile(CustomFETile Tile)
    {

    } 
    #endregion



    
}
