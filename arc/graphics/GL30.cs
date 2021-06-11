// Decompiled with JetBrains decompiler
// Type: arc.graphics.GL30
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.nio;

namespace arc.graphics
{
  [Implements(new string[] {"arc.graphics.GL20"})]
  public interface GL30 : GL20
  {
    const int GL_READ_BUFFER = 3074;
    const int GL_UNPACK_ROW_LENGTH = 3314;
    const int GL_UNPACK_SKIP_ROWS = 3315;
    const int GL_UNPACK_SKIP_PIXELS = 3316;
    const int GL_PACK_ROW_LENGTH = 3330;
    const int GL_PACK_SKIP_ROWS = 3331;
    const int GL_PACK_SKIP_PIXELS = 3332;
    const int GL_COLOR = 6144;
    const int GL_DEPTH = 6145;
    const int GL_STENCIL = 6146;
    const int GL_RED = 6403;
    const int GL_RGB8 = 32849;
    const int GL_RGBA8 = 32856;
    const int GL_RGB10_A2 = 32857;
    const int GL_TEXTURE_BINDING_3D = 32874;
    const int GL_UNPACK_SKIP_IMAGES = 32877;
    const int GL_UNPACK_IMAGE_HEIGHT = 32878;
    const int GL_TEXTURE_3D = 32879;
    const int GL_TEXTURE_WRAP_R = 32882;
    const int GL_MAX_3D_TEXTURE_SIZE = 32883;
    const int GL_UNSIGNED_INT_2_10_10_10_REV = 33640;
    const int GL_MAX_ELEMENTS_VERTICES = 33000;
    const int GL_MAX_ELEMENTS_INDICES = 33001;
    const int GL_TEXTURE_MIN_LOD = 33082;
    const int GL_TEXTURE_MAX_LOD = 33083;
    const int GL_TEXTURE_BASE_LEVEL = 33084;
    const int GL_TEXTURE_MAX_LEVEL = 33085;
    const int GL_MIN = 32775;
    const int GL_MAX = 32776;
    const int GL_DEPTH_COMPONENT24 = 33190;
    const int GL_MAX_TEXTURE_LOD_BIAS = 34045;
    const int GL_TEXTURE_COMPARE_MODE = 34892;
    const int GL_TEXTURE_COMPARE_FUNC = 34893;
    const int GL_CURRENT_QUERY = 34917;
    const int GL_QUERY_RESULT = 34918;
    const int GL_QUERY_RESULT_AVAILABLE = 34919;
    const int GL_BUFFER_MAPPED = 35004;
    const int GL_BUFFER_MAP_POINTER = 35005;
    const int GL_STREAM_READ = 35041;
    const int GL_STREAM_COPY = 35042;
    const int GL_STATIC_READ = 35045;
    const int GL_STATIC_COPY = 35046;
    const int GL_DYNAMIC_READ = 35049;
    const int GL_DYNAMIC_COPY = 35050;
    const int GL_MAX_DRAW_BUFFERS = 34852;
    const int GL_DRAW_BUFFER0 = 34853;
    const int GL_DRAW_BUFFER1 = 34854;
    const int GL_DRAW_BUFFER2 = 34855;
    const int GL_DRAW_BUFFER3 = 34856;
    const int GL_DRAW_BUFFER4 = 34857;
    const int GL_DRAW_BUFFER5 = 34858;
    const int GL_DRAW_BUFFER6 = 34859;
    const int GL_DRAW_BUFFER7 = 34860;
    const int GL_DRAW_BUFFER8 = 34861;
    const int GL_DRAW_BUFFER9 = 34862;
    const int GL_DRAW_BUFFER10 = 34863;
    const int GL_DRAW_BUFFER11 = 34864;
    const int GL_DRAW_BUFFER12 = 34865;
    const int GL_DRAW_BUFFER13 = 34866;
    const int GL_DRAW_BUFFER14 = 34867;
    const int GL_DRAW_BUFFER15 = 34868;
    const int GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 35657;
    const int GL_MAX_VERTEX_UNIFORM_COMPONENTS = 35658;
    const int GL_SAMPLER_3D = 35679;
    const int GL_SAMPLER_2D_SHADOW = 35682;
    const int GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 35723;
    const int GL_PIXEL_PACK_BUFFER = 35051;
    const int GL_PIXEL_UNPACK_BUFFER = 35052;
    const int GL_PIXEL_PACK_BUFFER_BINDING = 35053;
    const int GL_PIXEL_UNPACK_BUFFER_BINDING = 35055;
    const int GL_FLOAT_MAT2x3 = 35685;
    const int GL_FLOAT_MAT2x4 = 35686;
    const int GL_FLOAT_MAT3x2 = 35687;
    const int GL_FLOAT_MAT3x4 = 35688;
    const int GL_FLOAT_MAT4x2 = 35689;
    const int GL_FLOAT_MAT4x3 = 35690;
    const int GL_SRGB = 35904;
    const int GL_SRGB8 = 35905;
    const int GL_SRGB8_ALPHA8 = 35907;
    const int GL_COMPARE_REF_TO_TEXTURE = 34894;
    const int GL_MAJOR_VERSION = 33307;
    const int GL_MINOR_VERSION = 33308;
    const int GL_NUM_EXTENSIONS = 33309;
    const int GL_RGBA32F = 34836;
    const int GL_RGB32F = 34837;
    const int GL_RGBA16F = 34842;
    const int GL_RGB16F = 34843;
    const int GL_VERTEX_ATTRIB_ARRAY_INTEGER = 35069;
    const int GL_MAX_ARRAY_TEXTURE_LAYERS = 35071;
    const int GL_MIN_PROGRAM_TEXEL_OFFSET = 35076;
    const int GL_MAX_PROGRAM_TEXEL_OFFSET = 35077;
    const int GL_MAX_VARYING_COMPONENTS = 35659;
    const int GL_TEXTURE_2D_ARRAY = 35866;
    const int GL_TEXTURE_BINDING_2D_ARRAY = 35869;
    const int GL_R11F_G11F_B10F = 35898;
    const int GL_UNSIGNED_INT_10F_11F_11F_REV = 35899;
    const int GL_RGB9_E5 = 35901;
    const int GL_UNSIGNED_INT_5_9_9_9_REV = 35902;
    const int GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 35958;
    const int GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 35967;
    const int GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 35968;
    const int GL_TRANSFORM_FEEDBACK_VARYINGS = 35971;
    const int GL_TRANSFORM_FEEDBACK_BUFFER_START = 35972;
    const int GL_TRANSFORM_FEEDBACK_BUFFER_SIZE = 35973;
    const int GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 35976;
    const int GL_RASTERIZER_DISCARD = 35977;
    const int GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 35978;
    const int GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 35979;
    const int GL_INTERLEAVED_ATTRIBS = 35980;
    const int GL_SEPARATE_ATTRIBS = 35981;
    const int GL_TRANSFORM_FEEDBACK_BUFFER = 35982;
    const int GL_TRANSFORM_FEEDBACK_BUFFER_BINDING = 35983;
    const int GL_RGBA32UI = 36208;
    const int GL_RGB32UI = 36209;
    const int GL_RGBA16UI = 36214;
    const int GL_RGB16UI = 36215;
    const int GL_RGBA8UI = 36220;
    const int GL_RGB8UI = 36221;
    const int GL_RGBA32I = 36226;
    const int GL_RGB32I = 36227;
    const int GL_RGBA16I = 36232;
    const int GL_RGB16I = 36233;
    const int GL_RGBA8I = 36238;
    const int GL_RGB8I = 36239;
    const int GL_RED_INTEGER = 36244;
    const int GL_RGB_INTEGER = 36248;
    const int GL_RGBA_INTEGER = 36249;
    const int GL_SAMPLER_2D_ARRAY = 36289;
    const int GL_SAMPLER_2D_ARRAY_SHADOW = 36292;
    const int GL_SAMPLER_CUBE_SHADOW = 36293;
    const int GL_UNSIGNED_INT_VEC2 = 36294;
    const int GL_UNSIGNED_INT_VEC3 = 36295;
    const int GL_UNSIGNED_INT_VEC4 = 36296;
    const int GL_INT_SAMPLER_2D = 36298;
    const int GL_INT_SAMPLER_3D = 36299;
    const int GL_INT_SAMPLER_CUBE = 36300;
    const int GL_INT_SAMPLER_2D_ARRAY = 36303;
    const int GL_UNSIGNED_INT_SAMPLER_2D = 36306;
    const int GL_UNSIGNED_INT_SAMPLER_3D = 36307;
    const int GL_UNSIGNED_INT_SAMPLER_CUBE = 36308;
    const int GL_UNSIGNED_INT_SAMPLER_2D_ARRAY = 36311;
    const int GL_BUFFER_ACCESS_FLAGS = 37151;
    const int GL_BUFFER_MAP_LENGTH = 37152;
    const int GL_BUFFER_MAP_OFFSET = 37153;
    const int GL_DEPTH_COMPONENT32F = 36012;
    const int GL_DEPTH32F_STENCIL8 = 36013;
    const int GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 36269;
    const int GL_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 33296;
    const int GL_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 33297;
    const int GL_FRAMEBUFFER_ATTACHMENT_RED_SIZE = 33298;
    const int GL_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 33299;
    const int GL_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 33300;
    const int GL_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 33301;
    const int GL_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 33302;
    const int GL_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 33303;
    const int GL_FRAMEBUFFER_DEFAULT = 33304;
    const int GL_FRAMEBUFFER_UNDEFINED = 33305;
    const int GL_DEPTH_STENCIL_ATTACHMENT = 33306;
    const int GL_DEPTH_STENCIL = 34041;
    const int GL_UNSIGNED_INT_24_8 = 34042;
    const int GL_DEPTH24_STENCIL8 = 35056;
    const int GL_UNSIGNED_NORMALIZED = 35863;
    const int GL_DRAW_FRAMEBUFFER_BINDING = 36006;
    const int GL_READ_FRAMEBUFFER = 36008;
    const int GL_DRAW_FRAMEBUFFER = 36009;
    const int GL_READ_FRAMEBUFFER_BINDING = 36010;
    const int GL_RENDERBUFFER_SAMPLES = 36011;
    const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 36052;
    const int GL_MAX_COLOR_ATTACHMENTS = 36063;
    const int GL_COLOR_ATTACHMENT1 = 36065;
    const int GL_COLOR_ATTACHMENT2 = 36066;
    const int GL_COLOR_ATTACHMENT3 = 36067;
    const int GL_COLOR_ATTACHMENT4 = 36068;
    const int GL_COLOR_ATTACHMENT5 = 36069;
    const int GL_COLOR_ATTACHMENT6 = 36070;
    const int GL_COLOR_ATTACHMENT7 = 36071;
    const int GL_COLOR_ATTACHMENT8 = 36072;
    const int GL_COLOR_ATTACHMENT9 = 36073;
    const int GL_COLOR_ATTACHMENT10 = 36074;
    const int GL_COLOR_ATTACHMENT11 = 36075;
    const int GL_COLOR_ATTACHMENT12 = 36076;
    const int GL_COLOR_ATTACHMENT13 = 36077;
    const int GL_COLOR_ATTACHMENT14 = 36078;
    const int GL_COLOR_ATTACHMENT15 = 36079;
    const int GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 36182;
    const int GL_MAX_SAMPLES = 36183;
    const int GL_HALF_FLOAT = 5131;
    const int GL_MAP_READ_BIT = 1;
    const int GL_MAP_WRITE_BIT = 2;
    const int GL_MAP_INVALIDATE_RANGE_BIT = 4;
    const int GL_MAP_INVALIDATE_BUFFER_BIT = 8;
    const int GL_MAP_FLUSH_EXPLICIT_BIT = 16;
    const int GL_MAP_UNSYNCHRONIZED_BIT = 32;
    const int GL_RG = 33319;
    const int GL_RG_INTEGER = 33320;
    const int GL_R8 = 33321;
    const int GL_RG8 = 33323;
    const int GL_R16F = 33325;
    const int GL_R32F = 33326;
    const int GL_RG16F = 33327;
    const int GL_RG32F = 33328;
    const int GL_R8I = 33329;
    const int GL_R8UI = 33330;
    const int GL_R16I = 33331;
    const int GL_R16UI = 33332;
    const int GL_R32I = 33333;
    const int GL_R32UI = 33334;
    const int GL_RG8I = 33335;
    const int GL_RG8UI = 33336;
    const int GL_RG16I = 33337;
    const int GL_RG16UI = 33338;
    const int GL_RG32I = 33339;
    const int GL_RG32UI = 33340;
    const int GL_VERTEX_ARRAY_BINDING = 34229;
    const int GL_R8_SNORM = 36756;
    const int GL_RG8_SNORM = 36757;
    const int GL_RGB8_SNORM = 36758;
    const int GL_RGBA8_SNORM = 36759;
    const int GL_SIGNED_NORMALIZED = 36764;
    const int GL_PRIMITIVE_RESTART_FIXED_INDEX = 36201;
    const int GL_COPY_READ_BUFFER = 36662;
    const int GL_COPY_WRITE_BUFFER = 36663;
    const int GL_COPY_READ_BUFFER_BINDING = 36662;
    const int GL_COPY_WRITE_BUFFER_BINDING = 36663;
    const int GL_UNIFORM_BUFFER = 35345;
    const int GL_UNIFORM_BUFFER_BINDING = 35368;
    const int GL_UNIFORM_BUFFER_START = 35369;
    const int GL_UNIFORM_BUFFER_SIZE = 35370;
    const int GL_MAX_VERTEX_UNIFORM_BLOCKS = 35371;
    const int GL_MAX_FRAGMENT_UNIFORM_BLOCKS = 35373;
    const int GL_MAX_COMBINED_UNIFORM_BLOCKS = 35374;
    const int GL_MAX_UNIFORM_BUFFER_BINDINGS = 35375;
    const int GL_MAX_UNIFORM_BLOCK_SIZE = 35376;
    const int GL_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 35377;
    const int GL_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 35379;
    const int GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 35380;
    const int GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 35381;
    const int GL_ACTIVE_UNIFORM_BLOCKS = 35382;
    const int GL_UNIFORM_TYPE = 35383;
    const int GL_UNIFORM_SIZE = 35384;
    const int GL_UNIFORM_NAME_LENGTH = 35385;
    const int GL_UNIFORM_BLOCK_INDEX = 35386;
    const int GL_UNIFORM_OFFSET = 35387;
    const int GL_UNIFORM_ARRAY_STRIDE = 35388;
    const int GL_UNIFORM_MATRIX_STRIDE = 35389;
    const int GL_UNIFORM_IS_ROW_MAJOR = 35390;
    const int GL_UNIFORM_BLOCK_BINDING = 35391;
    const int GL_UNIFORM_BLOCK_DATA_SIZE = 35392;
    const int GL_UNIFORM_BLOCK_NAME_LENGTH = 35393;
    const int GL_UNIFORM_BLOCK_ACTIVE_UNIFORMS = 35394;
    const int GL_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 35395;
    const int GL_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 35396;
    const int GL_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 35398;
    const int GL_INVALID_INDEX = -1;
    const int GL_MAX_VERTEX_OUTPUT_COMPONENTS = 37154;
    const int GL_MAX_FRAGMENT_INPUT_COMPONENTS = 37157;
    const int GL_MAX_SERVER_WAIT_TIMEOUT = 37137;
    const int GL_OBJECT_TYPE = 37138;
    const int GL_SYNC_CONDITION = 37139;
    const int GL_SYNC_STATUS = 37140;
    const int GL_SYNC_FLAGS = 37141;
    const int GL_SYNC_FENCE = 37142;
    const int GL_SYNC_GPU_COMMANDS_COMPLETE = 37143;
    const int GL_UNSIGNALED = 37144;
    const int GL_SIGNALED = 37145;
    const int GL_ALREADY_SIGNALED = 37146;
    const int GL_TIMEOUT_EXPIRED = 37147;
    const int GL_CONDITION_SATISFIED = 37148;
    const int GL_WAIT_FAILED = 37149;
    const int GL_SYNC_FLUSH_COMMANDS_BIT = 1;
    const long GL_TIMEOUT_IGNORED = -1;
    const int GL_VERTEX_ATTRIB_ARRAY_DIVISOR = 35070;
    const int GL_ANY_SAMPLES_PASSED = 35887;
    const int GL_ANY_SAMPLES_PASSED_CONSERVATIVE = 36202;
    const int GL_SAMPLER_BINDING = 35097;
    const int GL_RGB10_A2UI = 36975;
    const int GL_TEXTURE_SWIZZLE_R = 36418;
    const int GL_TEXTURE_SWIZZLE_G = 36419;
    const int GL_TEXTURE_SWIZZLE_B = 36420;
    const int GL_TEXTURE_SWIZZLE_A = 36421;
    const int GL_GREEN = 6404;
    const int GL_BLUE = 6405;
    const int GL_INT_2_10_10_10_REV = 36255;
    const int GL_TRANSFORM_FEEDBACK = 36386;
    const int GL_TRANSFORM_FEEDBACK_PAUSED = 36387;
    const int GL_TRANSFORM_FEEDBACK_ACTIVE = 36388;
    const int GL_TRANSFORM_FEEDBACK_BINDING = 36389;
    const int GL_PROGRAM_BINARY_RETRIEVABLE_HINT = 33367;
    const int GL_PROGRAM_BINARY_LENGTH = 34625;
    const int GL_NUM_PROGRAM_BINARY_FORMATS = 34814;
    const int GL_PROGRAM_BINARY_FORMATS = 34815;
    const int GL_COMPRESSED_R11_EAC = 37488;
    const int GL_COMPRESSED_SIGNED_R11_EAC = 37489;
    const int GL_COMPRESSED_RG11_EAC = 37490;
    const int GL_COMPRESSED_SIGNED_RG11_EAC = 37491;
    const int GL_COMPRESSED_RGB8_ETC2 = 37492;
    const int GL_COMPRESSED_SRGB8_ETC2 = 37493;
    const int GL_COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 37494;
    const int GL_COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 37495;
    const int GL_COMPRESSED_RGBA8_ETC2_EAC = 37496;
    const int GL_COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 37497;
    const int GL_TEXTURE_IMMUTABLE_FORMAT = 37167;
    const int GL_MAX_ELEMENT_INDEX = 36203;
    const int GL_NUM_SAMPLE_COUNTS = 37760;
    const int GL_TEXTURE_IMMUTABLE_LEVELS = 33503;

