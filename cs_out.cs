using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NanoSVG
{
    public enum NSVGpaintType
    {
        NSVG_PAINT_UNDEF = -1,
        NSVG_PAINT_NONE = 0,
        NSVG_PAINT_COLOR = 1,
        NSVG_PAINT_LINEAR_GRADIENT = 2,
        NSVG_PAINT_RADIAL_GRADIENT = 3,
    }

    public enum NSVGspreadType
    {
        NSVG_SPREAD_PAD = 0,
        NSVG_SPREAD_REFLECT = 1,
        NSVG_SPREAD_REPEAT = 2,
    }

    public enum NSVGlineJoin
    {
        NSVG_JOIN_MITER = 0,
        NSVG_JOIN_ROUND = 1,
        NSVG_JOIN_BEVEL = 2,
    }

    public enum NSVGlineCap
    {
        NSVG_CAP_BUTT = 0,
        NSVG_CAP_ROUND = 1,
        NSVG_CAP_SQUARE = 2,
    }

    public enum NSVGfillRule
    {
        NSVG_FILLRULE_NONZERO = 0,
        NSVG_FILLRULE_EVENODD = 1,
    }

    public enum NSVGflags
    {
        NSVG_FLAGS_VISIBLE = 0x01,
    }

    public enum NSVGpaintOrder
    {
        NSVG_PAINT_FILL = 0x00,
        NSVG_PAINT_MARKERS = 0x01,
        NSVG_PAINT_STROKE = 0x02,
    }

    public partial struct NSVGgradientStop
    {
        [NativeTypeName("unsigned int")]
        public uint color;

        public float offset;
    }

    public partial struct NSVGgradient
    {
        [NativeTypeName("float[6]")]
        public _xform_e__FixedBuffer xform;

        [NativeTypeName("char")]
        public sbyte spread;

        public float fx;

        public float fy;

        public int nstops;

        [NativeTypeName("NSVGgradientStop[1]")]
        public _stops_e__FixedBuffer stops;

        [InlineArray(6)]
        public partial struct _xform_e__FixedBuffer
        {
            public float e0;
        }

        public partial struct _stops_e__FixedBuffer
        {
            public NSVGgradientStop e0;

            [UnscopedRef]
            public ref NSVGgradientStop this[int index]
            {
                get
                {
                    return ref Unsafe.Add(ref e0, index);
                }
            }

            [UnscopedRef]
            public Span<NSVGgradientStop> AsSpan(int length) => MemoryMarshal.CreateSpan(ref e0, length);
        }
    }

    public unsafe partial struct NSVGpaint
    {
        [NativeTypeName("signed char")]
        public sbyte type;

        [NativeTypeName("__AnonymousRecord_nanosvg_L130_C2")]
        public _Anonymous_e__Union Anonymous;

        [UnscopedRef]
        public ref uint color
        {
            get
            {
                return ref Anonymous.color;
            }
        }

        [UnscopedRef]
        public ref NSVGgradient* gradient
        {
            get
            {
                return ref Anonymous.gradient;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("unsigned int")]
            public uint color;

            [FieldOffset(0)]
            public NSVGgradient* gradient;
        }
    }

    public unsafe partial struct NSVGpath
    {
        public float* pts;

        public int npts;

        [NativeTypeName("char")]
        public sbyte closed;

        [NativeTypeName("float[4]")]
        public _bounds_e__FixedBuffer bounds;

        [NativeTypeName("struct NSVGpath *")]
        public NSVGpath* next;

        [InlineArray(4)]
        public partial struct _bounds_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct NSVGshape
    {
        [NativeTypeName("char[64]")]
        public _id_e__FixedBuffer id;

        public NSVGpaint fill;

        public NSVGpaint stroke;

        public float opacity;

        public float strokeWidth;

        public float strokeDashOffset;

        [NativeTypeName("float[8]")]
        public _strokeDashArray_e__FixedBuffer strokeDashArray;

        [NativeTypeName("char")]
        public sbyte strokeDashCount;

        [NativeTypeName("char")]
        public sbyte strokeLineJoin;

        [NativeTypeName("char")]
        public sbyte strokeLineCap;

        public float miterLimit;

        [NativeTypeName("char")]
        public sbyte fillRule;

        [NativeTypeName("unsigned char")]
        public byte paintOrder;

        [NativeTypeName("unsigned char")]
        public byte flags;

        [NativeTypeName("float[4]")]
        public _bounds_e__FixedBuffer bounds;

        [NativeTypeName("char[64]")]
        public _fillGradient_e__FixedBuffer fillGradient;

        [NativeTypeName("char[64]")]
        public _strokeGradient_e__FixedBuffer strokeGradient;

        [NativeTypeName("float[6]")]
        public _xform_e__FixedBuffer xform;

        public NSVGpath* paths;

        [NativeTypeName("struct NSVGshape *")]
        public NSVGshape* next;

        [InlineArray(64)]
        public partial struct _id_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(8)]
        public partial struct _strokeDashArray_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(4)]
        public partial struct _bounds_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(64)]
        public partial struct _fillGradient_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(64)]
        public partial struct _strokeGradient_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(6)]
        public partial struct _xform_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct NSVGimage
    {
        public float width;

        public float height;

        public NSVGshape* shapes;
    }

    public partial struct NSVGrasterizer
    {
    }

    public static unsafe partial class Methods
    {
        [DllImport("nanosvg", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NSVGimage* nsvgParseFromFile([NativeTypeName("const char *")] sbyte* filename, [NativeTypeName("const char *")] sbyte* units, float dpi);

        [DllImport("nanosvg", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NSVGimage* nsvgParse([NativeTypeName("char *")] sbyte* input, [NativeTypeName("const char *")] sbyte* units, float dpi);

        [DllImport("nanosvg", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NSVGpath* nsvgDuplicatePath(NSVGpath* p);

        [DllImport("nanosvg", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void nsvgDelete(NSVGimage* image);

        [DllImport("nanosvg", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NSVGrasterizer* nsvgCreateRasterizer();

        [DllImport("nanosvg", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void nsvgRasterize(NSVGrasterizer* r, NSVGimage* image, float tx, float ty, float scale, [NativeTypeName("unsigned char *")] byte* dst, int w, int h, int stride);

        [DllImport("nanosvg", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void nsvgDeleteRasterizer(NSVGrasterizer* param0);
    }
}
