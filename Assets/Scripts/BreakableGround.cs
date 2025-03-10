using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableGround : MonoBehaviour {
    private Collider groundCollider;
    private Collider spriteCollider;
    public GameObject sprite;
    public GameObject player;
    public PlayerMovement playerScript;
    public ParticleSystem blockDestroyParticle;

    [SerializeField] private AudioSource breakSound;

    void Start() {
        player = GameObject.FindWithTag("Player");
        // sprite = player.transform.GetChild(0).gameObject;
        groundCollider = GetComponent<Collider>();
        spriteCollider = sprite.GetComponent<Collider>();
        // playerScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter(Collision col) {
        if ((col.gameObject.tag == "Player") && (playerScript.isSlamming)) {
            Instantiate(blockDestroyParticle.gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
            breakSound.Play();
        }
    }
}
