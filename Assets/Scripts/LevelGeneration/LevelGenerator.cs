using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [Header("Player")]
    public GameObject playerPrefab;

    public CameraFollow follow;

    [Header("Room generation")]
    public GameObject start;
    public GameObject end;

    public GameObject[] roomPrefabs;

    public int minRoomCount = 4;
    public int maxRoomCount = 8;

    private List<Room> rooms;

    // =====================================
    void Start()
    {
        this.rooms = new List<Room>();

        int roomCount = Random.Range(this.minRoomCount, this.maxRoomCount);

        Transform next = this.CreateRoom(this.start, this.transform);
        for (int i = 0; i < roomCount; i++)
        {
            int index = Random.Range(0, this.roomPrefabs.Length);

            next = this.CreateRoom(
                this.roomPrefabs[index],
                next
            );
        }

        this.CreateRoom(this.end, next);

        StartRoom start = (StartRoom) this.rooms[0];
        this.MocoStart(start.playerSpawn);
    }

    // =====================================
    private void MocoStart(Transform start)
    {
        var go = Instantiate(this.playerPrefab, start.position, Quaternion.identity);

        this.follow.target = go.transform;
    }

    // =====================================
    private Transform CreateRoom(GameObject prefab, Transform target)
    {
        var go = Instantiate(prefab, target.position, Quaternion.identity);
        var room = go.GetComponent<Room>();

        this.rooms.Add(room);

        return room.nextRoomAnchor;
    }
}
