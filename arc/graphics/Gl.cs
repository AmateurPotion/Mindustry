// Decompiled with JetBrains decompiler
// Type: arc.graphics.Gl
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using java.util;
using System.Runtime.CompilerServices;

namespace arc.graphics
{
  public class Gl : Object
  {
    private const bool optimize = true;
    public const int esVersion20 = 1;
    public const int depthBufferBit = 256;
    public const int stencilBufferBit = 1024;
    public const int colorBufferBit = 16384;
    public const int falseV = 0;
    public const int trueV = 1;
    public const int points = 0;
    public const int lines = 1;
    public const int lineLoop = 2;
    public const int lineStrip = 3;
    public const int triangles = 4;
    public const int triangleStrip = 5;
    public const int triangleFan = 6;
    public const int zero = 0;
    public const int one = 1;
    public const int srcColor = 768;
    public const int oneMinusSrcColor = 769;
    public const int srcAlpha = 770;
    public const int oneMinusSrcAlpha = 771;
    public const int dstAlpha = 772;
    public const int oneMinusDstAlpha = 773;
    public const int dstColor = 774;
    public const int oneMinusDstColor = 775;
    public const int srcAlphaSaturate = 776;
    public const int funcAdd = 32774;
    public const int blendEquation = 32777;
    public const int blendEquationRgb = 32777;
    public const int blendEquationAlpha = 34877;
    public const int funcSubtract = 32778;
    public const int funcReverseSubtract = 32779;
    public const int min = 32775;
    public const int max = 32776;
    public const int blendDstRgb = 32968;
    public const int blendSrcRgb = 32969;
    public const int blendDstAlpha = 32970;
    public const int blendSrcAlpha = 32971;
    public const int constantColor = 32769;
    public const int oneMinusConstantColor = 32770;
    public const int constantAlpha = 32771;
    public const int oneMinusConstantAlpha = 32772;
    public const int blendColor = 32773;
    public const int arrayBuffer = 34962;
    public const int elementArrayBuffer = 34963;
    public const int arrayBufferBinding = 34964;
    public const int elementArrayBufferBinding = 34965;
    public const int streamDraw = 35040;
    public const int staticDraw = 35044;
    public const int dynamicDraw = 35048;
    public const int bufferSize = 34660;
    public const int bufferUsage = 34661;
    public const int currentVertexAttrib = 34342;
    public const int front = 1028;
    public const int back = 1029;
    public const int frontAndBack = 1032;
    public const int texture2d = 3553;
    public const int cullFace = 2884;
    public const int blend = 3042;
    public const int dither = 3024;
    public const int stencilTest = 2960;
    public const int depthTest = 2929;
    public const int scissorTest = 3089;
    public const int polygonOffsetFill = 32823;
    public const int sampleAlphaToCoverage = 32926;
    public const int sampleCoverage = 32928;
    public const int noError = 0;
    public const int invalidEnum = 1280;
    public const int invalidValue = 1281;
    public const int invalidOperation = 1282;
    public const int outOfMemory = 1285;
    public const int cw = 2304;
    public const int ccw = 2305;
    public const int lineWidth = 2849;
    public const int aliasedPointSizeRange = 33901;
    public const int aliasedLineWidthRange = 33902;
    public const int cullFaceMode = 2885;
    public const int frontFace = 2886;
    public const int depthRange = 2928;
    public const int depthWritemask = 2930;
    public const int depthClearValue = 2931;
    public const int depthFunc = 2932;
    public const int stencilClearValue = 2961;
    public const int stencilFunc = 2962;
    public const int stencilFail = 2964;
    public const int stencilPassDepthFail = 2965;
    public const int stencilPassDepthPass = 2966;
    public const int stencilRef = 2967;
    public const int stencilValueMask = 2963;
    public const int stencilWritemask = 2968;
    public const int stencilBackFunc = 34816;
    public const int stencilBackFail = 34817;
    public const int stencilBackPassDepthFail = 34818;
    public const int stencilBackPassDepthPass = 34819;
    public const int stencilBackRef = 36003;
    public const int stencilBackValueMask = 36004;
    public const int stencilBackWritemask = 36005;
    public const int viewport = 2978;
    public const int scissorBox = 3088;
    public const int colorClearValue = 3106;
    public const int colorWritemask = 3107;
    public const int unpackAlignment = 3317;
    public const int packAlignment = 3333;
    public const int maxTextureSize = 3379;
    public const int maxTextureUnits = 34018;
    public const int maxViewportDims = 3386;
    public const int subpixelBits = 3408;
    public const int redBits = 3410;
    public const int greenBits = 3411;
    public const int blueBits = 3412;
    public const int alphaBits = 3413;
    public const int depthBits = 3414;
    public const int stencilBits = 3415;
    public const int polygonOffsetUnits = 10752;
    public const int polygonOffsetFactor = 32824;
    public const int textureBinding2d = 32873;
    public const int sampleBuffers = 32936;
    public const int samples = 32937;
    public const int sampleCoverageValue = 32938;
    public const int sampleCoverageInvert = 32939;
    public const int numCompressedTextureFormats = 34466;
    public const int compressedTextureFormats = 34467;
    public const int dontCare = 4352;
    public const int fastest = 4353;
    public const int nicest = 4354;
    public const int generateMipmap = 33169;
    public const int generateMipmapHint = 33170;
    public const int byteV = 5120;
    public const int unsignedByte = 5121;
    public const int shortV = 5122;
    public const int unsignedShort = 5123;
    public const int intV = 5124;
    public const int unsignedInt = 5125;
    public const int floatV = 5126;
    public const int @fixed = 5132;
    public const int depthComponent = 6402;
    public const int alpha = 6406;
    public const int rgb = 6407;
    public const int rgba = 6408;
    public const int luminance = 6409;
    public const int luminanceAlpha = 6410;
    public const int unsignedShort4444 = 32819;
    public const int unsignedShort5551 = 32820;
    public const int unsignedShort565 = 33635;
    public const int fragmentShader = 35632;
    public const int vertexShader = 35633;
    public const int maxVertexAttribs = 34921;
    public const int maxVertexUniformVectors = 36347;
    public const int maxVaryingVectors = 36348;
    public const int maxCombinedTextureImageUnits = 35661;
    public const int maxVertexTextureImageUnits = 35660;
    public const int maxTextureImageUnits = 34930;
    public const int maxFragmentUniformVectors = 36349;
    public const int shaderType = 35663;
    public const int deleteStatus = 35712;
    public const int linkStatus = 35714;
    public const int validateStatus = 35715;
    public const int attachedShaders = 35717;
    public const int activeUniforms = 35718;
    public const int activeUniformMaxLength = 35719;
    public const int activeAttributes = 35721;
    public const int activeAttributeMaxLength = 35722;
    public const int shadingLanguageVersion = 35724;
    public const int currentProgram = 35725;
    public const int never = 512;
    public const int less = 513;
    public const int equal = 514;
    public const int lequal = 515;
    public const int greater = 516;
    public const int notequal = 517;
    public const int gequal = 518;
    public const int always = 519;
    public const int keep = 7680;
    public const int replace = 7681;
    public const int incr = 7682;
    public const int decr = 7683;
    public const int invert = 5386;
    public const int incrWrap = 34055;
    public const int decrWrap = 34056;
    public const int vendor = 7936;
    public const int renderer = 7937;
    public const int version = 7938;
    public const int extensions = 7939;
    public const int nearest = 9728;
    public const int linear = 9729;
    public const int nearestMipmapNearest = 9984;
    public const int linearMipmapNearest = 9985;
    public const int nearestMipmapLinear = 9986;
    public const int linearMipmapLinear = 9987;
    public const int textureMagFilter = 10240;
    public const int textureMinFilter = 10241;
    public const int textureWrapS = 10242;
    public const int textureWrapT = 10243;
    public const int texture = 5890;
    public const int textureCubeMap = 34067;
    public const int textureBindingCubeMap = 34068;
    public const int textureCubeMapPositiveX = 34069;
    public const int textureCubeMapNegativeX = 34070;
    public const int textureCubeMapPositiveY = 34071;
    public const int textureCubeMapNegativeY = 34072;
    public const int textureCubeMapPositiveZ = 34073;
    public const int textureCubeMapNegativeZ = 34074;
    public const int maxCubeMapTextureSize = 34076;
    public const int texture0 = 33984;
    public const int texture1 = 33985;
    public const int texture2 = 33986;
    public const int texture3 = 33987;
    public const int texture4 = 33988;
    public const int texture5 = 33989;
    public const int texture6 = 33990;
    public const int texture7 = 33991;
    public const int texture8 = 33992;
    public const int texture9 = 33993;
    public const int texture10 = 33994;
    public const int texture11 = 33995;
    public const int texture12 = 33996;
    public const int texture13 = 33997;
    public const int texture14 = 33998;
    public const int texture15 = 33999;
    public const int texture16 = 34000;
    public const int texture17 = 34001;
    public const int texture18 = 34002;
    public const int texture19 = 34003;
    public const int texture20 = 34004;
    public const int texture21 = 34005;
    public const int texture22 = 34006;
    public const int texture23 = 34007;
    public const int texture24 = 34008;
    public const int texture25 = 34009;
    public const int texture26 = 34010;
    public const int texture27 = 34011;
    public const int texture28 = 34012;
    public const int texture29 = 34013;
    public const int texture30 = 34014;
    public const int texture31 = 34015;
    public const int activeTexture = 34016;
    public const int repeat = 10497;
    public const int clampToEdge = 33071;
    public const int mirroredRepeat = 33648;
    public const int floatVec2 = 35664;
    public const int floatVec3 = 35665;
    public const int floatVec4 = 35666;
    public const int intVec2 = 35667;
    public const int intVec3 = 35668;
    public const int intVec4 = 35669;
    public const int @bool = 35670;
    public const int boolVec2 = 35671;
    public const int boolVec3 = 35672;
    public const int boolVec4 = 35673;
    public const int floatMat2 = 35674;
    public const int floatMat3 = 35675;
    public const int floatMat4 = 35676;
    public const int sampler2d = 35678;
    public const int samplerCube = 35680;
    public const int vertexAttribArrayEnabled = 34338;
    public const int vertexAttribArraySize = 34339;
    public const int vertexAttribArrayStride = 34340;
    public const int vertexAttribArrayType = 34341;
    public const int vertexAttribArrayNormalized = 34922;
    public const int vertexAttribArrayPointer = 34373;
    public const int vertexAttribArrayBufferBinding = 34975;
    public const int implementationColorReadType = 35738;
    public const int implementationColorReadFormat = 35739;
    public const int compileStatus = 35713;
    public const int infoLogLength = 35716;
    public const int shaderSourceLength = 35720;
    public const int shaderCompiler = 36346;
    public const int shaderBinaryFormats = 36344;
    public const int numShaderBinaryFormats = 36345;
    public const int lowFloat = 36336;
    public const int mediumFloat = 36337;
    public const int highFloat = 36338;
    public const int lowInt = 36339;
    public const int mediumInt = 36340;
    public const int highInt = 36341;
    public const int framebuffer = 36160;
    public const int renderbuffer = 36161;
    public const int rgba4 = 32854;
    public const int rgb5A1 = 32855;
    public const int rgb565 = 36194;
    public const int depthComponent16 = 33189;
    public const int stencilIndex = 6401;
    public const int stencilIndex8 = 36168;
    public const int renderbufferWidth = 36162;
    public const int renderbufferHeight = 36163;
    public const int renderbufferInternalFormat = 36164;
    public const int renderbufferRedSize = 36176;
    public const int renderbufferGreenSize = 36177;
    public const int renderbufferBlueSize = 36178;
    public const int renderbufferAlphaSize = 36179;
    public const int renderbufferDepthSize = 36180;
    public const int renderbufferStencilSize = 36181;
    public const int framebufferAttachmentObjectType = 36048;
    public const int framebufferAttachmentObjectName = 36049;
    public const int framebufferAttachmentTextureLevel = 36050;
    public const int framebufferAttachmentTextureCubeMapFace = 36051;
    public const int colorAttachment0 = 36064;
    public const int depthAttachment = 36096;
    public const int stencilAttachment = 36128;
    public const int none = 0;
    public const int framebufferComplete = 36053;
    public const int framebufferIncompleteAttachment = 36054;
    public const int framebufferIncompleteMissingAttachment = 36055;
    public const int framebufferIncompleteDimensions = 36057;
    public const int framebufferUnsupported = 36061;
    public const int framebufferBinding = 36006;
    public const int renderbufferBinding = 36007;
    public const int maxRenderbufferSize = 34024;
    public const int invalidFramebufferOperation = 1286;
    public const int vertexProgramPointSize = 34370;
    private static IntBuffer ibuf;
    private static IntBuffer ibuf2;
    private static int lastActiveTexture;
    private static int[] lastBoundTextures;
    private static int lastUsedProgram;
    private static Bits enabled;
    private static bool wasDepthMask;
    private static int lastSfactor;
    private static int lastDfactor;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {161, 126, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getInt(int name)
    {
      ((Buffer) Gl.ibuf).position(0);
      Gl.getIntegerv(name, Gl.ibuf);
      return Gl.ibuf.get(0);
    }

    [LineNumberTable(new byte[] {161, 94, 109, 129, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void enable(int cap)
    {
      if (Gl.enabled.get(cap))
        return;
      Core.gl.glEnable(cap);
      Gl.enabled.set(cap);
    }

    [LineNumberTable(new byte[] {161, 212, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blendEquationSeparate(int modeRGB, int modeAlpha) => Core.gl.glBlendEquationSeparate(modeRGB, modeAlpha);

    [LineNumberTable(new byte[] {161, 180, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void viewport(int x, int y, int width, int height) => Core.gl.glViewport(x, y, width, height);

    [LineNumberTable(new byte[] {161, 16, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clear(int mask) => Core.gl.glClear(mask);

    [LineNumberTable(610)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int createShader(int type) => Core.gl.glCreateShader(type);

    [LineNumberTable(new byte[] {162, 172, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shaderSource(int shader, string @string) => Core.gl.glShaderSource(shader, @string);

    [LineNumberTable(new byte[] {161, 232, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void compileShader(int shader) => Core.gl.glCompileShader(shader);

    [LineNumberTable(new byte[] {162, 88, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getShaderiv(int shader, int pname, IntBuffer @params) => Core.gl.glGetShaderiv(shader, pname, @params);

    [LineNumberTable(718)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getShaderInfoLog(int shader) => Core.gl.glGetShaderInfoLog(shader);

    [LineNumberTable(606)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int createProgram() => Core.gl.glCreateProgram();

    [LineNumberTable(new byte[] {161, 184, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void attachShader(int program, int shader) => Core.gl.glAttachShader(program, shader);

    [LineNumberTable(new byte[] {162, 156, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void linkProgram(int program) => Core.gl.glLinkProgram(program);

    [LineNumberTable(new byte[] {162, 76, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getProgramiv(int program, int pname, IntBuffer @params) => Core.gl.glGetProgramiv(program, pname, @params);

    [LineNumberTable(706)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getProgramInfoLog(int program) => Core.gl.glGetProgramInfoLog(program);

    [LineNumberTable(682)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getAttribLocation(int program, string name) => Core.gl.glGetAttribLocation(program, name);

    [LineNumberTable(742)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getUniformLocation(int program, string name) => Core.gl.glGetUniformLocation(program, name);

    [LineNumberTable(new byte[] {162, 212, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform1i(int location, int x) => Core.gl.glUniform1i(location, x);

    [LineNumberTable(new byte[] {162, 236, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform2i(int location, int x, int y) => Core.gl.glUniform2i(location, x, y);

    [LineNumberTable(new byte[] {163, 4, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform3i(int location, int x, int y, int z) => Core.gl.glUniform3i(location, x, y, z);

    [LineNumberTable(new byte[] {163, 28, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform4i(int location, int x, int y, int z, int w) => Core.gl.glUniform4i(location, x, y, z, w);

    [LineNumberTable(new byte[] {162, 200, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform1f(int location, float x) => Core.gl.glUniform1f(location, x);

    [LineNumberTable(new byte[] {162, 224, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform2f(int location, float x, float y) => Core.gl.glUniform2f(location, x, y);

    [LineNumberTable(new byte[] {162, 248, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform3f(int location, float x, float y, float z) => Core.gl.glUniform3f(location, x, y, z);

    [LineNumberTable(new byte[] {163, 16, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform4f(int location, float x, float y, float z, float w) => Core.gl.glUniform4f(location, x, y, z, w);

    [LineNumberTable(new byte[] {162, 208, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform1fv(int location, int count, float[] v, int offset) => Core.gl.glUniform1fv(location, count, v, offset);

    [LineNumberTable(new byte[] {162, 232, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform2fv(int location, int count, float[] v, int offset) => Core.gl.glUniform2fv(location, count, v, offset);

    [LineNumberTable(new byte[] {163, 0, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform3fv(int location, int count, float[] v, int offset) => Core.gl.glUniform3fv(location, count, v, offset);

    [LineNumberTable(new byte[] {163, 24, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform4fv(int location, int count, float[] v, int offset) => Core.gl.glUniform4fv(location, count, v, offset);

    [LineNumberTable(new byte[] {158, 165, 130, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniformMatrix3fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      Core.gl.glUniformMatrix3fv(location, count, num != 0, value, offset);
    }

    [LineNumberTable(new byte[] {158, 163, 130, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniformMatrix4fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      Core.gl.glUniformMatrix4fv(location, count, num != 0, value, offset);
    }

    [LineNumberTable(new byte[] {158, 166, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniformMatrix3fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      Core.gl.glUniformMatrix3fv(location, count, num != 0, value);
    }

    [LineNumberTable(new byte[] {158, 164, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniformMatrix4fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      Core.gl.glUniformMatrix4fv(location, count, num != 0, value);
    }

    [LineNumberTable(new byte[] {158, 151, 130, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttribPointer(
      int indx,
      int size,
      int type,
      bool normalized,
      int stride,
      Buffer ptr)
    {
      int num = normalized ? 1 : 0;
      Core.gl.glVertexAttribPointer(indx, size, type, num != 0, stride, ptr);
    }

    [LineNumberTable(new byte[] {158, 150, 130, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttribPointer(
      int indx,
      int size,
      int type,
      bool normalized,
      int stride,
      int ptr)
    {
      int num = normalized ? 1 : 0;
      Core.gl.glVertexAttribPointer(indx, size, type, num != 0, stride, ptr);
    }

    [LineNumberTable(new byte[] {163, 64, 104, 129, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void useProgram(int program)
    {
      if (Gl.lastUsedProgram == program)
        return;
      Core.gl.glUseProgram(program);
      Gl.lastUsedProgram = program;
    }

    [LineNumberTable(new byte[] {162, 4, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deleteShader(int shader) => Core.gl.glDeleteShader(shader);

    [LineNumberTable(new byte[] {161, 252, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deleteProgram(int program) => Core.gl.glDeleteProgram(program);

    [LineNumberTable(new byte[] {162, 12, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void disableVertexAttribArray(int index) => Core.gl.glDisableVertexAttribArray(index);

    [LineNumberTable(new byte[] {162, 20, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void enableVertexAttribArray(int index) => Core.gl.glEnableVertexAttribArray(index);

    [LineNumberTable(new byte[] {163, 100, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttrib4f(int indx, float x, float y, float z, float w) => Core.gl.glVertexAttrib4f(indx, x, y, z, w);

    [LineNumberTable(678)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getActiveUniform(int program, int index, IntBuffer size, IntBuffer type) => Core.gl.glGetActiveUniform(program, index, size, type);

    [LineNumberTable(674)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getActiveAttrib(int program, int index, IntBuffer size, IntBuffer type) => Core.gl.glGetActiveAttrib(program, index, size, type);

    [LineNumberTable(new byte[] {161, 20, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clearColor(float red, float green, float blue, float alpha) => Core.gl.glClearColor(red, green, blue, alpha);

    [LineNumberTable(new byte[] {161, 78, 109, 129, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void disable(int cap)
    {
      if (!Gl.enabled.get(cap))
        return;
      Core.gl.glDisable(cap);
      Gl.enabled.clear(cap);
    }

    [LineNumberTable(new byte[] {159, 32, 66, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void depthMask(bool flag)
    {
      int num = flag ? 1 : 0;
      Core.gl.glDepthMask(num != 0);
    }

    [LineNumberTable(new byte[] {161, 8, 113, 152, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blendFunc(int sfactor, int dfactor)
    {
      if (Gl.lastSfactor == sfactor && Gl.lastDfactor == dfactor)
        return;
      Core.gl.glBlendFunc(Gl.lastSfactor = sfactor, Gl.lastDfactor = dfactor);
      Gl.lastSfactor = sfactor;
      Gl.lastDfactor = dfactor;
    }

    [LineNumberTable(new byte[] {161, 52, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void cullFace(int mode) => Core.gl.glCullFace(mode);

    [LineNumberTable(484)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int genTexture() => Core.gl.glGenTexture();

    [LineNumberTable(new byte[] {161, 140, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void pixelStorei(int pname, int param) => Core.gl.glPixelStorei(pname, param);

    [LineNumberTable(new byte[] {161, 168, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void texImage2D(
      int target,
      int level,
      int internalformat,
      int width,
      int height,
      int border,
      int format,
      int type,
      Buffer pixels)
    {
      Core.gl.glTexImage2D(target, level, internalformat, width, height, border, format, type, pixels);
    }

    [LineNumberTable(new byte[] {160, 247, 136, 140, 109, 138, 129, 200, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void bindTexture(int target, int texture)
    {
      if (target == 3553)
      {
        int index = Gl.lastActiveTexture - 33984;
        if (index >= 0 && index < Gl.lastBoundTextures.Length)
        {
          if (Gl.lastBoundTextures[index] == texture)
            return;
          Gl.lastBoundTextures[index] = texture;
        }
      }
      Core.gl.glBindTexture(target, texture);
    }

    [LineNumberTable(new byte[] {160, 240, 137, 107, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void activeTexture(int texture)
    {
      if (Gl.lastActiveTexture == texture)
        return;
      Core.gl.glActiveTexture(texture);
      Gl.lastActiveTexture = texture;
    }

    [LineNumberTable(new byte[] {162, 192, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void texParameteri(int target, int pname, int param) => Core.gl.glTexParameteri(target, pname, param);

    [LineNumberTable(new byte[] {161, 57, 107, 106, 8, 230, 69, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deleteTexture(int texture)
    {
      for (int index = 0; index < Gl.lastBoundTextures.Length; ++index)
      {
        if (Gl.lastBoundTextures[index] == texture)
          Gl.lastBoundTextures[index] = -1;
      }
      Core.gl.glDeleteTexture(texture);
    }

    [LineNumberTable(new byte[] {161, 122, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getIntegerv(int pname, IntBuffer @params) => Core.gl.glGetIntegerv(pname, @params);

    [LineNumberTable(new byte[] {160, 230, 102, 107, 102, 106, 102, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void reset()
    {
      Gl.lastActiveTexture = -1;
      Arrays.fill(Gl.lastBoundTextures, -1);
      Gl.lastUsedProgram = 0;
      Gl.enabled.clear();
      Gl.wasDepthMask = true;
      Gl.lastSfactor = -1;
      Gl.lastDfactor = -1;
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Gl()
    {
    }

    [LineNumberTable(new byte[] {161, 24, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clearDepthf(float depth) => Core.gl.glClearDepthf(depth);

    [LineNumberTable(new byte[] {161, 28, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void clearStencil(int s) => Core.gl.glClearStencil(s);

    [LineNumberTable(new byte[] {159, 42, 136, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void colorMask(bool red, bool green, bool blue, bool alpha)
    {
      int num1 = red ? 1 : 0;
      int num2 = green ? 1 : 0;
      int num3 = blue ? 1 : 0;
      int num4 = alpha ? 1 : 0;
      Core.gl.glColorMask(num1 != 0, num2 != 0, num3 != 0, num4 != 0);
    }

    [LineNumberTable(new byte[] {161, 36, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void compressedTexImage2D(
      int target,
      int level,
      int internalformat,
      int width,
      int height,
      int border,
      int imageSize,
      Buffer data)
    {
      Core.gl.glCompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data);
    }

    [LineNumberTable(new byte[] {161, 40, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void compressedTexSubImage2D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int width,
      int height,
      int format,
      int imageSize,
      Buffer data)
    {
      Core.gl.glCompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data);
    }

    [LineNumberTable(new byte[] {161, 44, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copyTexImage2D(
      int target,
      int level,
      int internalformat,
      int x,
      int y,
      int width,
      int height,
      int border)
    {
      Core.gl.glCopyTexImage2D(target, level, internalformat, x, y, width, height, border);
    }

    [LineNumberTable(new byte[] {161, 48, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void copyTexSubImage2D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int x,
      int y,
      int width,
      int height)
    {
      Core.gl.glCopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height);
    }

    [LineNumberTable(new byte[] {161, 66, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void depthFunc(int func) => Core.gl.glDepthFunc(func);

    [LineNumberTable(new byte[] {161, 74, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void depthRangef(float zNear, float zFar) => Core.gl.glDepthRangef(zNear, zFar);

    [LineNumberTable(new byte[] {161, 86, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void drawArrays(int mode, int first, int count) => Core.gl.glDrawArrays(mode, first, count);

    [LineNumberTable(new byte[] {161, 90, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void drawElements(int mode, int count, int type, Buffer indices) => Core.gl.glDrawElements(mode, count, type, indices);

    [LineNumberTable(new byte[] {161, 102, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void finish() => Core.gl.glFinish();

    [LineNumberTable(new byte[] {161, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void flush() => Core.gl.glFlush();

    [LineNumberTable(new byte[] {161, 110, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void frontFace(int mode) => Core.gl.glFrontFace(mode);

    [LineNumberTable(488)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getError() => Core.gl.glGetError();

    [LineNumberTable(502)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getString(int name) => Core.gl.glGetString(name);

    [LineNumberTable(new byte[] {161, 136, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void hint(int target, int mode) => Core.gl.glHint(target, mode);

    [LineNumberTable(new byte[] {161, 144, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void polygonOffset(float factor, float units) => Core.gl.glPolygonOffset(factor, units);

    [LineNumberTable(new byte[] {161, 148, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void readPixels(
      int x,
      int y,
      int width,
      int height,
      int format,
      int type,
      Buffer pixels)
    {
      Core.gl.glReadPixels(x, y, width, height, format, type, pixels);
    }

    [LineNumberTable(new byte[] {161, 152, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void scissor(int x, int y, int width, int height) => Core.gl.glScissor(x, y, width, height);

    [LineNumberTable(new byte[] {161, 156, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stencilFunc(int func, int @ref, int mask) => Core.gl.glStencilFunc(func, @ref, mask);

    [LineNumberTable(new byte[] {161, 160, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stencilMask(int mask) => Core.gl.glStencilMask(mask);

    [LineNumberTable(new byte[] {161, 164, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stencilOp(int fail, int zfail, int zpass) => Core.gl.glStencilOp(fail, zfail, zpass);

    [LineNumberTable(new byte[] {161, 172, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void texParameterf(int target, int pname, float param) => Core.gl.glTexParameterf(target, pname, param);

    [LineNumberTable(new byte[] {161, 176, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void texSubImage2D(
      int target,
      int level,
      int xoffset,
      int yoffset,
      int width,
      int height,
      int format,
      int type,
      Buffer pixels)
    {
      Core.gl.glTexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    [LineNumberTable(new byte[] {161, 188, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void bindAttribLocation(int program, int index, string name) => Core.gl.glBindAttribLocation(program, index, name);

    [LineNumberTable(new byte[] {161, 192, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void bindBuffer(int target, int buffer) => Core.gl.glBindBuffer(target, buffer);

    [LineNumberTable(new byte[] {161, 196, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void bindFramebuffer(int target, int framebuffer) => Core.gl.glBindFramebuffer(target, framebuffer);

    [LineNumberTable(new byte[] {161, 200, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void bindRenderbuffer(int target, int renderbuffer) => Core.gl.glBindRenderbuffer(target, renderbuffer);

    [LineNumberTable(new byte[] {161, 204, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blendColor(float red, float green, float blue, float alpha) => Core.gl.glBlendColor(red, green, blue, alpha);

    [LineNumberTable(new byte[] {161, 208, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blendEquation(int mode) => Core.gl.glBlendEquation(mode);

    [LineNumberTable(new byte[] {161, 216, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void blendFuncSeparate(int srcRGB, int dstRGB, int srcAlpha, int dstAlpha) => Core.gl.glBlendFuncSeparate(srcRGB, dstRGB, srcAlpha, dstAlpha);

    [LineNumberTable(new byte[] {161, 220, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void bufferData(int target, int size, Buffer data, int usage) => Core.gl.glBufferData(target, size, data, usage);

    [LineNumberTable(new byte[] {161, 224, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void bufferSubData(int target, int offset, int size, Buffer data) => Core.gl.glBufferSubData(target, offset, size, data);

    [LineNumberTable(598)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int checkFramebufferStatus(int target) => Core.gl.glCheckFramebufferStatus(target);

    [LineNumberTable(new byte[] {161, 244, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deleteBuffer(int buffer) => Core.gl.glDeleteBuffer(buffer);

    [LineNumberTable(new byte[] {161, 248, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deleteFramebuffer(int framebuffer) => Core.gl.glDeleteFramebuffer(framebuffer);

    [LineNumberTable(new byte[] {162, 0, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void deleteRenderbuffer(int renderbuffer) => Core.gl.glDeleteRenderbuffer(renderbuffer);

    [LineNumberTable(new byte[] {162, 8, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void detachShader(int program, int shader) => Core.gl.glDetachShader(program, shader);

    [LineNumberTable(new byte[] {162, 16, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void drawElements(int mode, int count, int type, int indices) => Core.gl.glDrawElements(mode, count, type, indices);

    [LineNumberTable(new byte[] {162, 24, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void framebufferRenderbuffer(
      int target,
      int attachment,
      int renderbuffertarget,
      int renderbuffer)
    {
      Core.gl.glFramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer);
    }

    [LineNumberTable(new byte[] {162, 28, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void framebufferTexture2D(
      int target,
      int attachment,
      int textarget,
      int texture,
      int level)
    {
      Core.gl.glFramebufferTexture2D(target, attachment, textarget, texture, level);
    }

    [LineNumberTable(658)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int genBuffer() => Core.gl.glGenBuffer();

    [LineNumberTable(new byte[] {162, 36, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void generateMipmap(int target) => Core.gl.glGenerateMipmap(target);

    [LineNumberTable(666)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int genFramebuffer() => Core.gl.glGenFramebuffer();

    [LineNumberTable(670)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int genRenderbuffer() => Core.gl.glGenRenderbuffer();

    [LineNumberTable(new byte[] {162, 60, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getBooleanv(int pname, Buffer @params) => Core.gl.glGetBooleanv(pname, @params);

    [LineNumberTable(new byte[] {162, 64, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getBufferParameteriv(int target, int pname, IntBuffer @params) => Core.gl.glGetBufferParameteriv(target, pname, @params);

    [LineNumberTable(new byte[] {162, 68, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getFloatv(int pname, FloatBuffer @params) => Core.gl.glGetFloatv(pname, @params);

    [LineNumberTable(new byte[] {162, 72, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getFramebufferAttachmentParameteriv(
      int target,
      int attachment,
      int pname,
      IntBuffer @params)
    {
      Core.gl.glGetFramebufferAttachmentParameteriv(target, attachment, pname, @params);
    }

    [LineNumberTable(new byte[] {162, 84, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getRenderbufferParameteriv(int target, int pname, IntBuffer @params) => Core.gl.glGetRenderbufferParameteriv(target, pname, @params);

    [LineNumberTable(new byte[] {162, 96, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getShaderPrecisionFormat(
      int shadertype,
      int precisiontype,
      IntBuffer range,
      IntBuffer precision)
    {
      Core.gl.glGetShaderPrecisionFormat(shadertype, precisiontype, range, precision);
    }

    [LineNumberTable(new byte[] {162, 100, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getTexParameterfv(int target, int pname, FloatBuffer @params) => Core.gl.glGetTexParameterfv(target, pname, @params);

    [LineNumberTable(new byte[] {162, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getTexParameteriv(int target, int pname, IntBuffer @params) => Core.gl.glGetTexParameteriv(target, pname, @params);

    [LineNumberTable(new byte[] {162, 108, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getUniformfv(int program, int location, FloatBuffer @params) => Core.gl.glGetUniformfv(program, location, @params);

    [LineNumberTable(new byte[] {162, 112, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getUniformiv(int program, int location, IntBuffer @params) => Core.gl.glGetUniformiv(program, location, @params);

    [LineNumberTable(new byte[] {162, 120, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getVertexAttribfv(int index, int pname, FloatBuffer @params) => Core.gl.glGetVertexAttribfv(index, pname, @params);

    [LineNumberTable(new byte[] {162, 124, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void getVertexAttribiv(int index, int pname, IntBuffer @params) => Core.gl.glGetVertexAttribiv(index, pname, @params);

    [LineNumberTable(754)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isBuffer(int buffer) => Core.gl.glIsBuffer(buffer);

    [LineNumberTable(758)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isEnabled(int cap) => Core.gl.glIsEnabled(cap);

    [LineNumberTable(762)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isFramebuffer(int framebuffer) => Core.gl.glIsFramebuffer(framebuffer);

    [LineNumberTable(766)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isProgram(int program) => Core.gl.glIsProgram(program);

    [LineNumberTable(770)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isRenderbuffer(int renderbuffer) => Core.gl.glIsRenderbuffer(renderbuffer);

    [LineNumberTable(774)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isShader(int shader) => Core.gl.glIsShader(shader);

    [LineNumberTable(778)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isTexture(int texture) => Core.gl.glIsTexture(texture);

    [LineNumberTable(new byte[] {162, 160, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void releaseShaderCompiler() => Core.gl.glReleaseShaderCompiler();

    [LineNumberTable(new byte[] {162, 164, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void renderbufferStorage(int target, int internalformat, int width, int height) => Core.gl.glRenderbufferStorage(target, internalformat, width, height);

    [LineNumberTable(new byte[] {158, 200, 130, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void sampleCoverage(float value, bool invert)
    {
      int num = invert ? 1 : 0;
      Core.gl.glSampleCoverage(value, num != 0);
    }

    [LineNumberTable(new byte[] {162, 176, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stencilFuncSeparate(int face, int func, int @ref, int mask) => Core.gl.glStencilFuncSeparate(face, func, @ref, mask);

    [LineNumberTable(new byte[] {162, 180, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stencilMaskSeparate(int face, int mask) => Core.gl.glStencilMaskSeparate(face, mask);

    [LineNumberTable(new byte[] {162, 184, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void stencilOpSeparate(int face, int fail, int zfail, int zpass) => Core.gl.glStencilOpSeparate(face, fail, zfail, zpass);

    [LineNumberTable(new byte[] {162, 188, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void texParameterfv(int target, int pname, FloatBuffer @params) => Core.gl.glTexParameterfv(target, pname, @params);

    [LineNumberTable(new byte[] {162, 196, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void texParameteriv(int target, int pname, IntBuffer @params) => Core.gl.glTexParameteriv(target, pname, @params);

    [LineNumberTable(new byte[] {162, 204, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform1fv(int location, int count, FloatBuffer v) => Core.gl.glUniform1fv(location, count, v);

    [LineNumberTable(new byte[] {162, 216, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform1iv(int location, int count, IntBuffer v) => Core.gl.glUniform1iv(location, count, v);

    [LineNumberTable(new byte[] {162, 220, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform1iv(int location, int count, int[] v, int offset) => Core.gl.glUniform1iv(location, count, v, offset);

    [LineNumberTable(new byte[] {162, 228, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform2fv(int location, int count, FloatBuffer v) => Core.gl.glUniform2fv(location, count, v);

    [LineNumberTable(new byte[] {162, 240, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform2iv(int location, int count, IntBuffer v) => Core.gl.glUniform2iv(location, count, v);

    [LineNumberTable(new byte[] {162, 244, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform2iv(int location, int count, int[] v, int offset) => Core.gl.glUniform2iv(location, count, v, offset);

    [LineNumberTable(new byte[] {162, 252, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform3fv(int location, int count, FloatBuffer v) => Core.gl.glUniform3fv(location, count, v);

    [LineNumberTable(new byte[] {163, 8, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform3iv(int location, int count, IntBuffer v) => Core.gl.glUniform3iv(location, count, v);

    [LineNumberTable(new byte[] {163, 12, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform3iv(int location, int count, int[] v, int offset) => Core.gl.glUniform3iv(location, count, v, offset);

    [LineNumberTable(new byte[] {163, 20, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform4fv(int location, int count, FloatBuffer v) => Core.gl.glUniform4fv(location, count, v);

    [LineNumberTable(new byte[] {163, 32, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform4iv(int location, int count, IntBuffer v) => Core.gl.glUniform4iv(location, count, v);

    [LineNumberTable(new byte[] {163, 36, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniform4iv(int location, int count, int[] v, int offset) => Core.gl.glUniform4iv(location, count, v, offset);

    [LineNumberTable(new byte[] {158, 168, 130, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniformMatrix2fv(
      int location,
      int count,
      bool transpose,
      FloatBuffer value)
    {
      int num = transpose ? 1 : 0;
      Core.gl.glUniformMatrix2fv(location, count, num != 0, value);
    }

    [LineNumberTable(new byte[] {158, 167, 130, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void uniformMatrix2fv(
      int location,
      int count,
      bool transpose,
      float[] value,
      int offset)
    {
      int num = transpose ? 1 : 0;
      Core.gl.glUniformMatrix2fv(location, count, num != 0, value, offset);
    }

    [LineNumberTable(new byte[] {163, 72, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void validateProgram(int program) => Core.gl.glValidateProgram(program);

    [LineNumberTable(new byte[] {163, 76, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttrib1f(int indx, float x) => Core.gl.glVertexAttrib1f(indx, x);

    [LineNumberTable(new byte[] {163, 80, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttrib1fv(int indx, FloatBuffer values) => Core.gl.glVertexAttrib1fv(indx, values);

    [LineNumberTable(new byte[] {163, 84, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttrib2f(int indx, float x, float y) => Core.gl.glVertexAttrib2f(indx, x, y);

    [LineNumberTable(new byte[] {163, 88, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttrib2fv(int indx, FloatBuffer values) => Core.gl.glVertexAttrib2fv(indx, values);

    [LineNumberTable(new byte[] {163, 92, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttrib3f(int indx, float x, float y, float z) => Core.gl.glVertexAttrib3f(indx, x, y, z);

    [LineNumberTable(new byte[] {163, 96, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttrib3fv(int indx, FloatBuffer values) => Core.gl.glVertexAttrib3fv(indx, values);

    [LineNumberTable(new byte[] {163, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void vertexAttrib4fv(int indx, FloatBuffer values) => Core.gl.glVertexAttrib4fv(indx, values);

    [LineNumberTable(new byte[] {159, 61, 109, 150, 134, 140, 134, 106, 134, 172, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Gl()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.Gl"))
        return;
      Gl.ibuf = Buffers.newIntBuffer(1);
      Gl.ibuf2 = Buffers.newIntBuffer(2);
      Gl.lastActiveTexture = -1;
      Gl.lastBoundTextures = new int[32];
      Gl.lastUsedProgram = 0;
      Gl.enabled = new Bits();
      Gl.wasDepthMask = true;
      Gl.lastSfactor = -1;
      Gl.lastDfactor = -1;
      Gl.reset();
    }
  }
}
