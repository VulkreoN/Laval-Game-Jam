using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] GameObject armature = null;
    [SerializeField] GameObject lookSegment = null;

    public GameObject player;
    Pathfinding.AIPath aiPath;
    Pathfinding.AIDestinationSetter des;
    BioIK.BioIK bones = null;
    

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<Pathfinding.AIPath>();
        des = GetComponent<Pathfinding.AIDestinationSetter>();
        bones = armature.GetComponent<BioIK.BioIK>();
        BioIK.BioSegment segment = bones.FindSegment(lookSegment.transform);
        BioIK.Position la = (BioIK.Position)segment.AddObjective(BioIK.ObjectiveType.Position);
        la.SetTargetTransform(player.transform);

        des.target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        des.target = player.transform;
    }
}
