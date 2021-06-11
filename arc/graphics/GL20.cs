// Decompiled with JetBrains decompiler
// Type: arc.graphics.GL20
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.nio;

namespace arc.graphics
{
  public interface GL20
  {
    const int GL_ES_VERSION_2_0 = 1;
    const int GL_DEPTH_BUFFER_BIT = 256;
    const int GL_STENCIL_BUFFER_BIT = 1024;
    const int GL_COLOR_BUFFER_BIT = 16384;
    const int GL_FALSE = 0;
    const int GL_TRUE = 1;
    const int GL_POINTS = 0;
    const int GL_LINES = 1;
    const int GL_LINE_LOOP = 2;
    const int GL_LINE_STRIP = 3;
    const int GL_TRIANGLES = 4;
    const int GL_TRIANGLE_STRIP = 5;
    const int GL_TRIANGLE_FAN = 6;
    const int GL_ZERO = 0;
    const int GL_ONE = 1;
    const int GL_SRC_COLOR = 768;
    const int GL_ONE_MINUS_SRC_COLOR = 769;
    const int GL_SRC_ALPHA = 770;
    const int GL_ONE_MINUS_SRC_ALPHA = 771;
    const int GL_DST_ALPHA = 772;
    const int GL_ONE_MINUS_DST_ALPHA = 773;
    const int GL_DST_COLOR = 774;
    const int GL_ONE_MINUS_DST_COLOR = 775;
    const int GL_SRC_ALPHA_SATURATE = 776;
    const int GL_FUNC_ADD = 32774;
    const int GL_BLEND_EQUATION = 32777;
    const int GL_BLEND_EQUATION_RGB = 32777;
    const int GL_BLEND_EQUATION_ALPHA = 34877;
    const int GL_FUNC_SUBTRACT = 32778;
    const int GL_FUNC_REVERSE_SUBTRACT = 32779;
    const int GL_BLEND_DST_RGB = 32968;
    const int GL_BLEND_SRC_RGB = 32969;
    const int GL_BLEND_DST_ALPHA = 32970;
    const int GL_BLEND_SRC_ALPHA = 32971;
    const int GL_CONSTANT_COLOR = 32769;
    const int GL_ONE_MINUS_CONSTANT_COLOR = 32770;
    const int GL_CONSTANT_ALPHA = 32771;
    const int GL_ONE_MINUS_CONSTANT_ALPHA = 32772;
    const int GL_BLEND_COLOR = 32773;
    const int GL_ARRAY_BUFFER = 34962;
    const int GL_ELEMENT_ARRAY_BUFFER = 34963;
    const int GL_ARRAY_BUFFER_BINDING = 34964;
    const int GL_ELEMENT_ARRAY_BUFFER_BINDING = 34965;
    const int GL_STREAM_DRAW = 35040;
    const int GL_STATIC_DRAW = 35044;
    const int GL_DYNAMIC_DRAW = 35048;
    const int GL_BUFFER_SIZE = 34660;
    const int GL_BUFFER_USAGE = 34661;
    const int GL_CURRENT_VERTEX_ATTRIB = 34342;
    const int GL_FRONT = 1028;
    const int GL_BACK = 1029;
    const int GL_FRONT_AND_BACK = 1032;
    const int GL_TEXTURE_2D = 3553;
    const int GL_CULL_FACE = 2884;
    const int GL_BLEND = 3042;
    const int GL_DITHER = 3024;
    const int GL_STENCIL_TEST = 2960;
    const int GL_DEPTH_TEST = 2929;
    const int GL_SCISSOR_TEST = 3089;
    const int GL_POLYGON_OFFSET_FILL = 32823;
    const int GL_SAMPLE_ALPHA_TO_COVERAGE = 32926;
    const int GL_SAMPLE_COVERAGE = 32928;
    const int GL_NO_ERROR = 0;
    const int GL_INVALID_ENUM = 1280;
    const int GL_INVALID_VALUE = 1281;
    const int GL_INVALID_OPERATION = 1282;
    const int GL_OUT_OF_MEMORY = 1285;
    const int GL_CW = 2304;
    const int GL_CCW = 2305;
    const int GL_LINE_WIDTH = 2849;
    const int GL_ALIASED_POINT_SIZE_RANGE = 33901;
    const int GL_ALIASED_LINE_WIDTH_RANGE = 33902;
    const int GL_CULL_FACE_MODE = 2885;
    const int GL_FRONT_FACE = 2886;
    const int GL_DEPTH_RANGE = 2928;
    const int GL_DEPTH_WRITEMASK = 2930;
    const int GL_DEPTH_CLEAR_VALUE = 2931;
    const int GL_DEPTH_FUNC = 2932;
    const int GL_STENCIL_CLEAR_VALUE = 2961;
    const int GL_STENCIL_FUNC = 2962;
    const int GL_STENCIL_FAIL = 2964;
    const int GL_STENCIL_PASS_DEPTH_FAIL = 2965;
    const int GL_STENCIL_PASS_DEPTH_PASS = 2966;
    const int GL_STENCIL_REF = 2967;
    const int GL_STENCIL_VALUE_MASK = 2963;
    const int GL_STENCIL_WRITEMASK = 2968;
    const int GL_STENCIL_BACK_FUNC = 34816;
    const int GL_STENCIL_BACK_FAIL = 34817;
    const int GL_STENCIL_BACK_PASS_DEPTH_FAIL = 34818;
    const int GL_STENCIL_BACK_PASS_DEPTH_PASS = 34819;
    const int GL_STENCIL_BACK_REF = 36003;
    const int GL_STENCIL_BACK_VALUE_MASK = 36004;
    const int GL_STENCIL_BACK_WRITEMASK = 36005;
    const int GL_VIEWPORT = 2978;
    const int GL_SCISSOR_BOX = 3088;
    const int GL_COLOR_CLEAR_VALUE = 3106;
    const int GL_COLOR_WRITEMASK = 3107;
    const int GL_UNPACK_ALIGNMENT = 3317;
    const int GL_PACK_ALIGNMENT = 3333;
    const int GL_MAX_TEXTURE_SIZE = 3379;
    const int GL_MAX_TEXTURE_UNITS = 34018;
    const int GL_MAX_VIEWPORT_DIMS = 3386;
    const int GL_SUBPIXEL_BITS = 3408;
    const int GL_RED_BITS = 3410;
    const int GL_GREEN_BITS = 3411;
    const int GL_BLUE_BITS = 3412;
    const int GL_ALPHA_BITS = 3413;
    const int GL_DEPTH_BITS = 3414;
    const int GL_STENCIL_BITS = 3415;
    const int GL_POLYGON_OFFSET_UNITS = 10752;
    const int GL_POLYGON_OFFSET_FACTOR = 32824;
    const int GL_TEXTURE_BINDING_2D = 32873;
    const int GL_SAMPLE_BUFFERS = 32936;
    const int GL_SAMPLES = 32937;
    const int GL_SAMPLE_COVERAGE_VALUE = 32938;
    const int GL_SAMPLE_COVERAGE_INVERT = 32939;
    const int GL_NUM_COMPRESSED_TEXTURE_FORMATS = 34466;
    const int GL_COMPRESSED_TEXTURE_FORMATS = 34467;
    const int GL_DONT_CARE = 4352;
    const int GL_FASTEST = 4353;
    const int GL_NICEST = 4354;
    const int GL_GENERATE_MIPMAP = 33169;
    const int GL_GENERATE_MIPMAP_HINT = 33170;
    const int GL_BYTE = 5120;
    const int GL_UNSIGNED_BYTE = 5121;
    const int GL_SHORT = 5122;
    const int GL_UNSIGNED_SHORT = 5123;
    const int GL_INT = 5124;
    const int GL_UNSIGNED_INT = 5125;
    const int GL_FLOAT = 5126;
    const int GL_FIXED = 5132;
    const int GL_DEPTH_COMPONENT = 6402;
    const int GL_ALPHA = 6406;
    const int GL_RGB = 6407;
    const int GL_RGBA = 6408;
    const int GL_LUMINANCE = 6409;
    const int GL_LUMINANCE_ALPHA = 6410;
    const int GL_UNSIGNED_SHORT_4_4_4_4 = 32819;
    const int GL_UNSIGNED_SHORT_5_5_5_1 = 32820;
    const int GL_UNSIGNED_SHORT_5_6_5 = 33635;
    const int GL_FRAGMENT_SHADER = 35632;
    const int GL_VERTEX_SHADER = 35633;
    const int GL_MAX_VERTEX_ATTRIBS = 34921;
    const int GL_MAX_VERTEX_UNIFORM_VECTORS = 36347;
    const int GL_MAX_VARYING_VECTORS = 36348;
    const int GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 35661;
    const int GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 35660;
    const int GL_MAX_TEXTURE_IMAGE_UNITS = 34930;
    const int GL_MAX_FRAGMENT_UNIFORM_VECTORS = 36349;
    const int GL_SHADER_TYPE = 35663;
    const int GL_DELETE_STATUS = 35712;
    const int GL_LINK_STATUS = 35714;
    const int GL_VALIDATE_STATUS = 35715;
    const int GL_ATTACHED_SHADERS = 35717;
    const int GL_ACTIVE_UNIFORMS = 35718;
    const int GL_ACTIVE_UNIFORM_MAX_LENGTH = 35719;
    const int GL_ACTIVE_ATTRIBUTES = 35721;
    const int GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 35722;
    const int GL_SHADING_LANGUAGE_VERSION = 35724;
    const int GL_CURRENT_PROGRAM = 35725;
    const int GL_NEVER = 512;
    const int GL_LESS = 513;
    const int GL_EQUAL = 514;
    const int GL_LEQUAL = 515;
    const int GL_GREATER = 516;
    const int GL_NOTEQUAL = 517;
    const int GL_GEQUAL = 518;
    const int GL_ALWAYS = 519;
    const int GL_KEEP = 7680;
    const int GL_REPLACE = 7681;
    const int GL_INCR = 7682;
    const int GL_DECR = 7683;
    const int GL_INVERT = 5386;
    const int GL_INCR_WRAP = 34055;
    const int GL_DECR_WRAP = 34056;
    const int GL_VENDOR = 7936;
    const int GL_RENDERER = 7937;
    const int GL_VERSION = 7938;
    const int GL_EXTENSIONS = 7939;
    const int GL_NEAREST = 9728;
    const int GL_LINEAR = 9729;
    const int GL_NEAREST_MIPMAP_NEAREST = 9984;
    const int GL_LINEAR_MIPMAP_NEAREST = 9985;
    const int GL_NEAREST_MIPMAP_LINEAR = 9986;
    const int GL_LINEAR_MIPMAP_LINEAR = 9987;
    const int GL_TEXTURE_MAG_FILTER = 10240;
    const int GL_TEXTURE_MIN_FILTER = 10241;
    const int GL_TEXTURE_WRAP_S = 10242;
    const int GL_TEXTURE_WRAP_T = 10243;
    const int GL_TEXTURE = 5890;
    const int GL_TEXTURE_CUBE_MAP = 34067;
    const int GL_TEXTURE_BINDING_CUBE_MAP = 34068;
    const int GL_TEXTURE_CUBE_MAP_POSITIVE_X = 34069;
    const int GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 34070;
    const int GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 34071;
    const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 34072;
    const int GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 34073;
    const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 34074;
    const int GL_MAX_CUBE_MAP_TEXTURE_SIZE = 34076;
    const int GL_TEXTURE0 = 33984;
    const int GL_TEXTURE1 = 33985;
    const int GL_TEXTURE2 = 33986;
    const int GL_TEXTURE3 = 33987;
    const int GL_TEXTURE4 = 33988;
    const int GL_TEXTURE5 = 33989;
    const int GL_TEXTURE6 = 33990;
    const int GL_TEXTURE7 = 33991;
    const int GL_TEXTURE8 = 33992;
    const int GL_TEXTURE9 = 33993;
    const int GL_TEXTURE10 = 33994;
    const int GL_TEXTURE11 = 33995;
    const int GL_TEXTURE12 = 33996;
    const int GL_TEXTURE13 = 33997;
    const int GL_TEXTURE14 = 33998;
    const int GL_TEXTURE15 = 33999;
    const int GL_TEXTURE16 = 34000;
    const int GL_TEXTURE17 = 34001;
    const int GL_TEXTURE18 = 34002;
    const int GL_TEXTURE19 = 34003;
    const int GL_TEXTURE20 = 34004;
    const int GL_TEXTURE21 = 34005;
    const int GL_TEXTURE22 = 34006;
    const int GL_TEXTURE23 = 34007;
    const int GL_TEXTURE24 = 34008;
    const int GL_TEXTURE25 = 34009;
    const int GL_TEXTURE26 = 34010;
    const int GL_TEXTURE27 = 34011;
    const int GL_TEXTURE28 = 34012;
    const int GL_TEXTURE29 = 34013;
    const int GL_TEXTURE30 = 34014;
    const int GL_TEXTURE31 = 34015;
    const int GL_ACTIVE_TEXTURE = 34016;
    const int GL_REPEAT = 10497;
    const int GL_CLAMP_TO_EDGE = 33071;
    const int GL_MIRRORED_REPEAT = 33648;
    const int GL_FLOAT_VEC2 = 35664;
    const int GL_FLOAT_VEC3 = 35665;
    const int GL_FLOAT_VEC4 = 35666;
    const int GL_INT_VEC2 = 35667;
    const int GL_INT_VEC3 = 35668;
    const int GL_INT_VEC4 = 35669;
    const int GL_BOOL = 35670;
    const int GL_BOOL_VEC2 = 35671;
    const int GL_BOOL_VEC3 = 35672;
    const int GL_BOOL_VEC4 = 35673;
    const int GL_FLOAT_MAT2 = 35674;
    const int GL_FLOAT_MAT3 = 35675;
    const int GL_FLOAT_MAT4 = 35676;
    const int GL_SAMPLER_2D = 35678;
    const int GL_SAMPLER_CUBE = 35680;
    const int GL_VERTEX_ATTRIB_ARRAY_ENABLED = 34338;
    const int GL_VERTEX_ATTRIB_ARRAY_SIZE = 34339;
    const int GL_VERTEX_ATTRIB_ARRAY_STRIDE = 34340;
    const int GL_VERTEX_ATTRIB_ARRAY_TYPE = 34341;
    const int GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 34922;
    const int GL_VERTEX_ATTRIB_ARRAY_POINTER = 34373;
    const int GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 34975;
    const int GL_IMPLEMENTATION_COLOR_READ_TYPE = 35738;
    const int GL_IMPLEMENTATION_COLOR_READ_FORMAT = 35739;
    const int GL_COMPILE_STATUS = 35713;
    const int GL_INFO_LOG_LENGTH = 35716;
    const int GL_SHADER_SOURCE_LENGTH = 35720;
    const int GL_SHADER_COMPILER = 36346;
    const int GL_SHADER_BINARY_FORMATS = 36344;
    const int GL_NUM_SHADER_BINARY_FORMATS = 36345;
    const int GL_LOW_FLOAT = 36336;
    const int GL_MEDIUM_FLOAT = 36337;
    const int GL_HIGH_FLOAT = 36338;
    const int GL_LOW_INT = 36339;
    const int GL_MEDIUM_INT = 36340;
    const int GL_HIGH_INT = 36341;
    const int GL_FRAMEBUFFER = 36160;
    const int GL_RENDERBUFFER = 36161;
    const int GL_RGBA4 = 32854;
    const int GL_RGB5_A1 = 32855;
    const int GL_RGB565 = 36194;
    const int GL_DEPTH_COMPONENT16 = 33189;
    const int GL_STENCIL_INDEX = 6401;
    const int GL_STENCIL_INDEX8 = 36168;
    const int GL_RENDERBUFFER_WIDTH = 36162;
    const int GL_RENDERBUFFER_HEIGHT = 36163;
    const int GL_RENDERBUFFER_INTERNAL_FORMAT = 36164;
    const int GL_RENDERBUFFER_RED_SIZE = 36176;
    const int GL_RENDERBUFFER_GREEN_SIZE = 36177;
    const int GL_RENDERBUFFER_BLUE_SIZE = 36178;
    const int GL_RENDERBUFFER_ALPHA_SIZE = 36179;
    const int GL_RENDERBUFFER_DEPTH_SIZE = 36180;
    const int GL_RENDERBUFFER_STENCIL_SIZE = 36181;
    const int GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 36048;
    const int GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 36049;
    const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 36050;
    const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 36051;
    const int GL_COLOR_ATTACHMENT0 = 36064;
    const int GL_DEPTH_ATTACHMENT = 36096;
    const int GL_STENCIL_ATTACHMENT = 36128;
    const int GL_NONE = 0;
    const int GL_FRAMEBUFFER_COMPLETE = 36053;
    const int GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 36054;
    const int GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 36055;
    const int GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 36057;
    const int GL_FRAMEBUFFER_UNSUPPORTED = 36061;
    const int GL_FRAMEBUFFER_BINDING = 36006;
    const int GL_RENDERBUFFER_BINDING = 36007;
    const int GL_MAX_RENDERBUFFER_SIZE = 34024;
    const int GL_INVALID_FRAMEBUFFER_OPERATION = 1286;
    const int GL_VERTEX_PROGRAM_POINT_SIZE = 34370;
    const int GL_COVERAGE_BUFFER_BIT_NV = 32768;
    const int GL_TEXTURE_MAX_ANISOTROPY_EXT = 34046;
    const int GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT = 34047;

