using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthBar : MonoBehaviour
{
    Vector3 localScale;
    private Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = transform.parent.gameObject.GetComponent<Enemy>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = character.percentHealth() * 3f;
        transform.localScale = localScale;
    }
}
