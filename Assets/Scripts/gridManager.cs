using UnityEngine;

public class GridCreator : MonoBehaviour
{
    [SerializeField] private GameObject gridCubePrefab;  // Prefab del cubo para la cuadrícula
    [SerializeField] private Vector3 gridSize = new Vector3(3, 3, 1);  // Tamaño de la matriz
    [SerializeField] private Vector3 posicionBase = new Vector3(3, 3, 1);

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 position = new Vector3(posicionBase.x+x*2, posicionBase.y-y*4, posicionBase.z); // Posición del cubo
                Instantiate(gridCubePrefab, position, Quaternion.identity); // Crear el cubo
            }
        }
    }
}
