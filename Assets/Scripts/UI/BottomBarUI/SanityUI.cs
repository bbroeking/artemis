using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityUI : MonoBehaviour
{
    [SerializeField] private CellUI[] cells;
    // Start is called before the first frame update
    void Start()
    {
        cells = GetComponentsInChildren<CellUI>();
    }

    public void SetSanity(int currentHealth, int maxHealth){
        int set;
        float percent = (float) currentHealth / maxHealth;
        for (set = 9; set > percent * 10 && set > 0; set--){
            cells[set].SetCell(false);
        }
        for (int j = set; j > 0; j--){
            cells[set].SetCell(true);
        }
    }
}
