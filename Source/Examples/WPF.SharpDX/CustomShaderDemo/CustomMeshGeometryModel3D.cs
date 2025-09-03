using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Core;
using HelixToolkit.Wpf.SharpDX.Model.Scene;
using System.Windows;

namespace CustomShaderDemo
{
    public class CustomMeshGeometryModel3D : MeshGeometryModel3D
    {
        public static readonly DependencyProperty HeightScaleProperty = DependencyProperty.Register("HeightScale", typeof(double),
            typeof(CustomMeshGeometryModel3D),
            new PropertyMetadata(5.0, (d, e) =>
            {
                ((d as Element3D).SceneNode as CustomMeshNode).HeightScale = (float)(double)e.NewValue;
            }));

        public double HeightScale
        {
            set
            {
                SetValue(HeightScaleProperty, value);
            }
            get
            {
                return (double)GetValue(HeightScaleProperty);
            }
        }

        public static readonly DependencyProperty WoiMinProperty = DependencyProperty.Register(
            nameof(WoiMin), typeof(double), typeof(CustomMeshGeometryModel3D), 
            new PropertyMetadata(0.0, (d, e) =>
            {
                ((d as Element3D).SceneNode as CustomMeshNode).WoiMin = (float)(double)e.NewValue;
            }));

        public double WoiMin
        {
            get { return (double)GetValue(WoiMinProperty); }
            set { SetValue(WoiMinProperty, value); }
        }

        public static readonly DependencyProperty WoiMaxProperty = DependencyProperty.Register(
            nameof(WoiMax), typeof(double), typeof(CustomMeshGeometryModel3D),
            new PropertyMetadata(100.0, (d, e) =>
            {
                ((d as Element3D).SceneNode as CustomMeshNode).WoiMax = (float)(double)e.NewValue;
            }));

        public double WoiMax
        {
            get { return (double)GetValue(WoiMaxProperty); }
            set { SetValue(WoiMaxProperty, value); }
        }

        public static readonly DependencyProperty StrideProperty = DependencyProperty.Register(
            nameof(Stride), typeof(double), typeof(CustomMeshGeometryModel3D),
            new PropertyMetadata(1.0, (d, e) =>
            {
                ((d as Element3D).SceneNode as CustomMeshNode).Stride = (float)(double)e.NewValue;
            }));

        public double Stride
        {
            get { return (double)GetValue(StrideProperty); }
            set { SetValue(StrideProperty, value); }
        }

        protected override SceneNode OnCreateSceneNode()
        {
            return new CustomMeshNode();
        }

        protected override void AssignDefaultValuesToSceneNode(SceneNode core)
        {
            base.AssignDefaultValuesToSceneNode(core);
            (core as CustomMeshNode).HeightScale = (float)HeightScale;
        }
    }
}
