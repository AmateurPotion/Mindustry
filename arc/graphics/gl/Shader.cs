// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.Shader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.gl
{
  public class Shader : Object, Disposable
  {
    public const string positionAttribute = "a_position";
    public const string normalAttribute = "a_normal";
    public const string colorAttribute = "a_color";
    public const string mixColorAttribute = "a_mix_color";
    public const string texcoordAttribute = "a_texCoord";
    public const string tangentAttribute = "a_tangent";
    public const string binormalAttribute = "a_binormal";
    public const string boneweightAttribute = "a_boneWeight";
    public static bool pedantic;
    public static string prependVertexCode;
    public static string prependFragmentCode;
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private ObjectIntMap uniforms;
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private ObjectIntMap uniformTypes;
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private ObjectIntMap uniformSizes;
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private ObjectIntMap attributes;
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private ObjectIntMap attributeTypes;
    [Modifiers]
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private ObjectIntMap attributeSizes;
    [Modifiers]
    private string vertexShaderSource;
    [Modifiers]
    private string fragmentShaderSource;
    internal IntBuffer @params;
    internal IntBuffer type;
    private string log;
    private bool isCompiled;
    private string[] uniformNames;
    private string[] attributeNames;
    private int program;
    private int vertexShaderHandle;
    private int fragmentShaderHandle;
    private bool disposed;
    [Modifiers]
    private static float[] val;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {80, 148, 109, 159, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Shader(Fi vertexShader, Fi fragmentShader)
      : this(vertexShader.readString(), fragmentShader.readString())
    {
      Shader shader = this;
      if (String.instancehelper_isEmpty(this.log))
        return;
      Log.warn(new StringBuilder().append("Shader ").append((object) vertexShader).append(" | ").append((object) fragmentShader).append(":\n").append(this.log).toString());
    }

    [LineNumberTable(new byte[] {162, 3, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void bind() => Gl.useProgram(this.program);

    [LineNumberTable(new byte[] {160, 207, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformi(string name, int value) => Gl.uniform1i(this.fetchUniformLocation(name), value);

    [LineNumberTable(new byte[] {161, 133, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix4(string name, float[] val) => Gl.uniformMatrix4fv(this.fetchUniformLocation(name), 1, false, val, 0);

    [LineNumberTable(new byte[] {57, 232, 26, 139, 139, 139, 139, 139, 235, 69, 108, 140, 235, 85, 115, 147, 106, 138, 127, 17, 159, 17, 103, 135, 104, 104, 102, 136, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Shader(string vertexShader, string fragmentShader)
    {
      Shader shader = this;
      this.uniforms = new ObjectIntMap();
      this.uniformTypes = new ObjectIntMap();
      this.uniformSizes = new ObjectIntMap();
      this.attributes = new ObjectIntMap();
      this.attributeTypes = new ObjectIntMap();
      this.attributeSizes = new ObjectIntMap();
      this.@params = Buffers.newIntBuffer(1);
      this.type = Buffers.newIntBuffer(1);
      this.log = "";
      if (vertexShader == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("vertex shader must not be null");
      }
      if (fragmentShader == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("fragment shader must not be null");
      }
      vertexShader = this.preprocess(vertexShader, false);
      fragmentShader = this.preprocess(fragmentShader, true);
      if (Shader.prependVertexCode != null && String.instancehelper_length(Shader.prependVertexCode) > 0)
        vertexShader = new StringBuilder().append(Shader.prependVertexCode).append(vertexShader).toString();
      if (Shader.prependFragmentCode != null && String.instancehelper_length(Shader.prependFragmentCode) > 0)
        fragmentShader = new StringBuilder().append(Shader.prependFragmentCode).append(fragmentShader).toString();
      this.vertexShaderSource = vertexShader;
      this.fragmentShaderSource = fragmentShader;
      this.compileShaders(vertexShader, fragmentShader);
      if (this.isCompiled())
      {
        this.fetchAttributes();
        this.fetchUniforms();
      }
      else
      {
        string str = new StringBuilder().append("Failed to compile shader: ").append(this.log).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
    }

    [LineNumberTable(new byte[] {161, 137, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix4(string name, Mat mat) => Gl.uniformMatrix4fv(this.fetchUniformLocation(name), 1, false, Shader.copyTransform(mat), 0);

    [LineNumberTable(new byte[] {162, 9, 137, 102, 107, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (this.disposed)
        return;
      Gl.useProgram(0);
      Gl.deleteShader(this.vertexShaderHandle);
      Gl.deleteShader(this.fragmentShaderHandle);
      Gl.deleteProgram(this.program);
      this.disposed = true;
    }

    [LineNumberTable(new byte[] {159, 107, 162, 125, 223, 16, 125, 223, 16, 99, 143, 255, 40, 73, 252, 74, 234, 70, 127, 5, 127, 14, 134, 159, 0, 154, 127, 32, 127, 35, 127, 22, 127, 20, 255, 22, 56, 225, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual string preprocess(string source, bool fragment)
    {
      int num = fragment ? 1 : 0;
      string str1 = source;
      object obj1 = (object) "#ifdef GL_ES";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      if (String.instancehelper_contains(str1, charSequence2))
      {
        string message = new StringBuilder().append("Shader contains GL_ES specific code; this should be handled by the preprocessor. Code: \n```\n").append(source).append("\n```").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      string str2 = source;
      object obj2 = (object) "#version";
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence3 = charSequence1;
      if (String.instancehelper_contains(str2, charSequence3))
      {
        string message = new StringBuilder().append("Shader contains explicit version requirement; this should be handled by the preprocessor. Code: \n```\n").append(source).append("\n```").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (num != 0)
      {
        StringBuilder stringBuilder = new StringBuilder().append("#ifdef GL_ES\nprecision ");
        string str3 = source;
        object obj3 = (object) "#define HIGHP";
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence4 = charSequence1;
        string str4 = !String.instancehelper_contains(str3, charSequence4) ? "mediump" : "highp";
        source = stringBuilder.append(str4).append(" float;\nprecision mediump int;\n#else\n#define lowp  \n#define mediump \n#define highp \n#endif\n").append(source).toString();
      }
      else
        source = new StringBuilder().append("#ifndef GL_ES\n#define lowp  \n#define mediump \n#define highp \n#endif\n").append(source).toString();
      if (Core.gl30 == null)
        return source;
      string str5 = source;
      object obj4 = (object) "#version ";
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      CharSequence charSequence5 = charSequence1;
      string str6 = !String.instancehelper_contains(str5, charSequence5) ? (!Core.app.isDesktop() ? "300 es" : (!Core.graphics.getGLVersion().atLeast(3, 2) ? "130" : "150")) : "";
      StringBuilder stringBuilder1 = new StringBuilder().append("#version ").append(str6).append("\n").append(num == 0 ? "" : "out lowp vec4 fragColor;\n");
      string str7 = source;
      object obj5 = num == 0 ? (object) "out" : (object) "in";
      object obj6 = (object) "varying";
      charSequence1.__\u003Cref\u003E = (__Null) obj6;
      CharSequence charSequence6 = charSequence1;
      object obj7 = obj5;
      charSequence1.__\u003Cref\u003E = (__Null) obj7;
      CharSequence charSequence7 = charSequence1;
      string str8 = String.instancehelper_replace(str7, charSequence6, charSequence7);
      object obj8 = num == 0 ? (object) "in" : (object) "???";
      object obj9 = (object) "attribute";
      charSequence1.__\u003Cref\u003E = (__Null) obj9;
      CharSequence charSequence8 = charSequence1;
      object obj10 = obj8;
      charSequence1.__\u003Cref\u003E = (__Null) obj10;
      CharSequence charSequence9 = charSequence1;
      string str9 = String.instancehelper_replace(str8, charSequence8, charSequence9);
      object obj11 = (object) "texture(";
      object obj12 = (object) "texture2D(";
      charSequence1.__\u003Cref\u003E = (__Null) obj12;
      CharSequence charSequence10 = charSequence1;
      object obj13 = obj11;
      charSequence1.__\u003Cref\u003E = (__Null) obj13;
      CharSequence charSequence11 = charSequence1;
      string str10 = String.instancehelper_replace(str9, charSequence10, charSequence11);
      object obj14 = (object) "texture(";
      object obj15 = (object) "textureCube(";
      charSequence1.__\u003Cref\u003E = (__Null) obj15;
      CharSequence charSequence12 = charSequence1;
      object obj16 = obj14;
      charSequence1.__\u003Cref\u003E = (__Null) obj16;
      CharSequence charSequence13 = charSequence1;
      string str11 = String.instancehelper_replace(str10, charSequence12, charSequence13);
      object obj17 = (object) "fragColor";
      object obj18 = (object) "gl_FragColor";
      charSequence1.__\u003Cref\u003E = (__Null) obj18;
      CharSequence charSequence14 = charSequence1;
      object obj19 = obj17;
      charSequence1.__\u003Cref\u003E = (__Null) obj19;
      CharSequence charSequence15 = charSequence1;
      string str12 = String.instancehelper_replace(str11, charSequence14, charSequence15);
      return stringBuilder1.append(str12).toString();
    }

    [LineNumberTable(new byte[] {160, 88, 114, 146, 114, 103, 161, 114, 105, 103, 161, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void compileShaders([In] string obj0, [In] string obj1)
    {
      this.vertexShaderHandle = this.loadShader(35633, obj0);
      this.fragmentShaderHandle = this.loadShader(35632, obj1);
      if (this.vertexShaderHandle == -1 || this.fragmentShaderHandle == -1)
      {
        this.isCompiled = false;
      }
      else
      {
        this.program = this.linkProgram(this.createProgram());
        if (this.program == -1)
          this.isCompiled = false;
        else
          this.isCompiled = true;
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCompiled() => this.isCompiled;

    [LineNumberTable(new byte[] {162, 85, 108, 118, 141, 140, 105, 108, 110, 108, 121, 109, 109, 120, 120, 233, 55, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void fetchAttributes()
    {
      ((Buffer) this.@params).clear();
      Gl.getProgramiv(this.program, 35721, this.@params);
      int length = this.@params.get(0);
      this.attributeNames = new string[length];
      for (int index = 0; index < length; ++index)
      {
        ((Buffer) this.@params).clear();
        this.@params.put(0, 1);
        ((Buffer) this.type).clear();
        string activeAttrib = Gl.getActiveAttrib(this.program, index, this.@params, this.type);
        int attribLocation = Gl.getAttribLocation(this.program, activeAttrib);
        this.attributes.put((object) activeAttrib, attribLocation);
        this.attributeTypes.put((object) activeAttrib, this.type.get(0));
        this.attributeSizes.put((object) activeAttrib, this.@params.get(0));
        this.attributeNames[index] = activeAttrib;
      }
    }

    [LineNumberTable(new byte[] {162, 65, 108, 118, 141, 140, 105, 108, 110, 108, 121, 109, 109, 120, 120, 233, 55, 233, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void fetchUniforms()
    {
      ((Buffer) this.@params).clear();
      Gl.getProgramiv(this.program, 35718, this.@params);
      int length = this.@params.get(0);
      this.uniformNames = new string[length];
      for (int index = 0; index < length; ++index)
      {
        ((Buffer) this.@params).clear();
        this.@params.put(0, 1);
        ((Buffer) this.type).clear();
        string activeUniform = Gl.getActiveUniform(this.program, index, this.@params, this.type);
        int uniformLocation = Gl.getUniformLocation(this.program, activeUniform);
        this.uniforms.put((object) activeUniform, uniformLocation);
        this.uniformTypes.put((object) activeUniform, this.type.get(0));
        this.uniformSizes.put((object) activeUniform, this.@params.get(0));
        this.uniformNames[index] = activeUniform;
      }
    }

    [LineNumberTable(new byte[] {160, 106, 135, 103, 133, 103, 102, 140, 103, 104, 127, 25, 191, 6, 105, 100, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int loadShader([In] int obj0, [In] string obj1)
    {
      IntBuffer @params = Buffers.newIntBuffer(1);
      int shader1 = Gl.createShader(obj0);
      if (shader1 == 0)
        return -1;
      Gl.shaderSource(shader1, obj1);
      Gl.compileShader(shader1);
      Gl.getShaderiv(shader1, 35713, @params);
      string shaderInfoLog = Gl.getShaderInfoLog(shader1);
      if (!String.instancehelper_isEmpty(shaderInfoLog))
      {
        StringBuilder stringBuilder1 = new StringBuilder();
        Shader shader2 = this;
        this.log = stringBuilder1.append(this.log).append(obj0 != 35633 ? "Fragment shader:\n" : "Vertex shader\n").toString();
        StringBuilder stringBuilder2 = new StringBuilder();
        Shader shader3 = this;
        this.log = stringBuilder2.append(this.log).append(shaderInfoLog).toString();
      }
      return @params.get(0) == 0 ? -1 : shader1;
    }

    [LineNumberTable(new byte[] {160, 130, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual int createProgram()
    {
      int program = Gl.createProgram();
      return program != 0 ? program : -1;
    }

    [LineNumberTable(new byte[] {160, 135, 134, 108, 108, 134, 103, 108, 135, 108, 104, 99, 108, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int linkProgram([In] int obj0)
    {
      if (obj0 == -1)
        return -1;
      Gl.attachShader(obj0, this.vertexShaderHandle);
      Gl.attachShader(obj0, this.fragmentShaderHandle);
      Gl.linkProgram(obj0);
      ByteBuffer byteBuffer = ByteBuffer.allocateDirect(4);
      byteBuffer.order(ByteOrder.nativeOrder());
      IntBuffer @params = byteBuffer.asIntBuffer();
      Gl.getProgramiv(obj0, 35714, @params);
      if (@params.get(0) != 0)
        return obj0;
      this.log = Gl.getProgramInfoLog(obj0);
      return -1;
    }

    [LineNumberTable(new byte[] {159, 66, 130, 116, 109, 103, 127, 16, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int fetchUniformLocation(string name, bool pedantic)
    {
      int num = pedantic ? 1 : 0;
      int uniformLocation;
      if ((uniformLocation = this.uniforms.get((object) name, -2)) == -2)
      {
        uniformLocation = Gl.getUniformLocation(this.program, name);
        if (uniformLocation == -1 && num != 0)
        {
          string str = new StringBuilder().append("no uniform with name '").append(name).append("' in shader").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        this.uniforms.put((object) name, uniformLocation);
      }
      return uniformLocation;
    }

    [LineNumberTable(299)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int fetchUniformLocation([In] string obj0) => this.fetchUniformLocation(obj0, Shader.pedantic);

    [LineNumberTable(new byte[] {159, 20, 162, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix(string name, Mat matrix, bool transpose)
    {
      int num = transpose ? 1 : 0;
      this.setUniformMatrix(this.fetchUniformLocation(name), matrix, num != 0);
    }

    [LineNumberTable(new byte[] {159, 18, 162, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix(int location, Mat matrix, bool transpose)
    {
      int num = transpose ? 1 : 0;
      Gl.uniformMatrix3fv(location, 1, num != 0, matrix.val, 0);
    }

    [LineNumberTable(new byte[] {162, 193, 111, 143, 111, 111, 112, 112, 112, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float[] copyTransform(Mat matrix)
    {
      Shader.val[4] = matrix.val[3];
      Shader.val[1] = matrix.val[1];
      Shader.val[0] = matrix.val[0];
      Shader.val[5] = matrix.val[4];
      Shader.val[10] = matrix.val[8];
      Shader.val[12] = matrix.val[6];
      Shader.val[13] = matrix.val[7];
      Shader.val[15] = 1f;
      return Shader.val;
    }

    [LineNumberTable(new byte[] {162, 206, 111, 143, 111, 111, 112, 112, 112, 141, 110, 144, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float[] copyTransform(Mat matrix, float near, float far)
    {
      Shader.val[4] = matrix.val[3];
      Shader.val[1] = matrix.val[1];
      Shader.val[0] = matrix.val[0];
      Shader.val[5] = matrix.val[4];
      Shader.val[10] = matrix.val[8];
      Shader.val[12] = matrix.val[6];
      Shader.val[13] = matrix.val[7];
      Shader.val[15] = 1f;
      float num1 = -2f / (far - near);
      float num2 = -(far + near) / (far - near);
      Shader.val[10] = num1;
      Shader.val[14] = num2;
      return Shader.val;
    }

    [LineNumberTable(new byte[] {161, 169, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix4fv(int location, float[] values, int offset, int length) => Gl.uniformMatrix4fv(location, length / 16, false, values, offset);

    [LineNumberTable(new byte[] {161, 28, 104, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(string name, float value1, float value2) => Gl.uniform2f(this.fetchUniformLocation(name), value1, value2);

    [LineNumberTable(new byte[] {161, 33, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(int location, float value1, float value2) => Gl.uniform2f(location, value1, value2);

    [LineNumberTable(new byte[] {161, 44, 104, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(string name, float value1, float value2, float value3) => Gl.uniform3f(this.fetchUniformLocation(name), value1, value2, value3);

    [LineNumberTable(new byte[] {161, 49, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(int location, float value1, float value2, float value3) => Gl.uniform3f(location, value1, value2, value3);

    [LineNumberTable(new byte[] {161, 61, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(
      string name,
      float value1,
      float value2,
      float value3,
      float value4)
    {
      Gl.uniform4f(this.fetchUniformLocation(name), value1, value2, value3, value4);
    }

    [LineNumberTable(new byte[] {161, 66, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(
      int location,
      float value1,
      float value2,
      float value3,
      float value4)
    {
      Gl.uniform4f(location, value1, value2, value3, value4);
    }

    [LineNumberTable(new byte[] {160, 177, 116, 109, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int fetchAttributeLocation([In] string obj0)
    {
      int attribLocation;
      if ((attribLocation = this.attributes.get((object) obj0, -2)) == -2)
      {
        attribLocation = Gl.getAttribLocation(this.program, obj0);
        this.attributes.put((object) obj0, attribLocation);
      }
      return attribLocation;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void apply()
    {
    }

    [LineNumberTable(new byte[] {160, 160, 104, 113, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getLog()
    {
      if (!this.isCompiled)
        return this.log;
      this.log = Gl.getProgramInfoLog(this.program);
      return this.log;
    }

    [LineNumberTable(new byte[] {160, 212, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformi(int location, int value) => Gl.uniform1i(location, value);

    [LineNumberTable(new byte[] {160, 222, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformi(string name, int value1, int value2) => Gl.uniform2i(this.fetchUniformLocation(name), value1, value2);

    [LineNumberTable(new byte[] {160, 227, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformi(int location, int value1, int value2) => Gl.uniform2i(location, value1, value2);

    [LineNumberTable(new byte[] {160, 238, 104, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformi(string name, int value1, int value2, int value3) => Gl.uniform3i(this.fetchUniformLocation(name), value1, value2, value3);

    [LineNumberTable(new byte[] {160, 243, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformi(int location, int value1, int value2, int value3) => Gl.uniform3i(location, value1, value2, value3);

    [LineNumberTable(new byte[] {160, 255, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformi(string name, int value1, int value2, int value3, int value4) => Gl.uniform4i(this.fetchUniformLocation(name), value1, value2, value3, value4);

    [LineNumberTable(new byte[] {161, 4, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformi(int location, int value1, int value2, int value3, int value4) => Gl.uniform4i(location, value1, value2, value3, value4);

    [LineNumberTable(new byte[] {161, 13, 104, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(string name, float value) => Gl.uniform1f(this.fetchUniformLocation(name), value);

    [LineNumberTable(new byte[] {161, 18, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(int location, float value) => Gl.uniform1f(location, value);

    [LineNumberTable(new byte[] {161, 70, 104, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniform1fv(string name, float[] values, int offset, int length) => Gl.uniform1fv(this.fetchUniformLocation(name), length, values, offset);

    [LineNumberTable(new byte[] {161, 75, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniform1fv(int location, float[] values, int offset, int length) => Gl.uniform1fv(location, length, values, offset);

    [LineNumberTable(new byte[] {161, 79, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniform2fv(string name, float[] values, int offset, int length) => Gl.uniform2fv(this.fetchUniformLocation(name), length / 2, values, offset);

    [LineNumberTable(new byte[] {161, 84, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniform2fv(int location, float[] values, int offset, int length) => Gl.uniform2fv(location, length / 2, values, offset);

    [LineNumberTable(new byte[] {161, 88, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniform3fv(string name, float[] values, int offset, int length) => Gl.uniform3fv(this.fetchUniformLocation(name), length / 3, values, offset);

    [LineNumberTable(new byte[] {161, 93, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniform3fv(int location, float[] values, int offset, int length) => Gl.uniform3fv(location, length / 3, values, offset);

    [LineNumberTable(new byte[] {161, 97, 104, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniform4fv(string name, float[] values, int offset, int length) => Gl.uniform4fv(this.fetchUniformLocation(name), length / 4, values, offset);

    [LineNumberTable(new byte[] {161, 102, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniform4fv(int location, float[] values, int offset, int length) => Gl.uniform4fv(location, length / 4, values, offset);

    [LineNumberTable(new byte[] {161, 111, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix(string name, Mat matrix) => this.setUniformMatrix(name, matrix, false);

    [LineNumberTable(new byte[] {161, 125, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix(int location, Mat matrix) => this.setUniformMatrix(location, matrix, false);

    [LineNumberTable(new byte[] {161, 141, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix4(string name, Mat mat, float near, float far) => Gl.uniformMatrix4fv(this.fetchUniformLocation(name), 1, false, Shader.copyTransform(mat, near, far), 0);

    [LineNumberTable(new byte[] {159, 12, 99, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix3fv(
      string name,
      FloatBuffer buffer,
      int count,
      bool transpose)
    {
      int num = transpose ? 1 : 0;
      ((Buffer) buffer).position(0);
      Gl.uniformMatrix3fv(this.fetchUniformLocation(name), count, num != 0, buffer);
    }

    [LineNumberTable(new byte[] {159, 9, 99, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix4fv(
      string name,
      FloatBuffer buffer,
      int count,
      bool transpose)
    {
      int num = transpose ? 1 : 0;
      ((Buffer) buffer).position(0);
      Gl.uniformMatrix4fv(this.fetchUniformLocation(name), count, num != 0, buffer);
    }

    [LineNumberTable(new byte[] {161, 173, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformMatrix4fv(string name, float[] values, int offset, int length) => this.setUniformMatrix4fv(this.fetchUniformLocation(name), values, offset, length);

    [LineNumberTable(new byte[] {161, 182, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(string name, Vec2 values) => this.setUniformf(name, values.x, values.y);

    [LineNumberTable(new byte[] {161, 186, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(int location, Vec2 values) => this.setUniformf(location, values.x, values.y);

    [LineNumberTable(new byte[] {161, 195, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(string name, Vec3 values) => this.setUniformf(name, values.x, values.y, values.z);

    [LineNumberTable(new byte[] {161, 199, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(int location, Vec3 values) => this.setUniformf(location, values.x, values.y, values.z);

    [LineNumberTable(new byte[] {161, 208, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(string name, Color values) => this.setUniformf(name, values.r, values.g, values.b, values.a);

    [LineNumberTable(new byte[] {161, 212, 127, 0})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setUniformf(int location, Color values) => this.setUniformf(location, values.r, values.g, values.b, values.a);

    [LineNumberTable(new byte[] {158, 249, 67, 104, 101, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVertexAttribute(
      string name,
      int size,
      int type,
      bool normalize,
      int stride,
      Buffer buffer)
    {
      int num = normalize ? 1 : 0;
      int indx = this.fetchAttributeLocation(name);
      if (indx == -1)
        return;
      Gl.vertexAttribPointer(indx, size, type, num != 0, stride, buffer);
    }

    [LineNumberTable(new byte[] {158, 248, 131, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVertexAttribute(
      int location,
      int size,
      int type,
      bool normalize,
      int stride,
      Buffer buffer)
    {
      int num = normalize ? 1 : 0;
      Gl.vertexAttribPointer(location, size, type, num != 0, stride, buffer);
    }

    [LineNumberTable(new byte[] {158, 244, 67, 104, 101, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVertexAttribute(
      string name,
      int size,
      int type,
      bool normalize,
      int stride,
      int offset)
    {
      int num = normalize ? 1 : 0;
      int indx = this.fetchAttributeLocation(name);
      if (indx == -1)
        return;
      Gl.vertexAttribPointer(indx, size, type, num != 0, stride, offset);
    }

    [LineNumberTable(new byte[] {158, 243, 131, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setVertexAttribute(
      int location,
      int size,
      int type,
      bool normalize,
      int stride,
      int offset)
    {
      int num = normalize ? 1 : 0;
      Gl.vertexAttribPointer(location, size, type, num != 0, stride, offset);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDisposed() => this.disposed;

    [LineNumberTable(new byte[] {162, 28, 104, 101, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disableVertexAttribute(string name)
    {
      int index = this.fetchAttributeLocation(name);
      if (index == -1)
        return;
      Gl.disableVertexAttribArray(index);
    }

    [LineNumberTable(new byte[] {162, 34, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void disableVertexAttribute(int location) => Gl.disableVertexAttribArray(location);

    [LineNumberTable(new byte[] {162, 42, 104, 101, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void enableVertexAttribute(string name)
    {
      int index = this.fetchAttributeLocation(name);
      if (index == -1)
        return;
      Gl.enableVertexAttribArray(index);
    }

    [LineNumberTable(new byte[] {162, 48, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void enableVertexAttribute(int location) => Gl.enableVertexAttribArray(location);

    [LineNumberTable(new byte[] {162, 60, 104, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAttributef(
      string name,
      float value1,
      float value2,
      float value3,
      float value4)
    {
      Gl.vertexAttrib4f(this.fetchAttributeLocation(name), value1, value2, value3, value4);
    }

    [LineNumberTable(735)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasAttribute(string name) => this.attributes.containsKey((object) name);

    [LineNumberTable(743)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAttributeType(string name) => this.attributeTypes.get((object) name, 0);

    [LineNumberTable(751)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAttributeLocation(string name) => this.attributes.get((object) name, -1);

    [LineNumberTable(759)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getAttributeSize(string name) => this.attributeSizes.get((object) name, 0);

    [LineNumberTable(767)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasUniform(string name) => this.uniforms.containsKey((object) name);

    [LineNumberTable(775)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getUniformType(string name) => this.uniformTypes.get((object) name, 0);

    [LineNumberTable(783)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getUniformLocation(string name) => this.uniforms.get((object) name, -1);

    [LineNumberTable(791)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getUniformSize(string name) => this.uniformSizes.get((object) name, 0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getAttributes() => this.attributeNames;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string[] getUniforms() => this.uniformNames;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getVertexShaderSource() => this.vertexShaderSource;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFragmentShaderSource() => this.fragmentShaderSource;

    [LineNumberTable(new byte[] {159, 128, 109, 230, 69, 234, 69, 234, 162, 235})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Shader()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.graphics.gl.Shader"))
        return;
      Shader.pedantic = false;
      Shader.prependVertexCode = "";
      Shader.prependFragmentCode = "";
      Shader.val = new float[16];
    }
  }
}
