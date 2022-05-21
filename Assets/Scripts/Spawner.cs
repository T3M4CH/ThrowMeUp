using Scene;
using UnityEngine;
using BlockNamespace;
using BallController;
public class Spawner : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private SceneView _sceneView;
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private Block _chainTemplate;
    [SerializeField] private Block _finishTemplate;
    private int _towerSize = 5;
    private Block _parentBlock;
    private void Awake()
    {
        _sceneView.OnSetLevel += BuildTower;
        _parentBlock = new GameObject().AddComponent<Block>();
    }
    private void BuildTower(int level)
    {
        _towerSize *= level;
        Block currentSegment = _parentBlock;
        for (int i = 0; i < _towerSize; i++)
        {
            currentSegment = BuildSegment(_blockTemplate, currentSegment.transform);
            currentSegment = BuildSegment(_chainTemplate, currentSegment.transform);
        }
        BuildSegment(_finishTemplate, currentSegment.transform);
    }
    private Block BuildSegment(Block blockPrefab, Transform position)
    {
        Block block = Instantiate(blockPrefab, GetBuildPoint(position, blockPrefab.transform), Quaternion.identity, _parentBlock.transform);
        block.Initialize(_ball);
        return block;
    }
    private Vector3 GetBuildPoint(Transform currentSegment, Transform nextSegment)
    {
        return new Vector3(currentSegment.position.x, currentSegment.position.y + currentSegment.localScale.y / 2 + nextSegment.localScale.y / 2, currentSegment.position.z);
    }
}