    void glReadBuffer(int i);

    void glDrawRangeElements(int i1, int i2, int i3, int i4, int i5, Buffer b);

    void glDrawRangeElements(int i1, int i2, int i3, int i4, int i5, int i6);

    void glTexImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      Buffer b);

    void glTexImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      int i10);

    void glTexSubImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      int i10,
      Buffer b);

    void glTexSubImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      int i10,
      int i11);

    void glCopyTexSubImage3D(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9);

    void glGenQueries(int i, IntBuffer ib);

    void glDeleteQueries(int i, IntBuffer ib);

    bool glIsQuery(int i);

    void glBeginQuery(int i1, int i2);

    void glEndQuery(int i);

    void glGetQueryiv(int i1, int i2, IntBuffer ib);

    void glGetQueryObjectuiv(int i1, int i2, IntBuffer ib);

    bool glUnmapBuffer(int i);

    Buffer glGetBufferPointerv(int i1, int i2);

    void glDrawBuffers(int i, IntBuffer ib);

    void glUniformMatrix2x3fv(int i1, int i2, bool b, FloatBuffer fb);

    void glUniformMatrix3x2fv(int i1, int i2, bool b, FloatBuffer fb);

    void glUniformMatrix2x4fv(int i1, int i2, bool b, FloatBuffer fb);

    void glUniformMatrix4x2fv(int i1, int i2, bool b, FloatBuffer fb);

    void glUniformMatrix3x4fv(int i1, int i2, bool b, FloatBuffer fb);

    void glUniformMatrix4x3fv(int i1, int i2, bool b, FloatBuffer fb);

    void glBlitFramebuffer(
      int i1,
      int i2,
      int i3,
      int i4,
      int i5,
      int i6,
      int i7,
      int i8,
      int i9,
      int i10);

    void glRenderbufferStorageMultisample(int i1, int i2, int i3, int i4, int i5);

    void glFramebufferTextureLayer(int i1, int i2, int i3, int i4, int i5);

    void glFlushMappedBufferRange(int i1, int i2, int i3);

    void glBindVertexArray(int i);

    void glDeleteVertexArrays(int i, IntBuffer ib);

    void glGenVertexArrays(int i, IntBuffer ib);

    bool glIsVertexArray(int i);

    void glBeginTransformFeedback(int i);

    void glEndTransformFeedback();

    void glBindBufferRange(int i1, int i2, int i3, int i4, int i5);

    void glBindBufferBase(int i1, int i2, int i3);

    void glTransformFeedbackVaryings(int i1, string[] strarr, int i2);

    void glVertexAttribIPointer(int i1, int i2, int i3, int i4, int i5);

    void glGetVertexAttribIiv(int i1, int i2, IntBuffer ib);

    void glGetVertexAttribIuiv(int i1, int i2, IntBuffer ib);

    void glVertexAttribI4i(int i1, int i2, int i3, int i4, int i5);

    void glVertexAttribI4ui(int i1, int i2, int i3, int i4, int i5);

    void glGetUniformuiv(int i1, int i2, IntBuffer ib);

    int glGetFragDataLocation(int i, string str);

    void glUniform1uiv(int i1, int i2, IntBuffer ib);

    void glUniform3uiv(int i1, int i2, IntBuffer ib);

    void glUniform4uiv(int i1, int i2, IntBuffer ib);

    void glClearBufferiv(int i1, int i2, IntBuffer ib);

    void glClearBufferuiv(int i1, int i2, IntBuffer ib);

    void glClearBufferfv(int i1, int i2, FloatBuffer fb);

    void glClearBufferfi(int i1, int i2, float f, int i3);

    string glGetStringi(int i1, int i2);

    void glCopyBufferSubData(int i1, int i2, int i3, int i4, int i5);

    void glGetUniformIndices(int i, string[] strarr, IntBuffer ib);

    void glGetActiveUniformsiv(int i1, int i2, IntBuffer ib1, int i3, IntBuffer ib2);

    int glGetUniformBlockIndex(int i, string str);

    void glGetActiveUniformBlockiv(int i1, int i2, int i3, IntBuffer ib);

    void glGetActiveUniformBlockName(int i1, int i2, Buffer b1, Buffer b2);

    void glUniformBlockBinding(int i1, int i2, int i3);

    void glDrawArraysInstanced(int i1, int i2, int i3, int i4);

    void glDrawElementsInstanced(int i1, int i2, int i3, int i4, int i5);

    void glGetInteger64v(int i, LongBuffer lb);

    void glGetBufferParameteri64v(int i1, int i2, LongBuffer lb);

    void glGenSamplers(int i, IntBuffer ib);

    void glDeleteSamplers(int i, IntBuffer ib);

    bool glIsSampler(int i);

    void glBindSampler(int i1, int i2);

    void glSamplerParameteri(int i1, int i2, int i3);

    void glSamplerParameteriv(int i1, int i2, IntBuffer ib);

    void glSamplerParameterf(int i1, int i2, float f);

    void glSamplerParameterfv(int i1, int i2, FloatBuffer fb);

    void glGetSamplerParameteriv(int i1, int i2, IntBuffer ib);

    void glGetSamplerParameterfv(int i1, int i2, FloatBuffer fb);

    void glVertexAttribDivisor(int i1, int i2);

    void glBindTransformFeedback(int i1, int i2);

    void glDeleteTransformFeedbacks(int i, IntBuffer ib);

    void glGenTransformFeedbacks(int i, IntBuffer ib);

    bool glIsTransformFeedback(int i);

    void glPauseTransformFeedback();

    void glResumeTransformFeedback();

    void glProgramParameteri(int i1, int i2, int i3);

    void glInvalidateFramebuffer(int i1, int i2, IntBuffer ib);

    void glInvalidateSubFramebuffer(
      int i1,
      int i2,
      IntBuffer ib,
      int i3,
      int i4,
      int i5,
      int i6);

    [HideFromJava]
    new static class __Fields
    {
      public const int GL_READ_BUFFER = 3074;
      public const int GL_UNPACK_ROW_LENGTH = 3314;
      public const int GL_UNPACK_SKIP_ROWS = 3315;
      public const int GL_UNPACK_SKIP_PIXELS = 3316;
      public const int GL_PACK_ROW_LENGTH = 3330;
      public const int GL_PACK_SKIP_ROWS = 3331;
      public const int GL_PACK_SKIP_PIXELS = 3332;
      public const int GL_COLOR = 6144;
      public const int GL_DEPTH = 6145;
      public const int GL_STENCIL = 6146;
      public const int GL_RED = 6403;
      public const int GL_RGB8 = 32849;
      public const int GL_RGBA8 = 32856;
      public const int GL_RGB10_A2 = 32857;
      public const int GL_TEXTURE_BINDING_3D = 32874;
      public const int GL_UNPACK_SKIP_IMAGES = 32877;
      public const int GL_UNPACK_IMAGE_HEIGHT = 32878;
      public const int GL_TEXTURE_3D = 32879;
      public const int GL_TEXTURE_WRAP_R = 32882;
      public const int GL_MAX_3D_TEXTURE_SIZE = 32883;
      public const int GL_UNSIGNED_INT_2_10_10_10_REV = 33640;
      public const int GL_MAX_ELEMENTS_VERTICES = 33000;
      public const int GL_MAX_ELEMENTS_INDICES = 33001;
      public const int GL_TEXTURE_MIN_LOD = 33082;
      public const int GL_TEXTURE_MAX_LOD = 33083;
      public const int GL_TEXTURE_BASE_LEVEL = 33084;
      public const int GL_TEXTURE_MAX_LEVEL = 33085;
      public const int GL_MIN = 32775;
      public const int GL_MAX = 32776;
      public const int GL_DEPTH_COMPONENT24 = 33190;
      public const int GL_MAX_TEXTURE_LOD_BIAS = 34045;
      public const int GL_TEXTURE_COMPARE_MODE = 34892;
      public const int GL_TEXTURE_COMPARE_FUNC = 34893;
      public const int GL_CURRENT_QUERY = 34917;
      public const int GL_QUERY_RESULT = 34918;
      public const int GL_QUERY_RESULT_AVAILABLE = 34919;
      public const int GL_BUFFER_MAPPED = 35004;
      public const int GL_BUFFER_MAP_POINTER = 35005;
      public const int GL_STREAM_READ = 35041;
      public const int GL_STREAM_COPY = 35042;
      public const int GL_STATIC_READ = 35045;
      public const int GL_STATIC_COPY = 35046;
      public const int GL_DYNAMIC_READ = 35049;
      public const int GL_DYNAMIC_COPY = 35050;
      public const int GL_MAX_DRAW_BUFFERS = 34852;
      public const int GL_DRAW_BUFFER0 = 34853;
      public const int GL_DRAW_BUFFER1 = 34854;
      public const int GL_DRAW_BUFFER2 = 34855;
      public const int GL_DRAW_BUFFER3 = 34856;
      public const int GL_DRAW_BUFFER4 = 34857;
      public const int GL_DRAW_BUFFER5 = 34858;
      public const int GL_DRAW_BUFFER6 = 34859;
      public const int GL_DRAW_BUFFER7 = 34860;
      public const int GL_DRAW_BUFFER8 = 34861;
      public const int GL_DRAW_BUFFER9 = 34862;
      public const int GL_DRAW_BUFFER10 = 34863;
      public const int GL_DRAW_BUFFER11 = 34864;
      public const int GL_DRAW_BUFFER12 = 34865;
      public const int GL_DRAW_BUFFER13 = 34866;
      public const int GL_DRAW_BUFFER14 = 34867;
      public const int GL_DRAW_BUFFER15 = 34868;
      public const int GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 35657;
      public const int GL_MAX_VERTEX_UNIFORM_COMPONENTS = 35658;
      public const int GL_SAMPLER_3D = 35679;
      public const int GL_SAMPLER_2D_SHADOW = 35682;
      public const int GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 35723;
      public const int GL_PIXEL_PACK_BUFFER = 35051;
      public const int GL_PIXEL_UNPACK_BUFFER = 35052;
      public const int GL_PIXEL_PACK_BUFFER_BINDING = 35053;
      public const int GL_PIXEL_UNPACK_BUFFER_BINDING = 35055;
      public const int GL_FLOAT_MAT2x3 = 35685;
      public const int GL_FLOAT_MAT2x4 = 35686;
      public const int GL_FLOAT_MAT3x2 = 35687;
      public const int GL_FLOAT_MAT3x4 = 35688;
      public const int GL_FLOAT_MAT4x2 = 35689;
      public const int GL_FLOAT_MAT4x3 = 35690;
      public const int GL_SRGB = 35904;
      public const int GL_SRGB8 = 35905;
      public const int GL_SRGB8_ALPHA8 = 35907;
      public const int GL_COMPARE_REF_TO_TEXTURE = 34894;
      public const int GL_MAJOR_VERSION = 33307;
      public const int GL_MINOR_VERSION = 33308;
      public const int GL_NUM_EXTENSIONS = 33309;
      public const int GL_RGBA32F = 34836;
      public const int GL_RGB32F = 34837;
      public const int GL_RGBA16F = 34842;
      public const int GL_RGB16F = 34843;
      public const int GL_VERTEX_ATTRIB_ARRAY_INTEGER = 35069;
      public const int GL_MAX_ARRAY_TEXTURE_LAYERS = 35071;
      public const int GL_MIN_PROGRAM_TEXEL_OFFSET = 35076;
      public const int GL_MAX_PROGRAM_TEXEL_OFFSET = 35077;
      public const int GL_MAX_VARYING_COMPONENTS = 35659;
      public const int GL_TEXTURE_2D_ARRAY = 35866;
      public const int GL_TEXTURE_BINDING_2D_ARRAY = 35869;
      public const int GL_R11F_G11F_B10F = 35898;
      public const int GL_UNSIGNED_INT_10F_11F_11F_REV = 35899;
      public const int GL_RGB9_E5 = 35901;
      public const int GL_UNSIGNED_INT_5_9_9_9_REV = 35902;
      public const int GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 35958;
      public const int GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 35967;
      public const int GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = 35968;
      public const int GL_TRANSFORM_FEEDBACK_VARYINGS = 35971;
      public const int GL_TRANSFORM_FEEDBACK_BUFFER_START = 35972;
      public const int GL_TRANSFORM_FEEDBACK_BUFFER_SIZE = 35973;
      public const int GL_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = 35976;
      public const int GL_RASTERIZER_DISCARD = 35977;
      public const int GL_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = 35978;
      public const int GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = 35979;
      public const int GL_INTERLEAVED_ATTRIBS = 35980;
      public const int GL_SEPARATE_ATTRIBS = 35981;
      public const int GL_TRANSFORM_FEEDBACK_BUFFER = 35982;
      public const int GL_TRANSFORM_FEEDBACK_BUFFER_BINDING = 35983;
      public const int GL_RGBA32UI = 36208;
      public const int GL_RGB32UI = 36209;
      public const int GL_RGBA16UI = 36214;
      public const int GL_RGB16UI = 36215;
      public const int GL_RGBA8UI = 36220;
      public const int GL_RGB8UI = 36221;
      public const int GL_RGBA32I = 36226;
      public const int GL_RGB32I = 36227;
      public const int GL_RGBA16I = 36232;
      public const int GL_RGB16I = 36233;
      public const int GL_RGBA8I = 36238;
      public const int GL_RGB8I = 36239;
      public const int GL_RED_INTEGER = 36244;
      public const int GL_RGB_INTEGER = 36248;
      public const int GL_RGBA_INTEGER = 36249;
      public const int GL_SAMPLER_2D_ARRAY = 36289;
      public const int GL_SAMPLER_2D_ARRAY_SHADOW = 36292;
      public const int GL_SAMPLER_CUBE_SHADOW = 36293;
      public const int GL_UNSIGNED_INT_VEC2 = 36294;
      public const int GL_UNSIGNED_INT_VEC3 = 36295;
      public const int GL_UNSIGNED_INT_VEC4 = 36296;
      public const int GL_INT_SAMPLER_2D = 36298;
      public const int GL_INT_SAMPLER_3D = 36299;
      public const int GL_INT_SAMPLER_CUBE = 36300;
      public const int GL_INT_SAMPLER_2D_ARRAY = 36303;
      public const int GL_UNSIGNED_INT_SAMPLER_2D = 36306;
      public const int GL_UNSIGNED_INT_SAMPLER_3D = 36307;
      public const int GL_UNSIGNED_INT_SAMPLER_CUBE = 36308;
      public const int GL_UNSIGNED_INT_SAMPLER_2D_ARRAY = 36311;
      public const int GL_BUFFER_ACCESS_FLAGS = 37151;
      public const int GL_BUFFER_MAP_LENGTH = 37152;
      public const int GL_BUFFER_MAP_OFFSET = 37153;
      public const int GL_DEPTH_COMPONENT32F = 36012;
      public const int GL_DEPTH32F_STENCIL8 = 36013;
      public const int GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 36269;
      public const int GL_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = 33296;
      public const int GL_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = 33297;
      public const int GL_FRAMEBUFFER_ATTACHMENT_RED_SIZE = 33298;
      public const int GL_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = 33299;
      public const int GL_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = 33300;
      public const int GL_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = 33301;
      public const int GL_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = 33302;
      public const int GL_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = 33303;
      public const int GL_FRAMEBUFFER_DEFAULT = 33304;
      public const int GL_FRAMEBUFFER_UNDEFINED = 33305;
      public const int GL_DEPTH_STENCIL_ATTACHMENT = 33306;
      public const int GL_DEPTH_STENCIL = 34041;
      public const int GL_UNSIGNED_INT_24_8 = 34042;
      public const int GL_DEPTH24_STENCIL8 = 35056;
      public const int GL_UNSIGNED_NORMALIZED = 35863;
      public const int GL_DRAW_FRAMEBUFFER_BINDING = 36006;
      public const int GL_READ_FRAMEBUFFER = 36008;
      public const int GL_DRAW_FRAMEBUFFER = 36009;
      public const int GL_READ_FRAMEBUFFER_BINDING = 36010;
      public const int GL_RENDERBUFFER_SAMPLES = 36011;
      public const int GL_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = 36052;
      public const int GL_MAX_COLOR_ATTACHMENTS = 36063;
      public const int GL_COLOR_ATTACHMENT1 = 36065;
      public const int GL_COLOR_ATTACHMENT2 = 36066;
      public const int GL_COLOR_ATTACHMENT3 = 36067;
      public const int GL_COLOR_ATTACHMENT4 = 36068;
      public const int GL_COLOR_ATTACHMENT5 = 36069;
      public const int GL_COLOR_ATTACHMENT6 = 36070;
      public const int GL_COLOR_ATTACHMENT7 = 36071;
      public const int GL_COLOR_ATTACHMENT8 = 36072;
      public const int GL_COLOR_ATTACHMENT9 = 36073;
      public const int GL_COLOR_ATTACHMENT10 = 36074;
      public const int GL_COLOR_ATTACHMENT11 = 36075;
      public const int GL_COLOR_ATTACHMENT12 = 36076;
      public const int GL_COLOR_ATTACHMENT13 = 36077;
      public const int GL_COLOR_ATTACHMENT14 = 36078;
      public const int GL_COLOR_ATTACHMENT15 = 36079;
      public const int GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 36182;
      public const int GL_MAX_SAMPLES = 36183;
      public const int GL_HALF_FLOAT = 5131;
      public const int GL_MAP_READ_BIT = 1;
      public const int GL_MAP_WRITE_BIT = 2;
      public const int GL_MAP_INVALIDATE_RANGE_BIT = 4;
      public const int GL_MAP_INVALIDATE_BUFFER_BIT = 8;
      public const int GL_MAP_FLUSH_EXPLICIT_BIT = 16;
      public const int GL_MAP_UNSYNCHRONIZED_BIT = 32;
      public const int GL_RG = 33319;
      public const int GL_RG_INTEGER = 33320;
      public const int GL_R8 = 33321;
      public const int GL_RG8 = 33323;
      public const int GL_R16F = 33325;
      public const int GL_R32F = 33326;
      public const int GL_RG16F = 33327;
      public const int GL_RG32F = 33328;
      public const int GL_R8I = 33329;
      public const int GL_R8UI = 33330;
      public const int GL_R16I = 33331;
      public const int GL_R16UI = 33332;
      public const int GL_R32I = 33333;
      public const int GL_R32UI = 33334;
      public const int GL_RG8I = 33335;
      public const int GL_RG8UI = 33336;
      public const int GL_RG16I = 33337;
      public const int GL_RG16UI = 33338;
      public const int GL_RG32I = 33339;
      public const int GL_RG32UI = 33340;
      public const int GL_VERTEX_ARRAY_BINDING = 34229;
      public const int GL_R8_SNORM = 36756;
      public const int GL_RG8_SNORM = 36757;
      public const int GL_RGB8_SNORM = 36758;
      public const int GL_RGBA8_SNORM = 36759;
      public const int GL_SIGNED_NORMALIZED = 36764;
      public const int GL_PRIMITIVE_RESTART_FIXED_INDEX = 36201;
      public const int GL_COPY_READ_BUFFER = 36662;
      public const int GL_COPY_WRITE_BUFFER = 36663;
      public const int GL_COPY_READ_BUFFER_BINDING = 36662;
      public const int GL_COPY_WRITE_BUFFER_BINDING = 36663;
      public const int GL_UNIFORM_BUFFER = 35345;
      public const int GL_UNIFORM_BUFFER_BINDING = 35368;
      public const int GL_UNIFORM_BUFFER_START = 35369;
      public const int GL_UNIFORM_BUFFER_SIZE = 35370;
      public const int GL_MAX_VERTEX_UNIFORM_BLOCKS = 35371;
      public const int GL_MAX_FRAGMENT_UNIFORM_BLOCKS = 35373;
      public const int GL_MAX_COMBINED_UNIFORM_BLOCKS = 35374;
      public const int GL_MAX_UNIFORM_BUFFER_BINDINGS = 35375;
      public const int GL_MAX_UNIFORM_BLOCK_SIZE = 35376;
      public const int GL_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 35377;
      public const int GL_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 35379;
      public const int GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 35380;
      public const int GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 35381;
      public const int GL_ACTIVE_UNIFORM_BLOCKS = 35382;
      public const int GL_UNIFORM_TYPE = 35383;
      public const int GL_UNIFORM_SIZE = 35384;
      public const int GL_UNIFORM_NAME_LENGTH = 35385;
      public const int GL_UNIFORM_BLOCK_INDEX = 35386;
      public const int GL_UNIFORM_OFFSET = 35387;
      public const int GL_UNIFORM_ARRAY_STRIDE = 35388;
      public const int GL_UNIFORM_MATRIX_STRIDE = 35389;
      public const int GL_UNIFORM_IS_ROW_MAJOR = 35390;
      public const int GL_UNIFORM_BLOCK_BINDING = 35391;
      public const int GL_UNIFORM_BLOCK_DATA_SIZE = 35392;
      public const int GL_UNIFORM_BLOCK_NAME_LENGTH = 35393;
      public const int GL_UNIFORM_BLOCK_ACTIVE_UNIFORMS = 35394;
      public const int GL_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = 35395;
      public const int GL_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = 35396;
      public const int GL_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = 35398;
      public const int GL_INVALID_INDEX = -1;
      public const int GL_MAX_VERTEX_OUTPUT_COMPONENTS = 37154;
      public const int GL_MAX_FRAGMENT_INPUT_COMPONENTS = 37157;
      public const int GL_MAX_SERVER_WAIT_TIMEOUT = 37137;
      public const int GL_OBJECT_TYPE = 37138;
      public const int GL_SYNC_CONDITION = 37139;
      public const int GL_SYNC_STATUS = 37140;
      public const int GL_SYNC_FLAGS = 37141;
      public const int GL_SYNC_FENCE = 37142;
      public const int GL_SYNC_GPU_COMMANDS_COMPLETE = 37143;
      public const int GL_UNSIGNALED = 37144;
      public const int GL_SIGNALED = 37145;
      public const int GL_ALREADY_SIGNALED = 37146;
      public const int GL_TIMEOUT_EXPIRED = 37147;
      public const int GL_CONDITION_SATISFIED = 37148;
      public const int GL_WAIT_FAILED = 37149;
      public const int GL_SYNC_FLUSH_COMMANDS_BIT = 1;
      public const long GL_TIMEOUT_IGNORED = -1;
      public const int GL_VERTEX_ATTRIB_ARRAY_DIVISOR = 35070;
      public const int GL_ANY_SAMPLES_PASSED = 35887;
      public const int GL_ANY_SAMPLES_PASSED_CONSERVATIVE = 36202;
      public const int GL_SAMPLER_BINDING = 35097;
      public const int GL_RGB10_A2UI = 36975;
      public const int GL_TEXTURE_SWIZZLE_R = 36418;
      public const int GL_TEXTURE_SWIZZLE_G = 36419;
      public const int GL_TEXTURE_SWIZZLE_B = 36420;
      public const int GL_TEXTURE_SWIZZLE_A = 36421;
      public const int GL_GREEN = 6404;
      public const int GL_BLUE = 6405;
      public const int GL_INT_2_10_10_10_REV = 36255;
      public const int GL_TRANSFORM_FEEDBACK = 36386;
      public const int GL_TRANSFORM_FEEDBACK_PAUSED = 36387;
      public const int GL_TRANSFORM_FEEDBACK_ACTIVE = 36388;
      public const int GL_TRANSFORM_FEEDBACK_BINDING = 36389;
      public const int GL_PROGRAM_BINARY_RETRIEVABLE_HINT = 33367;
      public const int GL_PROGRAM_BINARY_LENGTH = 34625;
      public const int GL_NUM_PROGRAM_BINARY_FORMATS = 34814;
      public const int GL_PROGRAM_BINARY_FORMATS = 34815;
      public const int GL_COMPRESSED_R11_EAC = 37488;
      public const int GL_COMPRESSED_SIGNED_R11_EAC = 37489;
      public const int GL_COMPRESSED_RG11_EAC = 37490;
      public const int GL_COMPRESSED_SIGNED_RG11_EAC = 37491;
      public const int GL_COMPRESSED_RGB8_ETC2 = 37492;
      public const int GL_COMPRESSED_SRGB8_ETC2 = 37493;
      public const int GL_COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 37494;
      public const int GL_COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 37495;
      public const int GL_COMPRESSED_RGBA8_ETC2_EAC = 37496;
      public const int GL_COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 37497;
      public const int GL_TEXTURE_IMMUTABLE_FORMAT = 37167;
      public const int GL_MAX_ELEMENT_INDEX = 36203;
      public const int GL_NUM_SAMPLE_COUNTS = 37760;
      public const int GL_TEXTURE_IMMUTABLE_LEVELS = 33503;
    }
  }
}
