using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Core;
using HelixToolkit.Wpf.SharpDX.Render;
using HelixToolkit.Wpf.SharpDX.Shaders;
using HelixToolkit.Wpf.SharpDX.Utilities;
using SharpDX;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomShaderDemo
{
    public class CustomMeshCore : MeshRenderCore
    {
        private float dataHeightScale = 5;
        public float DataHeightScale
        {
            set
            {
                SetAffectsRender(ref dataHeightScale, value);
            }
            get { return dataHeightScale; }
        }

        private float dataWoiMin = 0;
        public float DataWoiMin
        {
            set
            {
                SetAffectsRender(ref dataWoiMin, value);
            }
            get { return dataWoiMin; }
        }

        private float dataWoiMax = 100;
        public float DataWoiMax
        {
            set
            {
                SetAffectsRender(ref dataWoiMax, value);
            }
            get { return dataWoiMax; }
        }

        private float dataStride = 1;
        public float DataStride
        {
            set
            {
                SetAffectsRender(ref dataStride, value);
            }
            get { return dataStride; }
        }

        protected override void OnUpdatePerModelStruct(RenderContext context)
        {
            base.OnUpdatePerModelStruct(context);
            modelStruct.Params.X = dataWoiMin;
            modelStruct.Params.Y = dataHeightScale;
            modelStruct.Params.Z = dataWoiMax;
            modelStruct.Params.W = dataStride;
        }
    }
}
