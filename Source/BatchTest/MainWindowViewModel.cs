using HelixToolkit.Wpf.SharpDX;
using SharpDX;
using System.Collections.ObjectModel;

namespace BatchedMeshDemo
{
    public class MainViewModel
    {
        public Camera Camera { get; }
        public IEffectsManager EffectsManager { get; } = new DefaultEffectsManager();

        public ObservableCollection<Geometry3D> BatchedMeshes { get; }
        public ObservableCollection<Material> BatchedMaterials { get; }

        public MainViewModel()
        {
            // 相机
            Camera = new PerspectiveCamera
            {
                Position = new Vector3(0, 0, 50),
                LookDirection = new Vector3(0, 0, -50),
                UpDirection = Vector3.UnitY
            };

            BatchedMeshes = new ObservableCollection<Geometry3D>();
            BatchedMaterials = new ObservableCollection<Material>();

            // 外管子（绿色）
            var outerTube = new MeshBuilder();
            outerTube.AddTube(
                new[] { new Vector3(0, 0, -10), new Vector3(0, 0, 10) },
                5, // 半径
                thetaDiv: 36,
                isTubeClosed: false);
            BatchedMeshes.Add(outerTube.ToMeshGeometry3D());
            BatchedMaterials.Add(PhongMaterials.Green);

            // 内管子（红色）
            var innerTube = new MeshBuilder();
            innerTube.AddTube(
                new[] { new Vector3(0, 0, -10), new Vector3(0, 0, 10) },
                3,
                thetaDiv: 36,
                isTubeClosed: false);
            BatchedMeshes.Add(innerTube.ToMeshGeometry3D());
            BatchedMaterials.Add(PhongMaterials.Red);
        }
    }
}