    void glActiveTexture(int i);

    void glBindTexture(int i1, int i2);

    void glBlendFunc(int i1, int i2);

    void glClear(int i);

    void glClearColor(float f1, float f2, float f3, float f4);

    void glClearDepthf(float f);

    void glClearStencil(int i);

    void glColorMask(bool b1, bool b2, bool b3, bool b4);

    void glCompressedTexImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      Buffer b);

    void glCompressedTexSubImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      Buffer b);

    void glCopyTexImage2D(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8);

    void glCopyTexSubImage2D(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8);

    void glCullFace(int i);

    void glDeleteTexture(int i);

    void glDepthFunc(int i);

    void glDepthMask(bool b);

    void glDepthRangef(float f1, float f2);

    void glDisable(int i);

    void glDrawArrays(int i1, int i2, int i3);

    void glDrawElements(int i1, int i2, int i3, Buffer b);

    void glEnable(int i);

    void glFinish();

    void glFlush();

    void glFrontFace(int i);

    int glGenTexture();

    int glGetError();

    void glGetIntegerv(int i, IntBuffer ib);

    string glGetString(int i);

    void glHint(int i1, int i2);

    void glLineWidth(float f);

    void glPixelStorei(int i1, int i2);

    void glPolygonOffset(float f1, float f2);

    void glReadPixels(int i1, int i2, int i3, int i4, int i5, int i6, Buffer b);

    void glScissor(int i1, int i2, int i3, int i4);

    void glStencilFunc(int i1, int i2, int i3);

    void glStencilMask(int i);

    void glStencilOp(int i1, int i2, int i3);

    void glTexImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      Buffer b);

    void glTexParameterf(int i1, int i2, float f);

    void glTexSubImage2D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      Buffer b);

    void glViewport(int i1, int i2, int i3, int i4);

    void glAttachShader(int i1, int i2);

    void glBindAttribLocation(int i1, int i2, string str);

    void glBindBuffer(int i1, int i2);

    void glBindFramebuffer(int i1, int i2);

    void glBindRenderbuffer(int i1, int i2);

    void glBlendColor(float f1, float f2, float f3, float f4);

    void glBlendEquation(int i);

    void glBlendEquationSeparate(int i1, int i2);

    void glBlendFuncSeparate(int i1, int i2, int i3, int i4);

    void glBufferData(int i1, int i2, Buffer b, int i3);

    void glBufferSubData(int i1, int i2, int i3, Buffer b);

    int glCheckFramebufferStatus(int i);

    void glCompileShader(int i);

    int glCreateProgram();

    int glCreateShader(int i);

    void glDeleteBuffer(int i);

    void glDeleteFramebuffer(int i);

    void glDeleteProgram(int i);

    void glDeleteRenderbuffer(int i);

    void glDeleteShader(int i);

    void glDetachShader(int i1, int i2);

    void glDisableVertexAttribArray(int i);

    void glDrawElements(int i1, int i2, int i3, int i4);

    void glEnableVertexAttribArray(int i);

    void glFramebufferRenderbuffer(int i1, int i2, int i3, int i4);

    void glFramebufferTexture2D(int i1, int i2, int i3, int i4, int i5);

    int glGenBuffer();

    void glGenerateMipmap(int i);

    int glGenFramebuffer();

    int glGenRenderbuffer();

    string glGetActiveAttrib(int i1, int i2, IntBuffer ib1, IntBuffer ib2);

    string glGetActiveUniform(int i1, int i2, IntBuffer ib1, IntBuffer ib2);

    int glGetAttribLocation(int i, string str);

    void glGetBooleanv(int i, Buffer b);

    void glGetBufferParameteriv(int i1, int i2, IntBuffer ib);

    void glGetFloatv(int i, FloatBuffer fb);

    void glGetFramebufferAttachmentParameteriv(int i1, int i2, int i3, IntBuffer ib);

    void glGetProgramiv(int i1, int i2, IntBuffer ib);

    string glGetProgramInfoLog(int i);

    void glGetRenderbufferParameteriv(int i1, int i2, IntBuffer ib);

    void glGetShaderiv(int i1, int i2, IntBuffer ib);

    string glGetShaderInfoLog(int i);

    void glGetShaderPrecisionFormat(int i1, int i2, IntBuffer ib1, IntBuffer ib2);

    void glGetTexParameterfv(int i1, int i2, FloatBuffer fb);

    void glGetTexParameteriv(int i1, int i2, IntBuffer ib);

    void glGetUniformfv(int i1, int i2, FloatBuffer fb);

    void glGetUniformiv(int i1, int i2, IntBuffer ib);

    int glGetUniformLocation(int i, string str);

    void glGetVertexAttribfv(int i1, int i2, FloatBuffer fb);

    void glGetVertexAttribiv(int i1, int i2, IntBuffer ib);

    bool glIsBuffer(int i);

    bool glIsEnabled(int i);

    bool glIsFramebuffer(int i);

    bool glIsProgram(int i);

    bool glIsRenderbuffer(int i);

    bool glIsShader(int i);

    bool glIsTexture(int i);

    void glLinkProgram(int i);

    void glReleaseShaderCompiler();

    void glRenderbufferStorage(int i1, int i2, int i3, int i4);

    void glSampleCoverage(float f, bool b);

    void glShaderSource(int i, string str);

    void glStencilFuncSeparate(int i1, int i2, int i3, int i4);

    void glStencilMaskSeparate(int i1, int i2);

    void glStencilOpSeparate(int i1, int i2, int i3, int i4);

    void glTexParameterfv(int i1, int i2, FloatBuffer fb);

    void glTexParameteri(int i1, int i2, int i3);

    void glTexParameteriv(int i1, int i2, IntBuffer ib);

    void glUniform1f(int i, float f);

    void glUniform1fv(int i1, int i2, FloatBuffer fb);

    void glUniform1fv(int i1, int i2, float[] farr, int i3);

    void glUniform1i(int i1, int i2);

    void glUniform1iv(int i1, int i2, IntBuffer ib);

    void glUniform1iv(int i1, int i2, int[] iarr, int i3);

    void glUniform2f(int i, float f1, float f2);

    void glUniform2fv(int i1, int i2, FloatBuffer fb);

    void glUniform2fv(int i1, int i2, float[] farr, int i3);

    void glUniform2i(int i1, int i2, int i3);

    void glUniform2iv(int i1, int i2, IntBuffer ib);

    void glUniform2iv(int i1, int i2, int[] iarr, int i3);

    void glUniform3f(int i, float f1, float f2, float f3);

    void glUniform3fv(int i1, int i2, FloatBuffer fb);

    void glUniform3fv(int i1, int i2, float[] farr, int i3);

    void glUniform3i(int i1, int i2, int i3, int i4);

    void glUniform3iv(int i1, int i2, IntBuffer ib);

    void glUniform3iv(int i1, int i2, int[] iarr, int i3);

    void glUniform4f(int i, float f1, float f2, float f3, float f4);

    void glUniform4fv(int i1, int i2, FloatBuffer fb);

    void glUniform4fv(int i1, int i2, float[] farr, int i3);

    void glUniform4i(int i1, int i2, int i3, int i4, int i5);

    void glUniform4iv(int i1, int i2, IntBuffer ib);

    void glUniform4iv(int i1, int i2, int[] iarr, int i3);

    void glUniformMatrix2fv(int i1, int i2, bool b, FloatBuffer fb);

    void glUniformMatrix2fv(int i1, int i2, bool b, float[] farr, int i3);

    void glUniformMatrix3fv(int i1, int i2, bool b, FloatBuffer fb);

    void glUniformMatrix3fv(int i1, int i2, bool b, float[] farr, int i3);

    void glUniformMatrix4fv(int i1, int i2, bool b, FloatBuffer fb);

    void glUniformMatrix4fv(int i1, int i2, bool b, float[] farr, int i3);

    void glUseProgram(int i);

    void glValidateProgram(int i);

    void glVertexAttrib1f(int i, float f);

    void glVertexAttrib1fv(int i, FloatBuffer fb);

    void glVertexAttrib2f(int i, float f1, float f2);

    void glVertexAttrib2fv(int i, FloatBuffer fb);

    void glVertexAttrib3f(int i, float f1, float f2, float f3);

    void glVertexAttrib3fv(int i, FloatBuffer fb);

    void glVertexAttrib4f(int i, float f1, float f2, float f3, float f4);

    void glVertexAttrib4fv(int i, FloatBuffer fb);

    void glVertexAttribPointer(int i1, int i2, int i3, bool b1, int i4, Buffer b2);

    void glVertexAttribPointer(int i1, int i2, int i3, bool b, int i4, int i5);

    [HideFromJava]
    static class __Fields
    {
      public const int GL_ES_VERSION_2_0 = 1;
      public const int GL_DEPTH_BUFFER_BIT = 256;
      public const int GL_STENCIL_BUFFER_BIT = 1024;
      public const int GL_COLOR_BUFFER_BIT = 16384;
      public const int GL_FALSE = 0;
      public const int GL_TRUE = 1;
      public const int GL_POINTS = 0;
      public const int GL_LINES = 1;
      public const int GL_LINE_LOOP = 2;
      public const int GL_LINE_STRIP = 3;
      public const int GL_TRIANGLES = 4;
      public const int GL_TRIANGLE_STRIP = 5;
      public const int GL_TRIANGLE_FAN = 6;
      public const int GL_ZERO = 0;
      public const int GL_ONE = 1;
      public const int GL_SRC_COLOR = 768;
      public const int GL_ONE_MINUS_SRC_COLOR = 769;
      public const int GL_SRC_ALPHA = 770;
      public const int GL_ONE_MINUS_SRC_ALPHA = 771;
      public const int GL_DST_ALPHA = 772;
      public const int GL_ONE_MINUS_DST_ALPHA = 773;
      public const int GL_DST_COLOR = 774;
      public const int GL_ONE_MINUS_DST_COLOR = 775;
      public const int GL_SRC_ALPHA_SATURATE = 776;
      public const int GL_FUNC_ADD = 32774;
      public const int GL_BLEND_EQUATION = 32777;
      public const int GL_BLEND_EQUATION_RGB = 32777;
      public const int GL_BLEND_EQUATION_ALPHA = 34877;
      public const int GL_FUNC_SUBTRACT = 32778;
      public const int GL_FUNC_REVERSE_SUBTRACT = 32779;
      public const int GL_BLEND_DST_RGB = 32968;
      public const int GL_BLEND_SRC_RGB = 32969;
      public const int GL_BLEND_DST_ALPHA = 32970;
      public const int GL_BLEND_SRC_ALPHA = 32971;
      public const int GL_CONSTANT_COLOR = 32769;
      public const int GL_ONE_MINUS_CONSTANT_COLOR = 32770;
      public const int GL_CONSTANT_ALPHA = 32771;
      public const int GL_ONE_MINUS_CONSTANT_ALPHA = 32772;
      public const int GL_BLEND_COLOR = 32773;
      public const int GL_ARRAY_BUFFER = 34962;
      public const int GL_ELEMENT_ARRAY_BUFFER = 34963;
      public const int GL_ARRAY_BUFFER_BINDING = 34964;
      public const int GL_ELEMENT_ARRAY_BUFFER_BINDING = 34965;
      public const int GL_STREAM_DRAW = 35040;
      public const int GL_STATIC_DRAW = 35044;
      public const int GL_DYNAMIC_DRAW = 35048;
      public const int GL_BUFFER_SIZE = 34660;
      public const int GL_BUFFER_USAGE = 34661;
      public const int GL_CURRENT_VERTEX_ATTRIB = 34342;
      public const int GL_FRONT = 1028;
      public const int GL_BACK = 1029;
      public const int GL_FRONT_AND_BACK = 1032;
      public const int GL_TEXTURE_2D = 3553;
      public const int GL_CULL_FACE = 2884;
      public const int GL_BLEND = 3042;
      public const int GL_DITHER = 3024;
      public const int GL_STENCIL_TEST = 2960;
      public const int GL_DEPTH_TEST = 2929;
      public const int GL_SCISSOR_TEST = 3089;
      public const int GL_POLYGON_OFFSET_FILL = 32823;
      public const int GL_SAMPLE_ALPHA_TO_COVERAGE = 32926;
      public const int GL_SAMPLE_COVERAGE = 32928;
      public const int GL_NO_ERROR = 0;
      public const int GL_INVALID_ENUM = 1280;
      public const int GL_INVALID_VALUE = 1281;
      public const int GL_INVALID_OPERATION = 1282;
      public const int GL_OUT_OF_MEMORY = 1285;
      public const int GL_CW = 2304;
      public const int GL_CCW = 2305;
      public const int GL_LINE_WIDTH = 2849;
      public const int GL_ALIASED_POINT_SIZE_RANGE = 33901;
      public const int GL_ALIASED_LINE_WIDTH_RANGE = 33902;
      public const int GL_CULL_FACE_MODE = 2885;
      public const int GL_FRONT_FACE = 2886;
      public const int GL_DEPTH_RANGE = 2928;
      public const int GL_DEPTH_WRITEMASK = 2930;
      public const int GL_DEPTH_CLEAR_VALUE = 2931;
      public const int GL_DEPTH_FUNC = 2932;
      public const int GL_STENCIL_CLEAR_VALUE = 2961;
      public const int GL_STENCIL_FUNC = 2962;
      public const int GL_STENCIL_FAIL = 2964;
      public const int GL_STENCIL_PASS_DEPTH_FAIL = 2965;
      public const int GL_STENCIL_PASS_DEPTH_PASS = 2966;
      public const int GL_STENCIL_REF = 2967;
      public const int GL_STENCIL_VALUE_MASK = 2963;
      public const int GL_STENCIL_WRITEMASK = 2968;
      public const int GL_STENCIL_BACK_FUNC = 34816;
      public const int GL_STENCIL_BACK_FAIL = 34817;
      public const int GL_STENCIL_BACK_PASS_DEPTH_FAIL = 34818;
      public const int GL_STENCIL_BACK_PASS_DEPTH_PASS = 34819;
      public const int GL_STENCIL_BACK_REF = 36003;
      public const int GL_STENCIL_BACK_VALUE_MASK = 36004;
      public const int GL_STENCIL_BACK_WRITEMASK = 36005;
      public const int GL_VIEWPORT = 2978;
      public const int GL_SCISSOR_BOX = 3088;
      public const int GL_COLOR_CLEAR_VALUE = 3106;
      public const int GL_COLOR_WRITEMASK = 3107;
      public const int GL_UNPACK_ALIGNMENT = 3317;
      public const int GL_PACK_ALIGNMENT = 3333;
      public const int GL_MAX_TEXTURE_SIZE = 3379;
      public const int GL_MAX_TEXTURE_UNITS = 34018;
      public const int GL_MAX_VIEWPORT_DIMS = 3386;
      public const int GL_SUBPIXEL_BITS = 3408;
      public const int GL_RED_BITS = 3410;
      public const int GL_GREEN_BITS = 3411;
      public const int GL_BLUE_BITS = 3412;
      public const int GL_ALPHA_BITS = 3413;
      public const int GL_DEPTH_BITS = 3414;
      public const int GL_STENCIL_BITS = 3415;
      public const int GL_POLYGON_OFFSET_UNITS = 10752;
      public const int GL_POLYGON_OFFSET_FACTOR = 32824;
      public const int GL_TEXTURE_BINDING_2D = 32873;
      public const int GL_SAMPLE_BUFFERS = 32936;
      public const int GL_SAMPLES = 32937;
      public const int GL_SAMPLE_COVERAGE_VALUE = 32938;
      public const int GL_SAMPLE_COVERAGE_INVERT = 32939;
      public const int GL_NUM_COMPRESSED_TEXTURE_FORMATS = 34466;
      public const int GL_COMPRESSED_TEXTURE_FORMATS = 34467;
      public const int GL_DONT_CARE = 4352;
      public const int GL_FASTEST = 4353;
      public const int GL_NICEST = 4354;
      public const int GL_GENERATE_MIPMAP = 33169;
      public const int GL_GENERATE_MIPMAP_HINT = 33170;
      public const int GL_BYTE = 5120;
      public const int GL_UNSIGNED_BYTE = 5121;
      public const int GL_SHORT = 5122;
      public const int GL_UNSIGNED_SHORT = 5123;
      public const int GL_INT = 5124;
      public const int GL_UNSIGNED_INT = 5125;
      public const int GL_FLOAT = 5126;
      public const int GL_FIXED = 5132;
      public const int GL_DEPTH_COMPONENT = 6402;
      public const int GL_ALPHA = 6406;
      public const int GL_RGB = 6407;
      public const int GL_RGBA = 6408;
      public const int GL_LUMINANCE = 6409;
      public const int GL_LUMINANCE_ALPHA = 6410;
      public const int GL_UNSIGNED_SHORT_4_4_4_4 = 32819;
      public const int GL_UNSIGNED_SHORT_5_5_5_1 = 32820;
      public const int GL_UNSIGNED_SHORT_5_6_5 = 33635;
      public const int GL_FRAGMENT_SHADER = 35632;
      public const int GL_VERTEX_SHADER = 35633;
      public const int GL_MAX_VERTEX_ATTRIBS = 34921;
      public const int GL_MAX_VERTEX_UNIFORM_VECTORS = 36347;
      public const int GL_MAX_VARYING_VECTORS = 36348;
      public const int GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 35661;
      public const int GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 35660;
      public const int GL_MAX_TEXTURE_IMAGE_UNITS = 34930;
      public const int GL_MAX_FRAGMENT_UNIFORM_VECTORS = 36349;
      public const int GL_SHADER_TYPE = 35663;
      public const int GL_DELETE_STATUS = 35712;
      public const int GL_LINK_STATUS = 35714;
      public const int GL_VALIDATE_STATUS = 35715;
      public const int GL_ATTACHED_SHADERS = 35717;
      public const int GL_ACTIVE_UNIFORMS = 35718;
      public const int GL_ACTIVE_UNIFORM_MAX_LENGTH = 35719;
      public const int GL_ACTIVE_ATTRIBUTES = 35721;
      public const int GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 35722;
      public const int GL_SHADING_LANGUAGE_VERSION = 35724;
      public const int GL_CURRENT_PROGRAM = 35725;
      public const int GL_NEVER = 512;
      public const int GL_LESS = 513;
      public const int GL_EQUAL = 514;
      public const int GL_LEQUAL = 515;
      public const int GL_GREATER = 516;
      public const int GL_NOTEQUAL = 517;
      public const int GL_GEQUAL = 518;
      public const int GL_ALWAYS = 519;
      public const int GL_KEEP = 7680;
      public const int GL_REPLACE = 7681;
      public const int GL_INCR = 7682;
      public const int GL_DECR = 7683;
      public const int GL_INVERT = 5386;
      public const int GL_INCR_WRAP = 34055;
      public const int GL_DECR_WRAP = 34056;
      public const int GL_VENDOR = 7936;
      public const int GL_RENDERER = 7937;
      public const int GL_VERSION = 7938;
      public const int GL_EXTENSIONS = 7939;
      public const int GL_NEAREST = 9728;
      public const int GL_LINEAR = 9729;
      public const int GL_NEAREST_MIPMAP_NEAREST = 9984;
      public const int GL_LINEAR_MIPMAP_NEAREST = 9985;
      public const int GL_NEAREST_MIPMAP_LINEAR = 9986;
      public const int GL_LINEAR_MIPMAP_LINEAR = 9987;
      public const int GL_TEXTURE_MAG_FILTER = 10240;
      public const int GL_TEXTURE_MIN_FILTER = 10241;
      public const int GL_TEXTURE_WRAP_S = 10242;
      public const int GL_TEXTURE_WRAP_T = 10243;
      public const int GL_TEXTURE = 5890;
      public const int GL_TEXTURE_CUBE_MAP = 34067;
      public const int GL_TEXTURE_BINDING_CUBE_MAP = 34068;
      public const int GL_TEXTURE_CUBE_MAP_POSITIVE_X = 34069;
      public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 34070;
      public const int GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 34071;
      public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 34072;
      public const int GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 34073;
      public const int GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 34074;
      public const int GL_MAX_CUBE_MAP_TEXTURE_SIZE = 34076;
      public const int GL_TEXTURE0 = 33984;
      public const int GL_TEXTURE1 = 33985;
      public const int GL_TEXTURE2 = 33986;
      public const int GL_TEXTURE3 = 33987;
      public const int GL_TEXTURE4 = 33988;
      public const int GL_TEXTURE5 = 33989;
      public const int GL_TEXTURE6 = 33990;
      public const int GL_TEXTURE7 = 33991;
      public const int GL_TEXTURE8 = 33992;
      public const int GL_TEXTURE9 = 33993;
      public const int GL_TEXTURE10 = 33994;
      public const int GL_TEXTURE11 = 33995;
      public const int GL_TEXTURE12 = 33996;
      public const int GL_TEXTURE13 = 33997;
      public const int GL_TEXTURE14 = 33998;
      public const int GL_TEXTURE15 = 33999;
      public const int GL_TEXTURE16 = 34000;
      public const int GL_TEXTURE17 = 34001;
      public const int GL_TEXTURE18 = 34002;
      public const int GL_TEXTURE19 = 34003;
      public const int GL_TEXTURE20 = 34004;
      public const int GL_TEXTURE21 = 34005;
      public const int GL_TEXTURE22 = 34006;
      public const int GL_TEXTURE23 = 34007;
      public const int GL_TEXTURE24 = 34008;
      public const int GL_TEXTURE25 = 34009;
      public const int GL_TEXTURE26 = 34010;
      public const int GL_TEXTURE27 = 34011;
      public const int GL_TEXTURE28 = 34012;
      public const int GL_TEXTURE29 = 34013;
      public const int GL_TEXTURE30 = 34014;
      public const int GL_TEXTURE31 = 34015;
      public const int GL_ACTIVE_TEXTURE = 34016;
      public const int GL_REPEAT = 10497;
      public const int GL_CLAMP_TO_EDGE = 33071;
      public const int GL_MIRRORED_REPEAT = 33648;
      public const int GL_FLOAT_VEC2 = 35664;
      public const int GL_FLOAT_VEC3 = 35665;
      public const int GL_FLOAT_VEC4 = 35666;
      public const int GL_INT_VEC2 = 35667;
      public const int GL_INT_VEC3 = 35668;
      public const int GL_INT_VEC4 = 35669;
      public const int GL_BOOL = 35670;
      public const int GL_BOOL_VEC2 = 35671;
      public const int GL_BOOL_VEC3 = 35672;
      public const int GL_BOOL_VEC4 = 35673;
      public const int GL_FLOAT_MAT2 = 35674;
      public const int GL_FLOAT_MAT3 = 35675;
      public const int GL_FLOAT_MAT4 = 35676;
      public const int GL_SAMPLER_2D = 35678;
      public const int GL_SAMPLER_CUBE = 35680;
      public const int GL_VERTEX_ATTRIB_ARRAY_ENABLED = 34338;
      public const int GL_VERTEX_ATTRIB_ARRAY_SIZE = 34339;
      public const int GL_VERTEX_ATTRIB_ARRAY_STRIDE = 34340;
      public const int GL_VERTEX_ATTRIB_ARRAY_TYPE = 34341;
      public const int GL_VERTEX_ATTRIB_ARRAY_NORMALIZED = 34922;
      public const int GL_VERTEX_ATTRIB_ARRAY_POINTER = 34373;
      public const int GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 34975;
      public const int GL_IMPLEMENTATION_COLOR_READ_TYPE = 35738;
      public const int GL_IMPLEMENTATION_COLOR_READ_FORMAT = 35739;
      public const int GL_COMPILE_STATUS = 35713;
      public const int GL_INFO_LOG_LENGTH = 35716;
      public const int GL_SHADER_SOURCE_LENGTH = 35720;
      public const int GL_SHADER_COMPILER = 36346;
      public const int GL_SHADER_BINARY_FORMATS = 36344;
      public const int GL_NUM_SHADER_BINARY_FORMATS = 36345;
      public const int GL_LOW_FLOAT = 36336;
      public const int GL_MEDIUM_FLOAT = 36337;
      public const int GL_HIGH_FLOAT = 36338;
      public const int GL_LOW_INT = 36339;
      public const int GL_MEDIUM_INT = 36340;
      public const int GL_HIGH_INT = 36341;
      public const int GL_FRAMEBUFFER = 36160;
      public const int GL_RENDERBUFFER = 36161;
      public const int GL_RGBA4 = 32854;
      public const int GL_RGB5_A1 = 32855;
      public const int GL_RGB565 = 36194;
      public const int GL_DEPTH_COMPONENT16 = 33189;
      public const int GL_STENCIL_INDEX = 6401;
      public const int GL_STENCIL_INDEX8 = 36168;
      public const int GL_RENDERBUFFER_WIDTH = 36162;
      public const int GL_RENDERBUFFER_HEIGHT = 36163;
      public const int GL_RENDERBUFFER_INTERNAL_FORMAT = 36164;
      public const int GL_RENDERBUFFER_RED_SIZE = 36176;
      public const int GL_RENDERBUFFER_GREEN_SIZE = 36177;
      public const int GL_RENDERBUFFER_BLUE_SIZE = 36178;
      public const int GL_RENDERBUFFER_ALPHA_SIZE = 36179;
      public const int GL_RENDERBUFFER_DEPTH_SIZE = 36180;
      public const int GL_RENDERBUFFER_STENCIL_SIZE = 36181;
      public const int GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = 36048;
      public const int GL_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = 36049;
      public const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = 36050;
      public const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = 36051;
      public const int GL_COLOR_ATTACHMENT0 = 36064;
      public const int GL_DEPTH_ATTACHMENT = 36096;
      public const int GL_STENCIL_ATTACHMENT = 36128;
      public const int GL_NONE = 0;
      public const int GL_FRAMEBUFFER_COMPLETE = 36053;
      public const int GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 36054;
      public const int GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 36055;
      public const int GL_FRAMEBUFFER_INCOMPLETE_DIMENSIONS = 36057;
      public const int GL_FRAMEBUFFER_UNSUPPORTED = 36061;
      public const int GL_FRAMEBUFFER_BINDING = 36006;
      public const int GL_RENDERBUFFER_BINDING = 36007;
      public const int GL_MAX_RENDERBUFFER_SIZE = 34024;
      public const int GL_INVALID_FRAMEBUFFER_OPERATION = 1286;
      public const int GL_VERTEX_PROGRAM_POINT_SIZE = 34370;
      public const int GL_COVERAGE_BUFFER_BIT_NV = 32768;
      public const int GL_TEXTURE_MAX_ANISOTROPY_EXT = 34046;
      public const int GL_MAX_TEXTURE_MAX_ANISOTROPY_EXT = 34047;
    }
  }
}
