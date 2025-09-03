using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Core;
using HelixToolkit.Wpf.SharpDX.Model.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomShaderDemo
{
    public class CustomMeshNode : MeshNode
    {
        public float HeightScale
        {
            set
            {
                (RenderCore as CustomMeshCore).DataHeightScale = value;
            }
            get
            {
                return (RenderCore as CustomMeshCore).DataHeightScale;
            }
        }

        public float WoiMin
        {
            set
            {
                (RenderCore as CustomMeshCore).DataWoiMin = value;
            }
            get
            {
                return (RenderCore as CustomMeshCore).DataWoiMin;
            }
        }

        public float WoiMax
        {
            set
            {
                (RenderCore as CustomMeshCore).DataWoiMax = value;
            }
            get
            {
                return (RenderCore as CustomMeshCore).DataWoiMax;
            }
        }

        public float Stride
        {
            set
            {
                (RenderCore as CustomMeshCore).DataStride = value;
            }
            get
            {
                return (RenderCore as CustomMeshCore).DataStride;
            }
        }

        protected override RenderCore OnCreateRenderCore()
        {
            return new CustomMeshCore();
        }

        protected override IRenderTechnique OnCreateRenderTechnique(IEffectsManager effectsManager)
        {
            return effectsManager[CustomShaderNames.DataSampling];
        }
    }
}
