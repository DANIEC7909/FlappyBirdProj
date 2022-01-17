using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
public class PipeManager : MonoBehaviour
{
   static Vector3 calculatedTilePos;
  [SerializeField]  Transform firstTile;
  [SerializeField]static  Transform _firstTile;

    static PipeManagerModel _model;
    [SerializeField]
    PipeManagerModel model;

    [SerializeField]
   static List<SimplePipe> _pipes= new List<SimplePipe>();

    private void Awake()
    {
        _model = model;
    }
    private void Start()
    {
        calculatedTilePos= firstTile.position;
        _firstTile = firstTile;_pipes.Clear();
    }
    public static void DestroyPipeAndSpawnNewOne(SimplePipe sp)
    {
        if (!_pipes.Contains(sp))
        {
            _pipes.Add(sp);
        }
        if (_pipes.Count>=_model.maxPipesInScene-2) {
            Destroy(_pipes[0].gameObject);
            _pipes.Remove(_pipes[0]);
        }
        calculatedTilePos = new Vector3(calculatedTilePos.x + _model.DistanceBetweenObjectsX,_firstTile.position.y + Random.Range(-_model.HeightObjectsY, _model.HeightObjectsY));
     SimplePipe isp = Instantiate(_model.Prefabs[0],calculatedTilePos,Quaternion.identity).GetComponent<SimplePipe>();
        _pipes.Add(isp);
    }
    public static void DestroyPipeAndSpawnNewOneByBomb(SimplePipe sp)
    {
            Destroy(sp.gameObject);
            _pipes.Remove(sp);
        calculatedTilePos = new Vector3(calculatedTilePos.x + _model.DistanceBetweenObjectsX, _firstTile.position.y + Random.Range(-_model.HeightObjectsY, _model.HeightObjectsY));
        SimplePipe isp = Instantiate(_model.Prefabs[0], calculatedTilePos, Quaternion.identity).GetComponent<SimplePipe>();
        _pipes.Add(isp);
    }
}
