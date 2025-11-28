using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEntry
{
    public GameObject Prefab;
    public int Amount = 1;

    [Header("Spawn Restrictions")]
    public float MinDistanceFromPlayer = 0f;
}

public class Generation : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private List<SpawnEntry> _SpawnList = new List<SpawnEntry>();
    [SerializeField] private GameObject _SpawnSurface;
    [SerializeField] private int _TotalLoops = 1;

    [Header("Player Reference")]
    [SerializeField] private Transform _Player;

    [Header("Spacing (global)")]
    [Tooltip("Extra spacing added between spawned objects (in world units).")]
    [SerializeField, Range(0f, 10f)] private float _MinSpacingBetweenObjects = 0.5f;

    private List<(Vector3 pos, float radius)> placed = new List<(Vector3, float)>();

    [SerializeField] private AnimalSelection selected;

    private void Start()
    {
        Generate(selected);
    }

    public void Generate(AnimalSelection animal)
    {
        _SpawnList = animal.Environment.prefabHolder;

        if (!IsValid())
            return;

        var col = _SpawnSurface.GetComponent<Collider>();

        for (int loop = 0; loop < _TotalLoops; loop++)
        {
            SpawnAll(col);
        }
    }

    private bool IsValid()
    {
        if (_SpawnList == null || _SpawnList.Count == 0)
        {
            Debug.LogWarning($"{nameof(Generation)}: Spawn list is empty.");
            return false;
        }

        if (!_SpawnSurface)
        {
            Debug.LogWarning($"{nameof(Generation)}: No spawn surface assigned.");
            return false;
        }

        if (!_SpawnSurface.GetComponent<Collider>())
        {
            Debug.LogWarning($"{nameof(Generation)}: Spawn surface has no collider.");
            return false;
        }

        return true;
    }

    private void SpawnAll(Collider col)
    {
        foreach (var entry in _SpawnList)
        {
            if (!entry.Prefab)
                continue;

            float radius = GetPrefabRadius(entry.Prefab);

            for (int i = 0; i < entry.Amount; i++)
            {
                Vector3 pos = FindValidPosition(radius, col, entry.MinDistanceFromPlayer);
                placed.Add((pos, radius));
                Instantiate(entry.Prefab, pos, Quaternion.identity);
            }
        }
    }

    private float GetPrefabRadius(GameObject prefab)
    {
        var cap = prefab.GetComponentInChildren<CapsuleCollider>();
        if (cap != null)
            return cap.radius;

        var sph = prefab.GetComponentInChildren<SphereCollider>();
        if (sph != null)
            return sph.radius;

        var box = prefab.GetComponentInChildren<BoxCollider>();
        if (box != null)
            return Mathf.Max(box.size.x, box.size.z) * 0.5f;

        return 1f;
    }

    private Vector3 FindValidPosition(float radius, Collider col, float minPlayerDist)
    {
        const int attempts = 80;

        for (int i = 0; i < attempts; i++)
        {
            Vector3 candidate = RandomPointInSurface(col);

            if (_Player && minPlayerDist > 0f)
            {
                Vector2 p = new Vector2(_Player.position.x, _Player.position.z);
                Vector2 c = new Vector2(candidate.x, candidate.z);

                if (Vector2.Distance(c, p) < minPlayerDist)
                    continue;
            }

            bool overlapsPlaced = false;
            foreach (var placedObj in placed)
            {
                float minDist = radius + placedObj.radius + _MinSpacingBetweenObjects;

                Vector2 a2d = new Vector2(candidate.x, candidate.z);
                Vector2 b2d = new Vector2(placedObj.pos.x, placedObj.pos.z);

                if (Vector2.Distance(a2d, b2d) < minDist)
                {
                    overlapsPlaced = true;
                    break;
                }
            }

            if (!overlapsPlaced)
                return candidate;
        }

        return RandomPointInSurface(col);
    }

    private Vector3 RandomPointInSurface(Collider col)
    {
        Bounds b = col.bounds;

        for (int i = 0; i < 30; i++)
        {
            float x = Random.Range(b.min.x, b.max.x);
            float z = Random.Range(b.min.z, b.max.z);

            Vector3 origin = new Vector3(x, b.max.y + 5f, z);

            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, 50f))
            {
                if (hit.collider == col)
                {
                    Vector3 closest = col.ClosestPoint(hit.point);

                    if (closest == hit.point)
                        return hit.point;
                }
            }
        }

        return col.bounds.center;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (var p in placed)
        {
            Gizmos.DrawWireSphere(p.pos, p.radius + _MinSpacingBetweenObjects);
        }
    }
#endif
}
