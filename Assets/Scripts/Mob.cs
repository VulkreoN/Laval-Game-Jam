using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] GameObject armature = null;
    [SerializeField] GameObject lookSegment = null;
    [SerializeField] GameObject meshObject = null;
    [SerializeField] List<Material> materials;
    [SerializeField] float life = 5f;
    [SerializeField] bool testHit = false;

    public GameObject player;
    Pathfinding.AIPath aiPath;
    Pathfinding.AIDestinationSetter des;
    BioIK.BioIK bones = null;
    Animator animator;
    SkinnedMeshRenderer smr;
    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        smr = meshObject.GetComponent<SkinnedMeshRenderer>();
        animator = GetComponent<Animator>();
        aiPath = GetComponent<Pathfinding.AIPath>();
        des = GetComponent<Pathfinding.AIDestinationSetter>();
        bones = armature.GetComponent<BioIK.BioIK>();

        if (armature)
        {
            if (bones)
            {
                BioIK.BioSegment segment = bones.FindSegment(lookSegment.transform);
                BioIK.Position la = (BioIK.Position)segment.AddObjective(BioIK.ObjectiveType.Position);
                la.SetTargetTransform(player.transform);                
            }
        }

        if (smr)
        {
            Material[] mats = smr.materials;
            mats[0] = materials[Random.Range(0, materials.Count)];
            Debug.Log(mats[0].name);
            smr.materials = mats;
        }

        if (des)
            des.target = player.transform;
    }

    IEnumerator HitAnimation()
    {
        smr.material.color = new Color(1,0,0);
        yield return new WaitForSeconds(0.2f);
        smr.material.color = new Color(1, 1, 1);
    }

    IEnumerator Die()
    {
        animator.SetTrigger("dead");
        yield return new WaitForSeconds(1.8f);
        Destroy(gameObject);
    }

        public void HitMob(float damage)
    {
        if (smr)
        {
            StartCoroutine(HitAnimation());
        }
        life -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (des)
            des.target = player.transform;

        if (animator)
            animator.SetFloat("Speed", aiPath.velocity.magnitude);

        if (testHit)
        {
            testHit = false;
            HitMob(1);
        }

        if (life <= 0 && dead == false)
        {
            dead = true;
            StartCoroutine(Die());
        }

    }
}
