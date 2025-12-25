using UnityEngine;

public class IsometricVector
{
    /// <summary>
    /// Funcion que convierte coordenadas de mundo a coordenadas isometricas
    /// </summary>
    /// <param name="vectorToTransform">Vector a transformar en coordenadas isometricas</param>
    public static Vector3 TransformToIsometricCoords(Vector3 vectorToTransform)
    {
        Quaternion rotation = Quaternion.Euler(0, 45f, 0);
        Matrix4x4 matrix = Matrix4x4.Rotate(rotation);
        Vector3 vectorConverted = matrix.MultiplyPoint3x4(vectorToTransform);
        return vectorConverted;
    }
}
