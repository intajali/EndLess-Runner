
using UnityEngine;

public class TrackController : MonoBehaviour
{
    [SerializeField] private Transform[] paths;
    [SerializeField] private Transform player;


    private Transform endTransform;
    public float offset;
    private float gap = 2f;

    private int swapCount = 1;
    private bool isSwapped = false;
    private int index = 0;

    void Start()
    {
        endTransform = paths[paths.Length - 1];
        offset = (paths[0].localScale.x * paths.Length) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        CreateTrack();
    }

    private void CreateTrack()
    {
        if(player.position.x > offset)
        {
            paths[index].position = new Vector3(endTransform.position.x + endTransform.localScale.x + gap, endTransform.position.y, endTransform.position.z);
            endTransform = paths[index];
            index++;
            if (index > 2)
                index = 0;
            swapCount++;
            offset += endTransform.localScale.x+gap;
        }
    }
}
